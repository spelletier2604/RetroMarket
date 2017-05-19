using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RetroMarket.Models;
using RetroMarket.Models.ViewModels;
using Stripe;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Claims;

namespace RetroMarket.Controllers
{

    public class OrderController : Controller
    {
        private IOrderRepository repository;
        private Cart cart;
        private ApplicationDbContext _context;

        public OrderController(IOrderRepository repoService, Cart cartService, ApplicationDbContext context)
        {
            repository = repoService;
            cart = cartService;
            _context = context;
            ViewData.Add("Total", cart.ComputeTotalValue());
        }

        [Authorize]
        public ViewResult List() =>
            View(repository.Orders.Where(o => !o.Shipped));
        [HttpPost]
        [Authorize]
        public IActionResult MarkShipped(int orderID)
        {
            Order order = repository.Orders
            .FirstOrDefault(o => o.OrderID == orderID);
            if (order != null)
            {
                order.Shipped = true;
                repository.SaveOrder(order);
            }
            return RedirectToAction(nameof(List));
        }

        public ViewResult Checkout()
        {
            Order order = new Order();


            return View(order);
        }

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            if (cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your cart is empty!");
            }
            if (ModelState.IsValid)
            {
                order.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                order.Lines = cart.Lines.ToArray();
                repository.SaveOrder(order);
                return RedirectToAction(nameof(Confirm), order);
            }
            else
            {
                return View(order);
            }
        }

        public ViewResult Confirm(Order ordererer)
        {
            Order order = _context.Orders.Where(o => o.UserId == User.FindFirstValue(ClaimTypes.NameIdentifier)).LastOrDefault();
            if (order == null)
                return View();
            ShipViewModel ship = new ShipViewModel
            {
                Order = order,
                OrderId = order.OrderID,
                Valid = false
            };

            // Pour s'assurer que la commande a passer par Checkout
            if (order.Line1 == null && order.Line2 == null && order.Line3 == null)
            {
                ModelState.AddModelError("", "Sorry, an error occured, please try again.");
                return View(ship);
            }
            if (ModelState.IsValid)
            {
                TaxesCanada t = new TaxesCanada((TaxesCanada.Abbre)Enum.Parse(typeof(TaxesCanada.Abbre), order.State));
                float montant = 0.0f;

                ship.PriceRaw = (float)cart.ComputeTotalValue();
                ViewData["Price"] = cart.ComputeTotalValue();
                if (order.State == "QC")
                {
                    montant = ((float)ship.PriceRaw * (1 + t.GST + t.PST));
                }
                else
                {
                    montant = ((float)ship.PriceRaw * (1 + t.GST));
                }
                ship.PriceTaxes = montant;
                ViewData["Taxes"] = montant;

                bool shipperIsPurolator = true;
                float purolator = 0.0f;
                float postecanada = 0.0f;
                purolator = CalculTransportPurolator(cart);
                postecanada = CalculTransportPosteCanada(cart, ship);

                if (postecanada == 0.0f)
                    shipperIsPurolator = true;
                else if (purolator > postecanada)
                    shipperIsPurolator = false;

                if (shipperIsPurolator)
                    ship.PriceShip = purolator;

                else
                    ship.PriceShip = postecanada;

                ship.PriceTotal = ship.PriceTaxes + ship.PriceShip;
                ship.PriceCents = Convert.ToInt32(100 * ship.PriceTotal);
                ViewData["Shipping"] = ship.PriceShip;
                ViewData["Total"] = ship.PriceTotal;
                ship.Valid = true;
                return View(ship);
            }
            else
            {
                return View(ship);
            }
        }

        [HttpPost]
        public IActionResult Confirm(ShipViewModel ship)
        {
            ship.Order = _context.Orders.FirstOrDefault(o => o.OrderID == ship.OrderId);
            // if (ship.SelectedShip == 1)
            //{
            //    ship.PriceTotal = ship.PriceTaxes + ship.PriceShipPurolator;

            //    return RedirectToAction(nameof(Completed), ship);
            //  }
            //  else if (ship.SelectedShip == 2)
            //  {
            //     ship.PriceTotal = ship.PriceTaxes + ship.PriceShipPosteCanada;
            //
            //       return RedirectToAction(nameof(Completed), ship);
            // //  }
            //   else
            //   {
            return View();
            // }
        }

        public ViewResult Completed(ShipViewModel ship)
        {

            cart.Clear();
            return View();
        }

        public float CalculTransportPurolator(Cart cart)
        {
            float result = 0.0f;
            float poids = 0.0f;
            float poidsArrondie = 0.0f;
            float prixPoids = 0.0f;

            foreach (CartLine item in cart.Lines)
            {
                poids += item.Product.Poids;
            }

            /*Devrait s'assurer qu'on a un chiffre arrondie à la valeur
             dizaine inférieur (Exemple 11 = 10)
             Exemple de ce que le code fait:
             56 / 10 = 5.6;
             5.6 - 0.5 = 5.1;
             Round(5.1) = 5;
             5 * 10 = 50;
             */
            poidsArrondie = (float)Math.Round(poids / 10 - 0.5) * 10;

            prixPoids = _context.Purolator.FirstOrDefault(x => x.MargedePoid == (int)poidsArrondie).Modificateur;

            result = poids * prixPoids;
            return result;
        }

        public float CalculTransportPosteCanada(Cart cart, ShipViewModel ship)
        {
            float result = 0.0f;
            //float poids = 0.0f;
            List<float> panierPoids = new List<float>();

            int i = 1;
            foreach (CartLine item in cart.Lines)
            {
                panierPoids.Add(item.Product.Poids);
            }

            //PosteCanada.Program posteCanada = new PosteCanada.Program();
            //posteCanada.Principale(panierPoids, ship.Order.Zip);
            //TestClient client = new TestClient();
            //result = client.CallGetQuickEstimate(ship.Order.City, ship.Order.Country, ship.Order.State, ship.Order.Zip, Convert.ToInt32(poids));

            return result;
        }

        public IActionResult Charge(string stripeEmail, string stripeToken, int amount)
        {
            var customers = new StripeCustomerService();
            var charges = new StripeChargeService();

            var customer = customers.Create(new StripeCustomerCreateOptions
            {
                Email = stripeEmail,
                SourceToken = stripeToken
            });

            var charge = charges.Create(new StripeChargeCreateOptions
            {
                Amount = amount,
                Description = "Sample Charge",
                Currency = "cad",
                CustomerId = customer.Id
            });

            return View();
        }
    }
}

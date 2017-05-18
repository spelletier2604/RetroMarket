using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RetroMarket.Models;
using RetroMarket.Models.ViewModels;
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
                Valid = false,
                ShipOptions = new List<ShipOptions>
                {
                    new ShipOptions {Id = 1, ShipName = "Purolator" },
                    new ShipOptions {Id = 2, ShipName = "Poste Canada" }
                }
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


                ship.PriceShipPurolator = CalculTransportPurolator(cart);
                ViewData["Purolator"] = CalculTransportPurolator(cart);
                ship.PriceShipPosteCanada = CalculTransportPosteCanada(cart);
                ViewData["PosteCanada"] = CalculTransportPosteCanada(cart);

                ViewData["TotalPurolator"] = ship.PriceTaxes + ship.PriceShipPurolator;
                ViewData["TotalPosteCanada"] = ship.PriceTaxes + ship.PriceShipPosteCanada;

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
            if (ship.SelectedShip == 1)
            {
                ship.PriceTotal = ship.PriceTaxes + ship.PriceShipPurolator;

                return RedirectToAction(nameof(Completed), ship);
            }
            else if (ship.SelectedShip == 2)
            {
                ship.PriceTotal = ship.PriceTaxes + ship.PriceShipPosteCanada;

                return RedirectToAction(nameof(Completed), ship);
            }
            else
            {
                return View();
            }
        }

        public ViewResult Completed(ShipViewModel ship)
        {
            ViewData["Price"] = ship.PriceRaw;
            ViewData["Taxes"] = ship.PriceTaxes;

            if (ship.SelectedShip == 1)
            {
                ViewData["Transport"] = ship.PriceShipPurolator;
            }
            else if (ship.SelectedShip == 2)
            {
                ViewData["Transport"] = ship.PriceShipPosteCanada;
            }

            ViewData["Total"] = ship.PriceTotal;

            cart.Clear();
            return View();
        }

        public float CalculTransportPurolator(Cart cart)
        {
            float result = 0.0f;
            float poids = 0.0f;

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
            poids = (float)Math.Round(poids / 10 - 0.5) * 10;

            result = _context.Purolator.FirstOrDefault(x => x.MargedePoid == (int)poids).Modificateur;

            return result;
        }

        public float CalculTransportPosteCanada(Cart cart)
        {
            //float result = 0.0f;
            //float poids = 0.0f;
            //
            //foreach (CartLine item in cart.Lines)
            //{
            //    poids += item.Product.Poids;
            //}
            //
            ///*Devrait s'assurer qu'on a un chiffre arrondie à la valeur
            // dizaine inférieur (Exemple 11 = 10)
            // Exemple de ce que le code fait:
            // 56 / 10 = 5.6;
            // 5.6 - 0.5 = 5.1;
            // Round(5.1) = 5;
            // 5 * 10 = 50;
            // */
            //poids = (float)Math.Round(poids / 10 - 0.5) * 10;
            //
            //result = _context.Purolator.FirstOrDefault(x => x.MargedePoid == (int)poids).Modificateur;
            //
            return 0;
        }
    }
}

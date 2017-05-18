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
                return RedirectToAction(nameof(Completed), order);
            }
            else
            {
                return View(order);
            }
        }
        // PAS TOUCHE JE SUIS EN TRAIN DLE FAIRE - David
        //public ViewResult Confirm(Order order)
        //{
        //    ShipViewModel ship = new ShipViewModel { Order = order, PosteCanada = false, Purolator = false };
        //    if (cart.Lines.Count() == 0)
        //    {
        //        ModelState.AddModelError("", "Sorry, your cart is empty!");
        //    }
        //    // Pour s'assurer que la commande a passer par Checkout
        //    if (order.UserId == null || order.Lines == null)
        //    {
        //        ModelState.AddModelError("", "Sorry, an error occured, please try again.");
        //    }
        //    if (ModelState.IsValid)
        //    {
        //        TaxesCanada t = new TaxesCanada((TaxesCanada.Abbre)Enum.Parse(typeof(TaxesCanada.Abbre), order.State));
        //        float montant = 0.0f;
        //
        //        ship
        //
        //        ViewData["Price"] = cart.ComputeTotalValue();
        //        if (order.State == "QC")
        //        {
        //            montant = ((float)cart.ComputeTotalValue() * (1 + t.GST + t.PST));
        //            ViewData["Taxes"] = montant;
        //        }
        //        else
        //        {
        //            montant = ((float)cart.ComputeTotalValue() * (1 + t.GST));
        //            ViewData["Taxes"] = montant;
        //        }
        //
        //        ViewData["Transport"] = CalculTransportPurolator(cart);
        //
        //        return View(new ShipViewModel { Order = order, PosteCanada = false, Purolator = false, Valid = true });
        //    }
        //    else
        //    {
        //        return View(ship);
        //    }
        //}

        //[HttpPost]
        //public IActionResult Confirm(ShipViewModel order)
        //{
        //    //   if (cart.Lines.Count() == 0)
        //    //   {
        //    //       ModelState.AddModelError("", "Sorry, your cart is empty!");
        //    //   }
        //    //   // Pour s'assurer que la commande a passer par Checkout
        //    //   if (order.UserId == null || order.Lines == null)
        //    //   {
        //    //       ModelState.AddModelError("", "Sorry, an error occured, please try again.");
        //    //   }
        //    //   if (ModelState.IsValid)
        //    //   {
        //    //       return View(order);
        //    //   }
        //    //   else
        //    //   {
        //    //       return View(order);
        //    //   }
        //    return View();
        //}

        public ViewResult Completed(Order orderer)
        {
            TaxesCanada t = new TaxesCanada((TaxesCanada.Abbre)Enum.Parse(typeof(TaxesCanada.Abbre), orderer.State));
            float montant = 0.0f;
            ViewData["Price"] = cart.ComputeTotalValue();
            if (orderer.State == "QC")
            {
                montant = ((float)cart.ComputeTotalValue() * (1 + t.GST + t.PST));
                ViewData["Taxes"] = montant;
            }
            else
            {
                montant = ((float)cart.ComputeTotalValue() * (1 + t.GST));
                ViewData["Taxes"] = montant;
            }

            ViewData["Transport"] = CalculTransportPurolator(cart);

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
    }
}

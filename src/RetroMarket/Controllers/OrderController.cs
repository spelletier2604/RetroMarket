using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RetroMarket.Models;
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

        public OrderController(IOrderRepository repoService, Cart cartService)
        {
            repository = repoService;
            cart = cartService;
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

        public ViewResult Completed(Order orderer)
        {
            TaxesCanada t = new TaxesCanada((TaxesCanada.Abbre)Enum.Parse(typeof(TaxesCanada.Abbre), orderer.State));
            ViewData["Price"] = cart.ComputeTotalValue();
            if (orderer.State == "QC")
            {
                ViewData["Taxes"] = ((float)cart.ComputeTotalValue() * (1 + t.GST + t.PST));
            }
            else
            {
                ViewData["Taxes"] = ((float)cart.ComputeTotalValue() * (1 + t.GST));
            }
            cart.Clear();
            return View();
        }
    }
}

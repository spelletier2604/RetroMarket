using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RetroMarket.Models;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace RetroMarket.Controllers
{

    public class UserOrderController : Controller
    {
        private IOrderRepository repository;

        public UserOrderController(IOrderRepository repoService)
        {
            repository = repoService;
        }

        [Authorize]
        public ViewResult List()
        {
            return View(repository.Orders.Where(u => u.UserId == User.FindFirstValue(ClaimTypes.NameIdentifier)));
        }
    }
}

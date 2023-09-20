using Microsoft.AspNetCore.Mvc;

namespace Northwind.MVC.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {

            return View();
        }
    }
}

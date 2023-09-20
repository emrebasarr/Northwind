using Microsoft.AspNetCore.Mvc;

namespace Northwind.MVC.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

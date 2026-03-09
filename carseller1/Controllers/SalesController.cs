using Microsoft.AspNetCore.Mvc;

namespace carseller1.Controllers
{
    public class SalesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

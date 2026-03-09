using Microsoft.AspNetCore.Mvc;

namespace carseller1.Controllers
{
    public class VehiclesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

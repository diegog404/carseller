using Microsoft.AspNetCore.Mvc;

namespace carseller1.Controllers
{
    public class CompaniesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

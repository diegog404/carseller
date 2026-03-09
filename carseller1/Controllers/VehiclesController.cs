using carseller1.Models;
using carseller1.Services;
using Microsoft.AspNetCore.Mvc;

namespace carseller1.Controllers
{
    public class VehiclesController : Controller
    {
        private readonly VehicleService _vehicleService;

        public VehiclesController(VehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        public IActionResult Index()
        {
            var list = _vehicleService.FindAll();
            return View(list);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Vehicle vehicle)
        {
            _vehicleService.Insert(vehicle);
            return RedirectToAction(nameof(Index));
        }
    }
}

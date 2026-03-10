using carseller1.Models;
using carseller1.Models.ViewModels;
using carseller1.Services;
using Microsoft.AspNetCore.Mvc;

namespace carseller1.Controllers
{
    public class VehiclesController : Controller
    {
        private readonly VehicleService _vehicleService;
        private readonly CompanyService _companyService;

        public VehiclesController(VehicleService vehicleService, CompanyService companyService)
        {
            _vehicleService = vehicleService;
            _companyService = companyService;
        }

        public IActionResult Index()
        {
            var list = _vehicleService.FindAll();
            return View(list);
        }

        public IActionResult Create()
        {
            var companies = _companyService.FindAll();
            var viewModel = new VehicleFormViewModel { Companies = companies };
            return View(viewModel);
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

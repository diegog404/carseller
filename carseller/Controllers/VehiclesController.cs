using carseller.Models;
using carseller.Models.ViewModels;
using carseller.Services;
using Microsoft.AspNetCore.Mvc;

namespace carseller.Controllers
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

        public async Task<IActionResult> Index()
        {
            var list = await _vehicleService.FindAllAsync();
            return View(list);
        }

        public async Task<IActionResult> Create()
        {
            var companies = await _companyService.FindAllAsync();
            var viewModel = new VehicleFormViewModel { Companies = companies };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Vehicle vehicle)
        { 
            await _vehicleService.InsertAsync(vehicle);
            return RedirectToAction(nameof(Index));
        }
    }
}

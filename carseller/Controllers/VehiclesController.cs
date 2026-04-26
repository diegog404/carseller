using carseller.Models;
using carseller.Models.ViewModels;
using carseller.Services;
using carseller.Services.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
            if (!ModelState.IsValid)
            {
                var companies = await _companyService.FindAllAsync();

                var viewModel = new VehicleFormViewModel { Vehicle = vehicle, Companies = companies };
                return View(viewModel);
            }

            await _vehicleService.InsertAsync(vehicle);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not provided." });
            }

            var obj = await _vehicleService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found." });
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _vehicleService.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not provided." });
            }

            var obj = await _vehicleService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found." });
            }

            return View(obj);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not provided." });
            }

            var obj = await _vehicleService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }

            List<Company> companies = await _companyService.FindAllAsync();

            VehicleFormViewModel viewModel = new VehicleFormViewModel { Vehicle = obj, Companies = companies };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Vehicle vehicle)
        {
            if (!ModelState.IsValid)
            {
                var companies = await _companyService.FindAllAsync();

                var viewModel = new VehicleFormViewModel { Vehicle = vehicle, Companies = companies };
                return View(viewModel);
            }

            if (id != vehicle.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "Id mismatch" });
            }

            try
            {
                await _vehicleService.UpdateAsync(vehicle);
                return RedirectToAction(nameof(Index));
            }
            catch (NotFoundException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
            catch (DbConcurrencyException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
        }

        public IActionResult Error(string message)
        {
            var viewModel = new ErrorViewModel
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
            return View(viewModel);
        }
    }
}

using carseller.Models;
using carseller.Services;
using carseller.Services.Exceptions;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace carseller.Controllers
{
    public class CompaniesController : Controller
    {
        private readonly CompanyService _companyService;

        public CompaniesController(CompanyService companyService)
        {
            _companyService = companyService;
        }

        public async Task<IActionResult> Index()
        {
            var list = await _companyService.FindAllAsync();
            return View(list);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Company company)
        {
            if (!ModelState.IsValid)
            {
                return View(company);
            }

            await _companyService.InsertAsync(company);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not provided." });
            }

            var obj = await _companyService.FindByIdAsync(id.Value);
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
            await _companyService.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int? id)
        {
            {
                if (id == null)
                {
                    return RedirectToAction(nameof(Error), new { message = "Id not provided." });
                }

                var obj = await _companyService.FindByIdAsync(id.Value);
                if (obj == null)
                {
                    return RedirectToAction(nameof(Error), new { message = "Id not found." });
                }

                return View(obj);
            }
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not provided." });
            }

            var obj = await _companyService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found." });
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Company company)
        {
            if (!ModelState.IsValid)
            {
                return View(company);
            }

            if (id != company.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "Id mismatch" });
            }

            try
            {
                await _companyService.UpdateAsync(company);
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
    }
}

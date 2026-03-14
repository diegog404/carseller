using carseller1.Models;
using carseller1.Services;
using Microsoft.AspNetCore.Mvc;

namespace carseller1.Controllers
{
    public class CompaniesController : Controller
    {
        private readonly CompanyService _companyService;

        public CompaniesController(CompanyService companyService)
        {
            _companyService = companyService;
        }

        public IActionResult Index()
        {
            var list = _companyService.FindAll();
            return View(list);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Company company)
        {
            _companyService.Insert(company);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var obj = _companyService.FindById(id.Value);
            if(obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _companyService.Remove(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

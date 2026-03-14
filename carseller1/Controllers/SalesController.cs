using carseller1.Models;
using carseller1.Models.ViewModels;
using carseller1.Services;
using Microsoft.AspNetCore.Mvc;

namespace carseller1.Controllers
{
    public class SalesController : Controller
    {
        private readonly SaleService _saleService;
        private readonly ClientService _clientService;
        private readonly UserService _userService;

        public SalesController(SaleService saleService, ClientService clientService, UserService userService)
        {
            _saleService = saleService;
            _clientService = clientService;
            _userService = userService;
        }

        public IActionResult Index()
        {
            var list = _saleService.FindAll();
            return View(list);
        }

        public IActionResult Create()
        {
            var clients = _clientService.FindAll();
            var users = _userService.FindAll();
            var viewModel = new SaleFormViewModel { Clients = clients, Users = users };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Sale sale)
        {
            _saleService.Insert(sale);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obj = _saleService.FindById(id.Value);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _saleService.Remove(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obj = _saleService.FindById(id.Value);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }
    }
}

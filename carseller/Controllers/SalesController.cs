using carseller.Models;
using carseller.Models.ViewModels;
using carseller.Services;
using Microsoft.AspNetCore.Mvc;

namespace carseller.Controllers
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

        public async Task<IActionResult> Index()
        {
            var list = await _saleService.FindAllAsync();
            return View(list);
        }

        public async Task<IActionResult> Create()
        {
            var clients = await _clientService.FindAllAsync();
            var users = await _userService.FindAllAsync();
            var viewModel = new SaleFormViewModel { Clients = clients, Users = users };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Sale sale)
        {
            await _saleService.InsertAsync(sale);
            return RedirectToAction(nameof(Index));
        }
    }
}

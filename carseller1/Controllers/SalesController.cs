using carseller1.Models;
using carseller1.Models.ViewModels;
using carseller1.Services;
using carseller1.Services.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

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
            if (!ModelState.IsValid)
            {
                var clients = await _clientService.FindAllAsync();
                var users = await _userService.FindAllAsync();
                var viewModel = new SaleFormViewModel { Clients = clients, Users = users };
                return View(viewModel);
            }

            await _saleService.InsertAsync(sale);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not provided." });
            }

            var obj = await _saleService.FindByIdAsync(id.Value);
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
            await _saleService.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not provided." });
            }

            var obj = await _saleService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found."});
            }

            return View(obj);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not provided." });
            }

            var obj = await _saleService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found." });
            }

            List<Client> clients = await _clientService.FindAllAsync();
            List<User> users = await _userService.FindAllAsync();

            SaleFormViewModel viewModel = new SaleFormViewModel { Sale = obj, Clients = clients, Users = users };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Sale sale)
        {
            if (!ModelState.IsValid)
            {
                var clients = await _clientService.FindAllAsync();
                var users = await _userService.FindAllAsync();
                var viewModel = new SaleFormViewModel { Clients = clients, Users = users };
                return View(viewModel);
            }

            if (id != sale.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "Id mismatch." });
            }

            try
            {
                await _saleService.UpdateAsync(sale);
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

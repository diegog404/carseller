using carseller.Data;
using carseller.Models;
using carseller.Models.Enums;
using carseller.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace carseller.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly carsellerContext _context;

        public HomeController(ILogger<HomeController> logger, carsellerContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var homeViewModel = new HomeViewModel
            {
                SalesInProgress = _context.Sale
                .Include(s => s.Vehicles)
                .Where(s => s.Status == SaleStatus.Pending)
                .ToList()
            };

            return View(homeViewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

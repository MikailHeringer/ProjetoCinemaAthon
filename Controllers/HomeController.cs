using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoCinemaAthon.Data;
using ProjetoCinemaAthon.Models;
using System.Diagnostics;

namespace ProjetoCinemaAthon.Controllers
{
    public class HomeController : Controller
    {
        // private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(/*ILogger<HomeController> logger,*/ ApplicationDbContext context)
        {
            //_logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            if (TempData["ResId"] != null)
            {
                int resId = (int) TempData["ResId"];
                if (resId == 1)
                {
                    ViewBag.Message = "true";
                }
                else if (resId == 2)
                {
                    ViewBag.Message = "false";
                }
            }
            return View(_context.RegistrarFilme);
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

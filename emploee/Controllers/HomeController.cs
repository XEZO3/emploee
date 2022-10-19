using emploee.Data;
using emploee.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace emploee.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly emploeeContext _context;
        //private readonly IWebHostEnvironment _hostEnviroment;

        public HomeController(emploeeContext context)
        {
            _context = context;
            //_hostEnviroment = hostEnviroment;
        }
        

        public IActionResult Index()
        {
            List<Emploee> emploee = _context.Emploees.ToList();
            return View(emploee);
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
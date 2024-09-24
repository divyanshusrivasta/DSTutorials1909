using DSTutorials1909.Data;
using DSTutorials1909.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DSTutorials1909.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _db;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger,ApplicationDbContext db)
        {
            _db = db;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var course = _db.Courses.ToList();

            return View(course);
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

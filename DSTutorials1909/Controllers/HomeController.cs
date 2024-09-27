using DSTutorials1909.Data;
using DSTutorials1909.Models;
<<<<<<< HEAD
using DSTutorials1909.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
=======
using Microsoft.AspNetCore.Mvc;
>>>>>>> 03c1add88b450c3c8e635227f66386f4516beae6
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

<<<<<<< HEAD

        

=======
>>>>>>> 03c1add88b450c3c8e635227f66386f4516beae6
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

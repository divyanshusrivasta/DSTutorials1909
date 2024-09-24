using DSTutorials1909.Data;
using Microsoft.AspNetCore.Mvc;

namespace DSTutorials1909.Controllers
{
    public class MainController : Controller
    {
        private readonly ApplicationDbContext _db;
        public MainController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {

            return View();
        }
    }
}

using DSTutorials1909.Data;
using DSTutorials1909.Models;
using DSTutorials1909.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading.Tasks;

namespace DSTutorials1909.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly ILogger<HomeController> _logger;
        private readonly RoleManager<IdentityRole> _roleManager;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db, RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _logger = logger;
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            var course = _db.Courses.ToList();
            return View(course);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(RoleStore role)
        {
            var rolexist = await _roleManager.RoleExistsAsync(role.RoleName);
            if (!rolexist)
            {
                await _roleManager.CreateAsync(new IdentityRole(role.RoleName));
            }
            return RedirectToAction("Index");
        }

        public IActionResult Tutorials()
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



        public IActionResult Contact()
        {
            return View();
        }



        public IActionResult QuestionList()
        {
            var data=_db.Questions.ToList();
            return View(data);
        }

        public IActionResult SolutionList()
        {

            // Retrieve questions and solutions authored by the logged-in user
            var vm = new CourseViewModel()
            {
                // Get only the questions authored by the logged-in user
                QuestionList = _db.Questions
                    .ToList(),

                // Get only the solutions authored by the logged-in user, including related questions
                SolutionsList = _db.Solutions
                    .Include(s => s.Question) // Include related questions
                    .ToList()
            };

            return View(vm);
        }



        #region API CALLS
        public IActionResult GetAll()
        {
            var que = _db.Questions.ToList();
            return Json(new { data=que });
        }

        public IActionResult GetAllSolutions()
        {
            var solutions = _db.Solutions
                    .Include(s => s.Question) // Include related questions
                    .Select(s => new
                    {
                        s.SId,
                        s.CreatedDate,
                        QuestionTitle = s.Question.QName, // The title of the associated question
                        QuestionId = s.Question.QId // The ID of the associated question
                    })
                    .ToList();

            return Json(new { data = solutions });
        }
        #endregion
    }
}

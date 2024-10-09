using DSTutorials1909.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace DSTutorials1909.Controllers
{
    [Authorize (Roles ="Admin,User")] // Ensure only logged-in users can access the dashboard
    public class DashboardController : Controller
    {
        private readonly ApplicationDbContext _db;
        public DashboardController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var userName = User.Identity.Name;

            var questionCount = _db.Questions.Count(q => q.Author == userName);

            var solvedCount = _db.Questions.Count(q => q.Author == userName && q.Solutions.Any());

            var unsolvedCount = _db.Questions.Count(q => q.Author == userName && !q.Solutions.Any());

            var answerCount = _db.Solutions.Count(s => s.SAuthor == userName);

            ViewBag.QuestionCount = questionCount;
            ViewBag.SolvedCount = solvedCount;
            ViewBag.UnsolvedCount = unsolvedCount;
            ViewBag.AnswerCount = answerCount;
            ViewBag.UserName = userName; 

            return View();
        }
    }
}

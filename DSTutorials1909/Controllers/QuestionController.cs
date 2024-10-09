using DSTutorials1909.Data;
using DSTutorials1909.Models;
using DSTutorials1909.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;

namespace DSTutorials1909.Controllers
{
    
    public class QuestionController : Controller
    {
        private readonly ApplicationDbContext _db;
        public QuestionController(ApplicationDbContext db)
        {
            _db = db;
        }

        [Authorize(Roles = "Admin,User")]
        public IActionResult TipsQuestion()
        {
            return View();
        }
        [Authorize(Roles = "Admin,User")]
        public IActionResult TipsAnswer()
        {
            return View();
        }

        // Display only the questions authored by the logged-in user
        [Authorize(Roles = "Admin,User")]
        public IActionResult Index()
        {
            // Get the logged-in user's name
            var userName = User.Identity.Name;

            // Retrieve only the questions authored by the logged-in user
            var data = _db.Questions
                .Where(q => q.Author == userName)
                .ToList();

            return View(data);
        }
        [Authorize(Roles = "Admin,User")]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(Question que)
        {
            que.Author = User.Identity.Name; // Get the logged-in user's name
            que.CreatedDate = DateTime.Now;  // Set current date/time
            que.QUrl = que.QName.Replace(" ", "-");
            que.ModifiedDate = que.CreatedDate;
            if (ModelState.IsValid) // Validate the model
            {
                

                _db.Questions.Add(que);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }

            // If model is not valid, return the same view with the model state
            return View(que);
        }




        //[HttpPost]
        //public IActionResult Create(Question que)
        //{
        //    que.Author = User.Identity.Name; // Get the logged-in user's name
        //    que.CreatedDate = DateTime.Now;  // Set current date/time
        //    que.QUrl = que.QName.Replace(" ", "-");
        //    que.ModifiedDate = que.CreatedDate;
        //    _db.Questions.Add(que);
        //    _db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        // Edit only the questions authored by the logged-in user
        [Authorize(Roles = "Admin,User")]
        public IActionResult Edit(int qid)
        {
            var userName = User.Identity.Name;
            var data = _db.Questions.FirstOrDefault(i => i.QId == qid && i.Author == userName); // Ensure only the author's question is retrieved

            if (data == null)
            {
                return NotFound(); // Return not found if the question doesn't belong to the user
            }

            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(Question que)
        {
            que.ModifiedDate = DateTime.Now;
            que.QUrl = que.QName.Replace(" ", "-");
            _db.Questions.Update(que);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        // Delete only the questions authored by the logged-in user
        [Authorize(Roles = "Admin,User")]
        public IActionResult Delete(int qid)
        {
            var userName = User.Identity.Name;
            var data = _db.Questions.FirstOrDefault(i => i.QId == qid && i.Author == userName); // Ensure only the author's question is retrieved

            if (data == null)
            {
                return NotFound(); // Return not found if the question doesn't belong to the user
            }

            return View(data);
        }

        [HttpPost]
        public IActionResult Delete(Question que)
        {
            var solutions = _db.Solutions.Where(s => s.QId == que.QId).ToList();
            _db.Solutions.RemoveRange(solutions); // Delete related solutions
            _db.Questions.Remove(que);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        // Create a solution for a specific question
        [Authorize(Roles = "Admin,User")]
        public IActionResult CreateSolution(int qid)
        {
            var question = _db.Questions.FirstOrDefault(q => q.QId == qid);
            ViewBag.Question = question;


            return View();
        }

        [HttpPost]
        public IActionResult CreateSolution(Solution sol)
        {
            sol.SAuthor = User.Identity.Name; // Get logged-in user's name
            sol.CreatedDate = DateTime.Now;
            sol.ModifiedDate = sol.CreatedDate;
            _db.Solutions.Add(sol);
            _db.SaveChanges();
            return RedirectToAction("Details", new { qid = sol.QId });
        }


        [Authorize(Roles = "Admin,User")]
        public IActionResult EditSolution(int sid)
        {
            var solution = _db.Solutions.FirstOrDefault(s => s.SId == sid);
            var question = _db.Questions.FirstOrDefault(q => q.QId == solution.QId);
            ViewBag.Question = question;
            return View(solution);
        }

        [HttpPost]
        public IActionResult EditSolution(Solution sol)
        {
            sol.ModifiedDate = DateTime.Now;
            sol.SAuthor = User.Identity.Name;
            _db.Solutions.Update(sol);
            _db.SaveChanges();
            return RedirectToAction("ViewSolutions", new { qid = sol.QId });
        }

        public IActionResult DeleteSolution(int sid)
        {
            var solution = _db.Solutions.FirstOrDefault(s => s.SId == sid);
            return View(solution);
        }

        [HttpPost]
        public IActionResult DeleteSolution(Solution sol)
        {
            _db.Solutions.Remove(sol);
            _db.SaveChanges();
            return RedirectToAction("ViewSolutions", new { qid = sol.QId });
        }




        // View solutions for a specific question
        [Authorize(Roles = "Admin,User")]
        public IActionResult ViewSolutions()
        {
            // Get the logged-in user's name
            var userName = User.Identity.Name;

            // Retrieve questions and solutions authored by the logged-in user
            var vm = new CourseViewModel()
            {
                // Get only the questions authored by the logged-in user
                QuestionList = _db.Questions
                    .Where(q => q.Author == userName)
                    .ToList(),

                // Get only the solutions authored by the logged-in user, including related questions
                SolutionsList = _db.Solutions
                    .Include(s => s.Question) // Include related questions
                    .Where(s => s.SAuthor == userName)
                    .ToList()
            };

            return View(vm);
        }

        public IActionResult Details(int qid)
        {
            // Get the logged-in user's name
            var userName = User.Identity.Name;

            // Get the question with its associated solutions
            var question = _db.Questions
                .Include(q => q.Solutions) // Include related solutions
                .FirstOrDefault(q => q.QId == qid); // Filter by question ID and user

            // Check if question is found and belongs to the logged-in user
            if (question == null)
            {
                return NotFound(); // Handle the case when question is not found or doesn't belong to the user
            }

            // Create a CourseViewModel instance to pass data to the view
            var viewModel = new CourseViewModel
            {
                Question = question,
                SolutionsList = question.Solutions.ToList() // List of associated solutions
            };

            return View(viewModel); // Pass the view model to the view
        }

        #region API CALLS
        public IActionResult GetAll()
        {
            try
            {
                var userName = User.Identity.Name;

                // Retrieve only the questions authored by the logged-in user
                var questions = _db.Questions
                    .Where(q => q.Author == userName)
                    .Select(q => new
                    {
                        q.QId,
                        q.QName,
                        q.CreatedDate,
                        q.ModifiedDate
                    })
                    .ToList();

                return Json(new { data = questions }); // Return the data as JSON
            }
            catch (Exception ex)
            {
                // Log the exception (implement your logging mechanism)
                return StatusCode(500, new { error = "An error occurred while fetching questions." });
            }
        }

        public IActionResult GetAllSolutions()
        {
            try
            {
                var userName = User.Identity.Name;

                // Get only the solutions authored by the logged-in user, including related questions
                var solutions = _db.Solutions
                    .Include(s => s.Question) // Include related questions
                    .Where(s => s.SAuthor == userName)
                    .Select(s => new
                    {
                        s.SId,
                        s.CreatedDate,
                        QuestionTitle = s.Question.QName, // The title of the associated question
                        QuestionId = s.Question.QId // The ID of the associated question
                    })
                    .ToList();

                return Json(new { data = solutions }); // Return the data as JSON
            }
            catch (Exception ex)
            {
                // Log the exception (implement your logging mechanism)
                return StatusCode(500, new { error = "An error occurred while fetching solutions." });
            }
        }
        #endregion
    }
}


































//using DSTutorials1909.Data;
//using DSTutorials1909.Models;
//using DSTutorials1909.ViewModel;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;

//namespace DSTutorials1909.Controllers
//{
//    [Authorize(Roles = "Admin,User")]
//    public class QuestionController : Controller
//    {
//        private readonly ApplicationDbContext _db;
//        public QuestionController(ApplicationDbContext db)
//        {
//            _db = db;
//        }

//        //public IActionResult Index()
//        //{
//        //    var data = _db.Questions.ToList();
//        //    return View(data);
//        //}


//        public IActionResult TipsQuestion()
//        {
//            return View();
//        }

//        public IActionResult TipsAnswer()
//        {
//            return View();
//        }

//        public IActionResult Index()
//        {
//            // Get the logged-in user's name
//            var userName = User.Identity.Name;

//            // Filter questions by the logged-in user
//            var data = _db.Questions
//                .Where(q => q.Author == userName) // Only get questions authored by the logged-in user
//                .ToList();

//            return View(data);
//        }


//        public IActionResult Create()
//        {
//            return View();
//        }

//        [HttpPost]
//        public IActionResult Create(Question que)
//        {
//            que.Author = User.Identity.Name; // Get the logged-in user's name
//            que.CreatedDate = DateTime.Now;  // Set current date/time
//            que.QUrl = que.QName.Replace(" ", "-");
//            que.ModifiedDate = que.CreatedDate;
//            _db.Questions.Add(que);
//            _db.SaveChanges();
//            return RedirectToAction("Index");
//        }

//        public IActionResult Edit(int qid)
//        {
//            var data = _db.Questions.FirstOrDefault(i => i.QId == qid);
//            return View(data);
//        }

//        [HttpPost]
//        public IActionResult Edit(Question que)
//        {
//            que.ModifiedDate = DateTime.Now;
//            que.QUrl = que.QName.Replace(" ", "-");
//            _db.Questions.Update(que);
//            _db.SaveChanges();
//            return RedirectToAction("Index");
//        }

//        public IActionResult Delete(int qid)
//        {
//            var data = _db.Questions.FirstOrDefault(i => i.QId == qid);
//            return View(data);
//        }

//        [HttpPost]
//        public IActionResult Delete(Question que)
//        {
//            var solutions = _db.Solutions.Where(s => s.QId == que.QId).ToList();
//            _db.Solutions.RemoveRange(solutions); // Delete related solutions
//            _db.Questions.Remove(que);
//            _db.SaveChanges();
//            return RedirectToAction("Index");
//        }

//        // Solutions

//        public IActionResult CreateSolution(int qid)
//        {
//            var question = _db.Questions.FirstOrDefault(q => q.QId == qid);
//            ViewBag.Question = question;

//            return View();
//        }

//        [HttpPost]
//        public IActionResult CreateSolution(Solution sol)
//        {
//            sol.SAuthor = User.Identity.Name; // Get logged-in user's name
//            sol.CreatedDate = DateTime.Now;
//            sol.ModifiedDate = sol.CreatedDate;
//            _db.Solutions.Add(sol);
//            _db.SaveChanges();
//            return RedirectToAction("Details", new { qid = sol.QId });
//        }

//        public IActionResult EditSolution(int sid)
//        {
//            var solution = _db.Solutions.FirstOrDefault(s => s.SId == sid);
//            var question = _db.Questions.FirstOrDefault(q => q.QId == solution.QId);
//            ViewBag.Question = question;
//            return View(solution);
//        }

//        [HttpPost]
//        public IActionResult EditSolution(Solution sol)
//        {
//            sol.ModifiedDate = DateTime.Now;
//            _db.Solutions.Update(sol);
//            _db.SaveChanges();
//            return RedirectToAction("ViewSolutions", new { qid = sol.QId });
//        }

//        public IActionResult DeleteSolution(int sid)
//        {
//            var solution = _db.Solutions.FirstOrDefault(s => s.SId == sid);
//            return View(solution);
//        }

//        [HttpPost]
//        public IActionResult DeleteSolution(Solution sol)
//        {
//            _db.Solutions.Remove(sol);
//            _db.SaveChanges();
//            return RedirectToAction("ViewSolutions", new { qid = sol.QId });
//        }

//        //public IActionResult ViewSolutions()
//        //{
//        //    CourseViewModel vm= new CourseViewModel()
//        //    {
//        //        QuestionList = _db.Questions.ToList(),
//        //        SolutionsList = _db.Solutions.ToList(),

//        //    };  
//        //    return View(vm);
//        //}

//        public IActionResult ViewSolutions()
//        {
//            // Get the logged-in user's name
//            var userName = User.Identity.Name;

//            // Retrieve questions and solutions authored by the logged-in user
//            var vm = new CourseViewModel()
//            {
//                // Get only the questions authored by the logged-in user
//                QuestionList = _db.Questions
//                    .Where(q => q.Author == userName)
//                    .ToList(),

//                // Get only the solutions authored by the logged-in user, including related questions
//                SolutionsList = _db.Solutions
//                    .Include(s => s.Question) // Include related questions
//                    .Where(s => s.SAuthor == userName)
//                    .ToList()
//            };

//            return View(vm);
//        }




//        public IActionResult Details(int qid)
//        {
//            // Get the question with its associated solutions
//            var question = _db.Questions
//                .Include(q => q.Solutions) // Include related solutions
//                .FirstOrDefault(q => q.QId == qid);

//            // Check if question is found
//            if (question == null)
//            {
//                return NotFound(); // Handle the case when question is not found
//            }

//            // Create a CourseViewModel instance to pass data to the view
//            var viewModel = new CourseViewModel
//            {
//                Question = question,
//                SolutionsList = question.Solutions.ToList() // List of associated solutions
//            };

//            return View(viewModel); // Pass the view model to the view
//        }

//        #region API CALLS
//        public IActionResult GetAll()
//        {
//            var questions = _db.Questions.ToList();
//            return Json(new { data = questions });
//        }

//        public IActionResult GetAllSolutions()
//        {
//            try
//            {
//                var userName = User.Identity.Name;

//                // Get only the solutions authored by the logged-in user, including related questions
//                var solutions = _db.Solutions
//                    .Include(s => s.Question) // Include related questions
//                    .Where(s => s.SAuthor == userName)
//                    .Select(s => new
//                    {
//                        s.SId,
//                        s.CreatedDate,
//                        QuestionTitle = s.Question.QName, // The title of the associated question
//                        QuestionId = s.Question.QId // The ID of the associated question
//                    })
//                    .ToList();

//                return Json(new { data = solutions }); // Return the data as JSON
//            }
//            catch (Exception ex)
//            {
//                // Log the exception (implement your logging mechanism)
//                return StatusCode(500, new { error = "An error occurred while fetching solutions." });
//            }
//        }




//        #endregion

//    }
//}






































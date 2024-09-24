using DSTutorials1909.Data;
using DSTutorials1909.Models;
using DSTutorials1909.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DSTutorials1909.Controllers
{
    public class CourseController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CourseController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var course = _db.Courses.ToList();
            return View(course);
        }


        public IActionResult Create()
        {
            CourseViewModel courseViewModel = new CourseViewModel()
            {
                Courses = new Courses()
            };

            return View(courseViewModel);
        }
        [HttpPost]
        public IActionResult Create(CourseViewModel course, IFormFile CourseImage)
        {
            if (CourseImage != null && CourseImage.Length > 0)
            {
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(CourseImage.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/", fileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    CourseImage.CopyTo(stream);
                }

                course.Courses.CourseImage = "/images/" + fileName;
            }

            _db.Courses.Add(course.Courses);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var course = _db.Courses.Find(id);

            CourseViewModel cr = new CourseViewModel()
            {
                Courses = course
            };
            return View(cr);
        }
        [HttpPost]
        public IActionResult Edit(CourseViewModel course, IFormFile CourseImage)
        {
            var cr = _db.Courses.AsNoTracking().FirstOrDefault(i => i.CoursesId == course.Courses.CoursesId);

            if (CourseImage != null && CourseImage.Length > 0)
            {
                if (!string.IsNullOrEmpty(cr.CourseImage))
                {
                    var oldPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/", Path.GetFileName(cr.CourseImage));
                    if (System.IO.File.Exists(oldPath))
                    {
                        System.IO.File.Delete(oldPath);
                    }
                }
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(CourseImage.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/", fileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    CourseImage.CopyTo(stream);
                }

                course.Courses.CourseImage = "/images/" + fileName;
            }
            else
            {
                course.Courses.CourseImage = cr.CourseImage;

            }

            _db.Courses.Update(course.Courses);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }


        public IActionResult Delete(int id)
        {
            var course = _db.Courses.Find(id);

            CourseViewModel cr = new CourseViewModel()
            {
                Courses = course
            };
            return View(cr);

        }

        [HttpPost]
        public IActionResult Delete(CourseViewModel course, IFormFile CourseImage)
        {
            var cr = _db.Courses.AsNoTracking().FirstOrDefault(i => i.CoursesId == course.Courses.CoursesId);
            if (!string.IsNullOrEmpty(cr.CourseImage))
            {
                var oldPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/", Path.GetFileName(cr.CourseImage));
                if (System.IO.File.Exists(oldPath))
                {
                    System.IO.File.Delete(oldPath);
                }
            }

            _db.Courses.Remove(course.Courses);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }


        #region API CALLS
        public IActionResult GetAll()
        {
            var coursse = _db.Courses.ToList();
            return Json(new { data = coursse });
        }
        #endregion



    }
}

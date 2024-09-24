using DSTutorials1909.Data;
using DSTutorials1909.Models;
using DSTutorials1909.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DSTutorials1909.Controllers
{
    public class MenuController : Controller
    {
        private readonly ApplicationDbContext _db;
        public MenuController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var data=_db.Menus.Include(i=>i.Courses).ToList();
            return View(data);
        }

        public IActionResult Create()
        {
            CourseViewModel courseViewModel = new CourseViewModel()
            {
                Menu = new Menu(),
                CourseList = _db.Courses.ToList()
            };
            return View(courseViewModel);
        }

        [HttpPost]
        public IActionResult Create(CourseViewModel cm)
        {
            _db.Menus.Add(cm.Menu);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var menu = _db.Menus.Include(i => i.Courses).FirstOrDefault(u => u.MenuId == id);
            CourseViewModel courseViewModel = new CourseViewModel()
            {
                Menu = menu,
                CourseList = _db.Courses.ToList()
            };
            return View(courseViewModel);
        }

        [HttpPost]
        public IActionResult Edit(CourseViewModel cm)
        {
            _db.Menus.Update(cm.Menu);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var menu = _db.Menus.Include(i => i.Courses).FirstOrDefault(u => u.MenuId == id);
            CourseViewModel courseViewModel = new CourseViewModel()
            {
                Menu = menu,
                CourseList = _db.Courses.ToList()
            };
            return View(courseViewModel);
        }

        [HttpPost]
        public IActionResult Delete(CourseViewModel cm)
        {
            _db.Menus.Remove(cm.Menu);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }




        #region API CALLS
        public IActionResult GetAll()
        {
            var menu = _db.Menus.Include(i=>i.Courses).ToList();
            return Json(new { data = menu });
        }
        #endregion

    }
}

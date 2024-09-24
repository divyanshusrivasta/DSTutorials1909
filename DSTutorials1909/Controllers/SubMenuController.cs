using DSTutorials1909.Data;
using DSTutorials1909.Models;
using DSTutorials1909.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DSTutorials1909.Controllers
{
    public class SubMenuController : Controller
    {
        private readonly ApplicationDbContext _db;
        public SubMenuController(ApplicationDbContext db)
        {
            _db = db;   
        }
        public IActionResult Index()
        {
            var data=_db.SubMenus.Include(i=>i.Courses).Include(o=>o.Menu).ToList();
            return View(data);
        }

        public IActionResult MenuShow(int Mid)
        {
            var data = _db.Menus.Where(i => i.CourseId == Mid).ToList();
            return Json(data);
        }

        public IActionResult Create()
        {
            CourseViewModel model = new CourseViewModel()
            { 
                SubMenu=new SubMenu(),
                CourseList=_db.Courses.ToList(),
                MenuList=_db.Menus.ToList(),

            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(CourseViewModel course)
        {
            _db.SubMenus.Add(course.SubMenu);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }



        public IActionResult Edit(int id)
        {
            var data = _db.SubMenus.Include(i => i.Courses).Include(o => o.Menu).FirstOrDefault(r=>r.SubMenuId==id);
            CourseViewModel model = new CourseViewModel()
            {
                SubMenu = data,
                CourseList = _db.Courses.ToList(),
                MenuList = _db.Menus.ToList(),

            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(CourseViewModel course)
        {
            _db.SubMenus.Update(course.SubMenu);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }


        public IActionResult Delete(int id)
        {
            var data = _db.SubMenus.Include(i => i.Courses).Include(o => o.Menu).FirstOrDefault(r => r.SubMenuId == id);
            CourseViewModel model = new CourseViewModel()
            {
                SubMenu = data,
                CourseList = _db.Courses.ToList(),
                MenuList = _db.Menus.ToList(),

            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(CourseViewModel course)
        {
            _db.SubMenus.Remove(course.SubMenu);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }


        #region API CALLS
        public IActionResult GetAll()
        {
            var subMenu = _db.SubMenus.Include(i => i.Courses).Include(o=>o.Menu).ToList();
            return Json(new { data = subMenu });
        }
        #endregion

    }
}

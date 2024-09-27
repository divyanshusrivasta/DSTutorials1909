using DSTutorials1909.Data;
using DSTutorials1909.Models;
using DSTutorials1909.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DSTutorials1909.Controllers
{
    public class ContentController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ContentController(ApplicationDbContext db)
        {
            _db = db;   
            
        }
        public IActionResult Index()
        {
            var data = _db.Contents.Include(i => i.Courses).Include(u => u.Menu).Include(m => m.SubMenu).ToList();
            return View(data);
        }

<<<<<<< HEAD
        [HttpGet]
        public string SideSubMenuUrl(int sideSubMenuId)
        {
            return _db.SubMenus.FirstOrDefault(i=>i.SubMenuId==sideSubMenuId).SubMenuUrl;
        }
=======
>>>>>>> 03c1add88b450c3c8e635227f66386f4516beae6


        public IActionResult MenuShow(int Mid)
        {
            var data = _db.Menus.Where(i => i.CourseId == Mid).ToList();
            return Json(data);
        }


        public IActionResult SubMenuShow(int Sid)
        {
            var data = _db.SubMenus.Where(i => i.MenuId == Sid).ToList();
            return Json(data);
        }

        public IActionResult Create()
        {
            CourseViewModel viewModel = new CourseViewModel()
            { 
                Content=new Content(),
                CourseList=_db.Courses.ToList(),
                MenuList=_db.Menus.ToList(),
                SubMenuList=_db.SubMenus.ToList()
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Create(CourseViewModel cm)
        {
            _db.Contents.Add(cm.Content);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            var data = _db.Contents.Include(i => i.Courses).Include(u => u.Menu).Include(m => m.SubMenu).FirstOrDefault(a=>a.ContentId==id);

            CourseViewModel viewModel = new CourseViewModel()
            {
                Content = data,
                CourseList = _db.Courses.ToList(),
                MenuList = _db.Menus.ToList(),
                SubMenuList = _db.SubMenus.ToList()
            };
            return View(viewModel);
        }



        public IActionResult Edit(int id)
        {
            var data = _db.Contents.Include(i => i.Courses).Include(u => u.Menu).Include(m => m.SubMenu).FirstOrDefault(a => a.ContentId == id);

            CourseViewModel viewModel = new CourseViewModel()
            {
                Content = data,
                CourseList = _db.Courses.ToList(),
                MenuList = _db.Menus.ToList(),
                SubMenuList = _db.SubMenus.ToList()
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(CourseViewModel cm)
        {
            _db.Contents.Update(cm.Content);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }



        public IActionResult Delete(int id)
        {
            var data = _db.Contents.Include(i => i.Courses).Include(u => u.Menu).Include(m => m.SubMenu).FirstOrDefault(a => a.ContentId == id);

            CourseViewModel viewModel = new CourseViewModel()
            {
                Content = data,
                CourseList = _db.Courses.ToList(),
                MenuList = _db.Menus.ToList(),
                SubMenuList = _db.SubMenus.ToList()
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Delete(CourseViewModel cm)
        {
            _db.Contents.Remove(cm.Content);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }


        public IActionResult Contact()
        {
            return View();
        }














        #region API CALLS
        public IActionResult GetAll()
        {
            var content = _db.Contents.Include(i => i.Courses).Include(u => u.Menu).Include(m => m.SubMenu).ToList();
            return Json(new { data = content });
        }
        #endregion
    }
}

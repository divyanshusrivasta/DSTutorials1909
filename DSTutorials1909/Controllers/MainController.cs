using DSTutorials1909.Data;
using DSTutorials1909.Models;
using DSTutorials1909.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DSTutorials1909.Controllers
{
    public class MainController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MainController(ApplicationDbContext context)
        {
            _context = context;
        }



        public IActionResult CourseDetails(string menuUrl, string subMenuUrl)
        {
            var viewModel = new CourseViewModel();

            // Fetch the selected course by menuUrl
            var selectedCourse = _context.Courses.FirstOrDefault(c => c.MenuUrl == menuUrl);
            if (selectedCourse == null)
            {
                return NotFound("Course not found");
            }

            viewModel.Courses = selectedCourse;

            // Fetch all menus for the selected course
            viewModel.MenuList = _context.Menus
                                         .Where(m => m.CourseId == selectedCourse.CoursesId)
                                         .OrderBy(m => m.MenuSequence)
                                         .ToList();
            if (!viewModel.MenuList.Any())
            {
                return NotFound("No menus found for this course");
            }

            // Fetch all submenus for the selected course
            viewModel.SubMenuList = _context.SubMenus
                                            .Where(sm => sm.CourseId == selectedCourse.CoursesId)
                                            .OrderBy(sm => sm.SubMenuSequence)
                                            .ToList();

            if (!viewModel.SubMenuList.Any())
            {
                viewModel.SubMenuList = new List<SubMenu>();
            }

            // Check if a submenu is selected using subMenuUrl
            if (!string.IsNullOrEmpty(subMenuUrl))
            {
                // Find the selected submenu by its URL
                viewModel.SubMenu = _context.SubMenus
                                            .FirstOrDefault(sm => sm.SubMenuUrl == subMenuUrl && sm.CourseId == selectedCourse.CoursesId);

                if (viewModel.SubMenu != null)
                {
                    // Fetch the content for the selected submenu
                    viewModel.ContentList = _context.Contents
                                                    .Where(c => c.SubMenuId == viewModel.SubMenu.SubMenuId)
                                                    .ToList();
                }
            }
            else
            {
                // If no submenu is selected, select the first submenu by default
                var firstSubMenu = viewModel.SubMenuList.FirstOrDefault();
                if (firstSubMenu != null)
                {
                    viewModel.SubMenu = firstSubMenu;
                    viewModel.ContentList = _context.Contents
                                                    .Where(c => c.SubMenuId == firstSubMenu.SubMenuId)
                                                    .ToList();
                }
            }

            // Set Previous and Next URLs
            var subMenus = viewModel.SubMenuList.ToList();
            int currentIndex = subMenus.FindIndex(sm => sm.SubMenuId == viewModel.SubMenu?.SubMenuId);

            if (currentIndex > 0)
            {
                viewModel.PrevUrl = subMenus[currentIndex - 1].SubMenuUrl; // Get previous submenu URL
            }
            if (currentIndex < subMenus.Count - 1)
            {
                viewModel.NextUrl = subMenus[currentIndex + 1].SubMenuUrl; // Get next submenu URL
            }

            return View("CourseDetails", viewModel);
        }













        //public IActionResult CourseDetails(string menuUrl, string subMenuUrl)
        //{
        //    var viewModel = new CourseViewModel();

        //    // Fetch the selected course by menuUrl
        //    var selectedCourse = _context.Courses.FirstOrDefault(c => c.MenuUrl == menuUrl);

        //    if (selectedCourse == null)
        //    {
        //        return NotFound("Course not found");
        //    }

        //    viewModel.Courses = selectedCourse;

        //    // Set the selected course name for highlighting in the navbar
        //    ViewBag.SelectedCourse = selectedCourse.CourseName;

        //    // Fetch all menus for the selected course
        //    viewModel.MenuList = _context.Menus
        //                                 .Where(m => m.CourseId == selectedCourse.CoursesId)
        //                                 .OrderBy(m => m.MenuSequence)
        //                                 .ToList();

        //    if (!viewModel.MenuList.Any())
        //    {
        //        return NotFound("No menus found for this course");
        //    }

        //    // Fetch all submenus for the selected course
        //    viewModel.SubMenuList = _context.SubMenus
        //                                    .Where(sm => sm.CourseId == selectedCourse.CoursesId)
        //                                    .OrderBy(sm => sm.SubMenuSequence)
        //                                    .ToList();

        //    if (!viewModel.SubMenuList.Any())
        //    {
        //        viewModel.SubMenuList = new List<SubMenu>();
        //    }

        //    // Check if a submenu is selected using subMenuUrl
        //    if (!string.IsNullOrEmpty(subMenuUrl))
        //    {
        //        // Find the selected submenu by its URL
        //        viewModel.SubMenu = _context.SubMenus
        //                                    .FirstOrDefault(sm => sm.SubMenuUrl == subMenuUrl && sm.CourseId == selectedCourse.CoursesId);

        //        if (viewModel.SubMenu != null)
        //        {
        //            // Fetch the content for the selected submenu
        //            viewModel.ContentList = _context.Contents
        //                                            .Where(c => c.SubMenuId == viewModel.SubMenu.SubMenuId)
        //                                            .ToList();
        //        }
        //    }
        //    else
        //    {
        //        // If no submenu is selected, select the first submenu by default
        //        var firstSubMenu = viewModel.SubMenuList.FirstOrDefault();
        //        if (firstSubMenu != null)
        //        {
        //            viewModel.SubMenu = firstSubMenu;
        //            viewModel.ContentList = _context.Contents
        //                                            .Where(c => c.SubMenuId == firstSubMenu.SubMenuId)
        //                                            .ToList();
        //        }
        //    }

        //    return View("CourseDetails", viewModel);
        //}

        public IActionResult Index()
        {
            return View();
        }
    }
}

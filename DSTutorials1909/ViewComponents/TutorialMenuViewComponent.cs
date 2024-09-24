using DSTutorials1909.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DSTutorials1909.ViewComponents
{
    public class TutorialMenuViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public TutorialMenuViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var courses = await _context.Courses.ToListAsync(); // Make sure you are returning CourseNaming model
            return View(courses);
        }
    }
}

using DSTutorials1909.Models;

namespace DSTutorials1909.ViewModel
{
    public class CourseViewModel
    {
        public Courses Courses { get; set; }
        public Menu Menu { get; set; }
        public IFormFile CourseImage { get; set; }
        public IEnumerable<Courses> CourseList { get; set; }

        public SubMenu SubMenu { get; set; }
        public IEnumerable<Menu> MenuList { get; set; }
        public IEnumerable<SubMenu> SubMenuList { get; set; }
        public Content Content { get; set; }
        public IEnumerable<Content> ContentList { get; set; }
<<<<<<< HEAD
        public SubMenu PreviousSubMenu { get; set; }
        public SubMenu NextSubMenu { get; set; }
        public string? PrevUrl { get; set; }
        public string? NextUrl { get; set; }
=======

>>>>>>> 03c1add88b450c3c8e635227f66386f4516beae6

    }
}

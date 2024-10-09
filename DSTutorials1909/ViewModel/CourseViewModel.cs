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
        public SubMenu PreviousSubMenu { get; set; }
        public SubMenu NextSubMenu { get; set; }
        public string? PrevUrl { get; set; }
        public string? NextUrl { get; set; }
        public List<SubMenu> PreviousSubMenus { get; set; }
        public List<SubMenu> NextSubMenus { get; set; }


        public Question Question { get; set; }
        public List<Question> QuestionList { get; set; }


        public Solution Solution { get; set; }
        public List<Solution> SolutionsList { get; set; }

    }
}

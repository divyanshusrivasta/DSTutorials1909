using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DSTutorials1909.Models
{
    public class SubMenu
    {
        [Key]
        public int SubMenuId { get; set; }
        public string SubMenuName { get; set; }
        public int SubMenuSequence { get; set; }
        [ForeignKey("Courses")]
        public int CourseId { get; set; }
        public Courses Courses { get; set; }
        [ForeignKey("Menu")]
        public int MenuId { get; set; }
        public Menu Menu { get; set; }
        public string SubMenuUrl { get; set; }


    }
}

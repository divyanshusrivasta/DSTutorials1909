using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DSTutorials1909.Models
{
    public class Content
    {
        [Key]
        public int ContentId { get; set; }
        public string ContentDetail { get; set; }
        [ForeignKey("Courses")]
        public int CourseId { get; set; }
        public Courses Courses { get; set; }
        [ForeignKey("Menu")]
        public int MenuId { get; set; }
        public Menu Menu { get; set; }
        [ForeignKey("SubMenu")]
        public int SubMenuId { get; set; }
        public SubMenu SubMenu { get; set; }


    }
}

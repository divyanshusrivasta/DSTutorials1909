using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DSTutorials1909.Models
{
    public class Menu
    {
        [Key]
        public int MenuId { get; set; }
        public string MenuName { get; set; }

        
        public int CourseId { get; set; }
        [ForeignKey("CourseId")]
        public Courses Courses { get; set; }
        public int MenuSequence { get; set; }
    }
}

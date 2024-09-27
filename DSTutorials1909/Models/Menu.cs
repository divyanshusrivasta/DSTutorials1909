using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DSTutorials1909.Models
{
    public class Menu
    {
        [Key]
        public int MenuId { get; set; }
        public string MenuName { get; set; }
<<<<<<< HEAD

        
=======
       
>>>>>>> 03c1add88b450c3c8e635227f66386f4516beae6
        public int CourseId { get; set; }
        [ForeignKey("CourseId")]
        public Courses Courses { get; set; }
        public int MenuSequence { get; set; }
    }
}

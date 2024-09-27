using System.ComponentModel.DataAnnotations;

namespace DSTutorials1909.Models
{
    public class Courses
    {
        [Key]

        public int CoursesId { get; set; }
        public string CourseName { get; set; }
<<<<<<< HEAD
        public string? MenuUrl { get; set; }
=======
>>>>>>> 03c1add88b450c3c8e635227f66386f4516beae6
        public string CourseDetails { get; set; }
        public string CourseImage { get; set; }
        public int CourseSequence { get; set; }


    }
}

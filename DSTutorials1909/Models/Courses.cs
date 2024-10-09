using System.ComponentModel.DataAnnotations;

namespace DSTutorials1909.Models
{
    public class Courses
    {
        [Key]
        public int CoursesId { get; set; }

        public string CourseName { get; set; }

        public string? MenuUrl { get; set; }  // Ensure this is included from the HEAD branch

        public string CourseDetails { get; set; }

        public string CourseImage { get; set; }

        public int CourseSequence { get; set; }
    }
}

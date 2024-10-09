using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DSTutorials1909.Models
{
    public class Question
    {
        [Key]
        public int QId { get; set; }
        [DisplayName("Question")]
        [Required(ErrorMessage = "Question is required.")]
        [StringLength(100, ErrorMessage = "Question cannot be longer than 100 characters.")]
        public string QName { get; set; }
        [DisplayName("Description")]
        [Required(ErrorMessage = "Description is required.")]
        [StringLength(500, ErrorMessage = "Description cannot be longer than 500 characters.")]

        public string QDescription { get; set; }
        public string? QUrl { get; set; }
        public string? Author { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public List<Solution>? Solutions { get; set; }  // This allows EF to know there are solutions linked to this question

    }
}

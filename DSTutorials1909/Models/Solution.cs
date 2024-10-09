using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DSTutorials1909.Models
{
    public class Solution
    {
        [Key]
        public int SId { get; set; }
        [DisplayName("Answer")]
        public string SName { get; set; }

        // Foreign key for Question
        [ForeignKey("Question")]
        public int QId { get; set; } // Keep this as is

        // Navigation property
        public virtual Question Question { get; set; }

        public string SAuthor { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}

<<<<<<< HEAD
﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
=======
﻿using System.ComponentModel.DataAnnotations;
>>>>>>> 03c1add88b450c3c8e635227f66386f4516beae6
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
<<<<<<< HEAD
        [DisplayName("Content Url")]

        public string SideSubMenuUrl { get; set; }
=======
>>>>>>> 03c1add88b450c3c8e635227f66386f4516beae6


    }
}

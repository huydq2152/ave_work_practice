using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Mike.Models.Common;

namespace Mike.Models.Entities
{
    [Table("Homework10_Announcement")]
    public class Announcement : EntityBase
    {
        public string Content { get; set; }

        [Required]
        public string Category { get; set; }

        public string Image { get; set; }

        [Required]
        public DateTime CreationTime { get; set; }
    }
}

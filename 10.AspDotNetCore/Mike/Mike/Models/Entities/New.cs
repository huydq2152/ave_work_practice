using System;
using System.ComponentModel.DataAnnotations.Schema;
using Mike.Models.Common;

namespace Mike.Models.Entities
{
    [Table("Homework10_New")]
    public class New: EntityBase
    {
        public string Content { get; set; }

        public string Image { get; set; }

        public DateTime CreationTime { get; set; }
    }
}

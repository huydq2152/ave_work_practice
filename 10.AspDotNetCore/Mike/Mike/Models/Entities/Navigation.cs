using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Mike.Models.Common;

namespace Mike.Models.Entities
{
    [Table("Homework10_Navigation")]
    public class Navigation : EntityBase
    {
        [Required]
        public string Slug { get; set; }

        [Required]
        public string Url { get; set; }
        
    }
}

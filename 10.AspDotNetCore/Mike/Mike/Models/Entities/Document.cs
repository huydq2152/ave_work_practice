using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Mike.Models.Common;

namespace Mike.Models.Entities
{
    [Table("Homework10_Document")]
    public class Document : EntityBase
    {
        public string Image { get; set; }

        [Required]
        public string FileUrl { get; set; }

        public int DocumentCategoryId { get; set; }

        [ForeignKey("DocumentCategoryId")]
        public virtual DocumentCategory DocumentCategory{ get; set; }
    }
}

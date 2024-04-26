using System.ComponentModel.DataAnnotations.Schema;
using Mike.Models.Common;

namespace Mike.Models.Entities
{
    [Table("Homework10_ImageGallery")]
    public class ImageGallery : EntityBase
    {
        public string Image { get; set; }
    }
}

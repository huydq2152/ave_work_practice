using System.ComponentModel.DataAnnotations.Schema;
using Mike.Models.Common;

namespace Mike.Models.Entities
{
    [Table("Homework10_VideoGallery")]
    public class VideoGallery : EntityBase
    {
        public string Video { get; set; }
    }
}

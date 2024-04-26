using Mike.Models.Common.Dtos;
using System.ComponentModel.DataAnnotations;
using System;

namespace Mike.Application.Share.Dtos.Announcement
{
    public class AnnouncementDto : DtoBase
    {
        public string Content { get; set; }
        
        public string Category { get; set; }

        public string Image { get; set; }
        
        public DateTime CreationTime { get; set; }
    }
}

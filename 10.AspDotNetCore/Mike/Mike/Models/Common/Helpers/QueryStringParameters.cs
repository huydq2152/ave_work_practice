using Microsoft.AspNetCore.Http;

namespace Mike.Models.Common.Helpers
{
    public class AnnouncementParameters
    {
        public int PageNumber { get; set; } = 1;

        public int PageSize { get; set; } = 4;
    }

    public class NewParameters
    {
        public int PageNumber { get; set; } = 1;

        public int PageSize { get; set; } = 4;
    }

    public class ImageGalleryParameters
    {
        public int PageNumber { get; set; } = 1;

        public int PageSize { get; set; } = 4;
    }

    public class VideoGalleryParameters
    {
        public int PageNumber { get; set; } = 1;

        public int PageSize { get; set; } = 4;
    }

    public class DocumentParameters
    {
        public int? DocumentCategoryId { get; set; }
        public int PageNumber { get; set; } = 1;

        public int PageSize { get; set; } = 4;
    }

    public class EventParameters
    {
        public int PageNumber { get; set; } = 1;

        public int PageSize { get; set; } = 4;
    }

    public class HowParameters
    {
        public string Filter { get; set; }
        public int PageNumber { get; set; } = 1;

        public int PageSize { get; set; } = 4;
    }

    public class FileUploadRequest
    {
        public string FileName { get; set;}

        public IFormFile File { get; set; }
    }
}

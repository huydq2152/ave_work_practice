using Mike.Models.Common.Dtos;

namespace Mike.Application.Share.Dtos.VideoGallery
{
    public class CreateOrEditVideoGalleryDto : CreateOrEditDtoBase
    {
        public string Video { get; set; }
    }
}

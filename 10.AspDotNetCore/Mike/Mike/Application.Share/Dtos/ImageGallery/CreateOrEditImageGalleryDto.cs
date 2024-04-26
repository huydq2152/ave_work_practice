using Mike.Models.Common.Dtos;

namespace Mike.Application.Share.Dtos.ImageGallery
{
    public class CreateOrEditImageGalleryDto : CreateOrEditDtoBase
    {
        public string Image { get; set; }
    }
}

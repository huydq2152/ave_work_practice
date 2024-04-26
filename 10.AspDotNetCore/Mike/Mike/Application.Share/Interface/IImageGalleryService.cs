using Mike.Application.Share.Dtos.ImageGallery;
using Mike.Models.Common.Helpers;
using Mike.Models.Entities;
using System.Threading.Tasks;

namespace Mike.Application.Share.Interface
{
    public interface IImageGalleryService
    {
        Task<PagedList<ImageGalleryDto>> GetPagedImageGallery(ImageGalleryParameters imageGalleryParameters);

        public Task<ImageGalleryDto> GetImageGalleryById(int id);

        Task<ImageGallery> CreateOrEdit(CreateOrEditImageGalleryDto input);

        public Task<ImageGallery> Delete(int id);
    }
}

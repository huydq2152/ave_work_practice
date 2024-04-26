using Mike.Application.Share.Dtos.VideoGallery;
using Mike.Models.Common.Helpers;
using Mike.Models.Entities;
using System.Threading.Tasks;

namespace Mike.Application.Share.Interface
{
    public interface IVideoGalleryService
    {
        Task<PagedList<VideoGalleryDto>> GetPagedVideoGallery(VideoGalleryParameters videoGalleryParameters);

        public Task<VideoGalleryDto> GetVideoGalleryById(int id);

        Task<VideoGallery> CreateOrEdit(CreateOrEditVideoGalleryDto input);

        public Task<VideoGallery> Delete(int id);
    }
}

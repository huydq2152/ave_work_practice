using Mike.Application.Share.Dtos.Announcement;
using System.Threading.Tasks;
using Mike.Models.Common.Helpers;
using Mike.Models.Entities;

namespace Mike.Application.Share.Interface
{
    public interface IAnnouncementService
    {
        Task<PagedList<AnnouncementDto>> GetPagedAnnouncement(AnnouncementParameters announcementParameters);

        public Task<AnnouncementDto> GetAnnouncementById(int id);

        Task<Announcement> CreateOrEdit(CreateOrEditAnnouncementDto input);

        public Task<Announcement> Delete(int id);
    }
}

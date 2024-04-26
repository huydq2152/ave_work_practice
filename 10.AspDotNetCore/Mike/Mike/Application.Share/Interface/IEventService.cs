using Mike.Application.Share.Dtos.Event;
using Mike.Models.Common.Helpers;
using Mike.Models.Entities;
using System.Threading.Tasks;

namespace Mike.Application.Share.Interface
{
    public interface IEventService
    {
        Task<PagedList<EventDto>> GetPagedEvent(EventParameters eventParameters);

        public Task<EventDto> GetEventById(int id);

        Task<Event> CreateOrEdit(CreateOrEditEventDto input);

        public Task<Event> Delete(int id);
    }
}

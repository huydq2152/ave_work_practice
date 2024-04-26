using AutoMapper;
using Mike.Application.Share.Dtos.Event;
using Mike.Application.Share.Interface;
using Mike.Models.Common.Helpers;
using Mike.Models.Common;
using Mike.Models.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Mike.Application.Services
{
    public class EventService : IEventService
    {
        private readonly IMapper _mapper;
        private readonly MikeDbContext _context;

        public EventService(IMapper mapper, MikeDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        private class QueryInput
        {
            public int? Id { get; set; }
        }
        private IQueryable<EventDto> EventQuery(QueryInput queryInput)
        {
            var id = queryInput.Id;

            var query = from obj in _context.Events
                    .Where(o => o.IsActive && (!id.HasValue || o.Id == id))
                    .OrderBy(o => o.Order)
                        select new EventDto
                        {
                            Id = obj.Id,
                            Name = obj.Name,
                            Start = obj.Start,
                            End = obj.End,
                            Day = obj.Day,
                            Month = obj.Month,
                            Order = obj.Order,
                            IsActive = obj.IsActive
                        };
            return query;
        }


        public Task<PagedList<EventDto>> GetPagedEvent(EventParameters eventParameters)
        {
            var queryInput = new QueryInput();
            return Task.FromResult(PagedList<EventDto>.ToPagedList(EventQuery(queryInput),
                eventParameters.PageNumber,
                eventParameters.PageSize));
        }

        public async Task<EventDto> GetEventById(int id)
        {
            var queryInput = new QueryInput()
            {
                Id = id
            };
            var objQuery = EventQuery(queryInput);

            var res = await objQuery.FirstOrDefaultAsync();
            return res;
        }

        public async Task<Event> CreateOrEdit(CreateOrEditEventDto input)
        {
            if (input.Id == null)
            {
                return await Create(input);
            }
            else
            {
                return await Update(input);
            }
        }

        private async Task<Event> Create(CreateOrEditEventDto input)
        {
            var obj = _mapper.Map<Event>(input);
            await _context.AddAsync(obj);
            await _context.SaveChangesAsync();
            return obj;
        }

        private async Task<Event> Update(CreateOrEditEventDto input)
        {
            var obj = await _context.Events.FirstOrDefaultAsync(o => o.Id == input.Id);
            if (obj == null) return null;

            _mapper.Map(input, obj);
            await _context.SaveChangesAsync();
            return obj;
        }

        public async Task<Event> Delete(int id)
        {
            var obj = await _context.Events.FirstOrDefaultAsync(o => o.Id == id);
            if (obj == null) return null;

            _context.Events.Remove(obj);
            await _context.SaveChangesAsync();
            return obj;
        }
    }
}

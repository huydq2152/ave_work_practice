using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Mike.Application.Share.Dtos.Announcement;
using Mike.Application.Share.Interface;
using Mike.Models.Common;
using Mike.Models.Common.Helpers;
using Mike.Models.Entities;

namespace Mike.Application.Services
{
    public class AnnouncementService : IAnnouncementService
    {
        private readonly IMapper _mapper;
        private readonly MikeDbContext _context;

        public AnnouncementService(IMapper mapper, MikeDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        private class QueryInput
        {
            public int? Id { get; set; }
        }
        private IQueryable<AnnouncementDto> AnnouncementQuery(QueryInput queryInput)
        {
            var id = queryInput.Id;

            var query = from obj in _context.Announcements
                    .Where(o => o.IsActive && (!id.HasValue || o.Id == id))
                    .OrderBy(o => o.Order)
                        select new AnnouncementDto
                        {
                            Id = obj.Id,
                            Name = obj.Name,
                            Category = obj.Category,
                            Content = obj.Content,
                            CreationTime = obj.CreationTime,
                            Image = obj.Image,
                            IsActive = obj.IsActive,
                            Order = obj.Order
                        };
            return query;
        }

        public Task<PagedList<AnnouncementDto>> GetPagedAnnouncement(AnnouncementParameters announcementParameters)
        {
            var queryInput = new QueryInput();
            return Task.FromResult(PagedList<AnnouncementDto>.ToPagedList(AnnouncementQuery(queryInput),
                announcementParameters.PageNumber,
                announcementParameters.PageSize));
        }

        public async Task<AnnouncementDto> GetAnnouncementById(int id)
        {
            var queryInput = new QueryInput()
            {
                Id = id
            };
            var objQuery = AnnouncementQuery(queryInput);

            var res = await objQuery.FirstOrDefaultAsync();
            return res;
        }

        public async Task<Announcement> CreateOrEdit(CreateOrEditAnnouncementDto input)
        {
            input.Image = $"{GlobalConfig.ImageFolderUrl}/{input.Image}";
            if (input.Id == null)
            {
                return await Create(input);
            }
            else
            {
                return await Update(input);
            }
        }

        private async Task<Announcement> Create(CreateOrEditAnnouncementDto input)
        {
            var obj = _mapper.Map<Announcement>(input);
            await _context.AddAsync(obj);
            await _context.SaveChangesAsync();
            return obj;
        }

        private async Task<Announcement> Update(CreateOrEditAnnouncementDto input)
        {
            var obj = await _context.Announcements.FirstOrDefaultAsync(o => o.Id == input.Id);
            if (obj == null) return null;

            _mapper.Map(input, obj);
            await _context.SaveChangesAsync();
            return obj;
        }

        public async Task<Announcement> Delete(int id)
        {
            var obj = await _context.Announcements.FirstOrDefaultAsync(o => o.Id == id);
            if (obj == null) return null;

            _context.Announcements.Remove(obj);
            await _context.SaveChangesAsync();
            return obj;
        }
    }
}

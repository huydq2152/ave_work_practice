using AutoMapper;
using Mike.Application.Share.Dtos.QuickLink;
using Mike.Application.Share.Interface;
using Mike.Models.Common;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Mike.Models.Entities;

namespace Mike.Application.Services
{
    public class QuickLinkService : IQuickLinkService
    {
        private readonly IMapper _mapper;
        private readonly MikeDbContext _context;

        public QuickLinkService(IMapper mapper, MikeDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        private class QueryInput
        {
            public int? Id { get; set; }
        }
        private IQueryable<QuickLinkDto> QuickLinkQuery(QueryInput queryInput)
        {
            var id = queryInput.Id;

            var query = from obj in _context.QuickLinks
                    .Where(o => o.IsActive && (!id.HasValue || o.Id == id))
                    .OrderBy(o => o.Order)
                        select new QuickLinkDto
                        {
                            Id = obj.Id,
                            Name = obj.Name,
                            Order = obj.Order,
                            IsActive = obj.IsActive,
                            Image = obj.Image,
                        };
            return query;
        }

        public async Task<List<QuickLinkDto>> GetAll()
        {
            var queryInput = new QueryInput();
            var objQuery = QuickLinkQuery(queryInput);

            var res = await objQuery.ToListAsync();
            return res;
        }

        public async Task<QuickLinkDto> GetQuickLinkById(int id)
        {
            var queryInput = new QueryInput()
            {
                Id = id
            };
            var objQuery = QuickLinkQuery(queryInput);

            var res = await objQuery.FirstOrDefaultAsync();
            return res;
        }

        public async Task<QuickLink> CreateOrEdit(CreateOrEditQuickLinkDto input)
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

        private async Task<QuickLink> Create(CreateOrEditQuickLinkDto input)
        {
            var obj = _mapper.Map<QuickLink>(input);
            await _context.AddAsync(obj);
            await _context.SaveChangesAsync();
            return obj;
        }

        private async Task<QuickLink> Update(CreateOrEditQuickLinkDto input)
        {
            var obj = await _context.QuickLinks.FirstOrDefaultAsync(o => o.Id == input.Id);
            if (obj == null) return null;

            _mapper.Map(input, obj);
            await _context.SaveChangesAsync();
            return obj;
        }

        public async Task<QuickLink> Delete(int id)
        {
            var obj = await _context.QuickLinks.FirstOrDefaultAsync(o => o.Id == id);
            if (obj == null) return null;

            _context.QuickLinks.Remove(obj);
            await _context.SaveChangesAsync();
            return obj;
        }
    }
}

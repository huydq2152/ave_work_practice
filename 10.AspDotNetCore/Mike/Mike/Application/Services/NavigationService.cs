using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Mike.Application.Share.Dtos.Navigation;
using Mike.Application.Share.Interface;
using Mike.Models.Common;
using Mike.Models.Entities;

namespace Mike.Application.Services
{
    public class NavigationService : INavigationService
    {
        private readonly IMapper _mapper;
        private readonly MikeDbContext _context;

        public NavigationService(IMapper mapper, MikeDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        private class QueryInput
        {
            public int? Id { get; set; }
        }
        private IQueryable<NavigationDto> NavigationQuery(QueryInput queryInput)
        {
            var id = queryInput.Id;

            var query = from obj in _context.Navigations
                    .Where(o => o.IsActive && (!id.HasValue || o.Id == id))
                    .OrderBy(o => o.Order)
                        select new NavigationDto
                        {
                            Id = obj.Id,
                            Name = obj.Name,
                            Slug = obj.Slug,
                            Url = obj.Url,
                            Order = obj.Order,
                            IsActive = obj.IsActive,
                        };
            return query;
        }

        public async Task<List<NavigationDto>> GetAll()
        {
            var queryInput = new QueryInput();
            var objQuery = NavigationQuery(queryInput);

            var res = await objQuery.ToListAsync();
            return res;
        }

        public async Task<NavigationDto> GetNavigationById(int id)
        {
            var queryInput = new QueryInput()
            {
                Id = id
            };
            var objQuery = NavigationQuery(queryInput);

            var res = await objQuery.FirstOrDefaultAsync();
            return res;
        }

        public async Task<Navigation> CreateOrEdit(CreateOrEditNavigationDto input)
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

        private async Task<Navigation> Create(CreateOrEditNavigationDto input)
        {
            var obj = _mapper.Map<Navigation>(input);
            await _context.AddAsync(obj);
            await _context.SaveChangesAsync();
            return obj;
        }

        private async Task<Navigation> Update(CreateOrEditNavigationDto input)
        {
            var obj = await _context.Navigations.FirstOrDefaultAsync(o => o.Id == input.Id);
            if (obj == null) return null;

            _mapper.Map(input, obj);
            await _context.SaveChangesAsync();
            return obj;
        }

        public async Task<Navigation> Delete(int id)
        {
            var obj = await _context.Navigations.FirstOrDefaultAsync(o => o.Id == id);
            if (obj == null) return null;

            _context.Navigations.Remove(obj);
            await _context.SaveChangesAsync();
            return obj;
        }
    }
}

using AutoMapper;
using Mike.Application.Share.Dtos.How;
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
    public class HowService: IHowService
    {
        private readonly IMapper _mapper;
        private readonly MikeDbContext _context;

        public HowService(IMapper mapper, MikeDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        private class QueryInput
        {
            public int? Id { get; set; }

            public string Filter { get; set; }
        }

        private IQueryable<HowDto> HowQuery(QueryInput queryInput)
        {
            var id = queryInput.Id;
            var filter = queryInput.Filter;

            var query = from obj in _context.Hows
                    .Where(o => !id.HasValue || o.Id == id)
                    .Where(o => string.IsNullOrEmpty(filter) || o.Question.ToLower().Contains(filter.ToLower()))
                select new HowDto
                {
                    Id = obj.Id,
                    Author = obj.Author,
                    Question = obj.Question,
                    Answer = obj.Answer
                };
            return query;
        }

        public Task<PagedList<HowDto>> GetPagedAndFilteredHow(HowParameters howParameters)
        {
            var queryInput = new QueryInput
            {
                Filter = howParameters.Filter
            };
            return Task.FromResult(PagedList<HowDto>.ToPagedList(HowQuery(queryInput),
                howParameters.PageNumber,
                howParameters.PageSize));
        }

        public async Task<HowDto> GetHowById(int id)
        {
            var queryInput = new QueryInput()
            {
                Id = id
            };
            var objQuery = HowQuery(queryInput);

            var res = await objQuery.FirstOrDefaultAsync();
            return res;
        }

        public async Task<How> CreateOrEdit(CreateOrEditHowDto input)
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

        private async Task<How> Create(CreateOrEditHowDto input)
        {
            var obj = _mapper.Map<How>(input);
            await _context.AddAsync(obj);
            await _context.SaveChangesAsync();
            return obj;
        }

        private async Task<How> Update(CreateOrEditHowDto input)
        {
            var obj = await _context.Hows.FirstOrDefaultAsync(o => o.Id == input.Id);
            if (obj == null) return null;

            _mapper.Map(input, obj);
            await _context.SaveChangesAsync();
            return obj;
        }

        public async Task<How> Delete(int id)
        {
            var obj = await _context.Hows.FirstOrDefaultAsync(o => o.Id == id);
            if (obj == null) return null;

            _context.Hows.Remove(obj);
            await _context.SaveChangesAsync();
            return obj;
        }
    }
}

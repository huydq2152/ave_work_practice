using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Mike.Application.Share.Dtos.New;
using Mike.Application.Share.Interface;
using Mike.Models.Common;
using Mike.Models.Common.Helpers;
using Mike.Models.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mike.Application.Services
{
    public class NewService : INewService
    {
        private readonly IMapper _mapper;
        private readonly MikeDbContext _context;

        public NewService(IMapper mapper, MikeDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        private class QueryInput
        {
            public int? Id { get; set; }
        }
        private IQueryable<NewDto> NewQuery(QueryInput queryInput)
        {
            var id = queryInput.Id;

            var query = from obj in _context.News
                    .Where(o => o.IsActive && (!id.HasValue || o.Id == id))
                    .OrderBy(o => o.Order)
                        select new NewDto
                        {
                            Id = obj.Id,
                            Name = obj.Name,
                            Content = obj.Content,
                            CreationTime = obj.CreationTime,
                            Image = obj.Image,
                            Order = obj.Order,
                            IsActive = obj.IsActive
                        };
            return query;
        }


        public Task<PagedList<NewDto>> GetPagedNew(NewParameters newParameters)
        {
            var queryInput = new QueryInput();
            return Task.FromResult(PagedList<NewDto>.ToPagedList(NewQuery(queryInput),
                newParameters.PageNumber,
                newParameters.PageSize));
        }

        public async Task<NewDto> GetNewById(int id)
        {
            var queryInput = new QueryInput()
            {
                Id = id
            };
            var objQuery = NewQuery(queryInput);

            var res = await objQuery.FirstOrDefaultAsync();
            return res;
        }

        public async Task<New> CreateOrEdit(CreateOrEditNewDto input)
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

        private async Task<New> Create(CreateOrEditNewDto input)
        {
            var obj = _mapper.Map<New>(input);
            await _context.AddAsync(obj);
            await _context.SaveChangesAsync();
            return obj;
        }

        private async Task<New> Update(CreateOrEditNewDto input)
        {
            var obj = await _context.News.FirstOrDefaultAsync(o => o.Id == input.Id);
            if (obj == null) return null;

            _mapper.Map(input, obj);
            await _context.SaveChangesAsync();
            return obj;
        }

        public async Task<New> Delete(int id)
        {
            var obj = await _context.News.FirstOrDefaultAsync(o => o.Id == id);
            if (obj == null) return null;

            _context.News.Remove(obj);
            await _context.SaveChangesAsync();
            return obj;
        }
    }
}

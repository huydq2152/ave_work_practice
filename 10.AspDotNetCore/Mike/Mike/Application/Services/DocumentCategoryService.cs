using AutoMapper;
using Mike.Application.Share.Dtos.DocumentCategory;
using Mike.Application.Share.Interface;
using Mike.Models.Common.Helpers;
using Mike.Models.Common;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Mike.Models.Entities;

namespace Mike.Application.Services
{
    public class DocumentCategoryService: IDocumentCategoryService
    {
        private readonly IMapper _mapper;
        private readonly MikeDbContext _context;

        public DocumentCategoryService(IMapper mapper, MikeDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        private class QueryInput
        {
            public int? Id { get; set; }
        }
        private IQueryable<DocumentCategoryDto> DocumentCategoryQuery(QueryInput queryInput)
        {
            var id = queryInput.Id;

            var query = from obj in _context.DocumentCategories
                    .Where(o => o.IsActive && (!id.HasValue || o.Id == id))
                    .OrderBy(o => o.Order)
                        select new DocumentCategoryDto
                        {
                            Id = obj.Id,
                            Name = obj.Name,
                            IsActive = obj.IsActive,
                            Order = obj.Order
                        };
            return query;
        }

        public async Task<List<DocumentCategoryDto>> GetAll()
        {
            var queryInput = new QueryInput();
            var objQuery = DocumentCategoryQuery(queryInput);

            var res = await objQuery.ToListAsync();
            return res;
        }

        public async Task<DocumentCategoryDto> GetDocumentCategoryById(int id)
        {
            var queryInput = new QueryInput()
            {
                Id = id
            };
            var objQuery = DocumentCategoryQuery(queryInput);

            var res = await objQuery.FirstOrDefaultAsync();
            return res;
        }

        public async Task<DocumentCategory> CreateOrEdit(CreateOrEditDocumentCategoryDto input)
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

        private async Task<DocumentCategory> Create(CreateOrEditDocumentCategoryDto input)
        {
            var obj = _mapper.Map<DocumentCategory>(input);
            await _context.AddAsync(obj);
            await _context.SaveChangesAsync();
            return obj;
        }

        private async Task<DocumentCategory> Update(CreateOrEditDocumentCategoryDto input)
        {
            var obj = await _context.DocumentCategories.FirstOrDefaultAsync(o => o.Id == input.Id);
            if (obj == null) return null;

            _mapper.Map(input, obj);
            await _context.SaveChangesAsync();
            return obj;
        }

        public async Task<DocumentCategory> Delete(int id)
        {
            var obj = await _context.DocumentCategories.FirstOrDefaultAsync(o => o.Id == id);
            if (obj == null) return null;

            _context.DocumentCategories.Remove(obj);
            await _context.SaveChangesAsync();
            return obj;
        }
    }
}

using AutoMapper;
using Mike.Application.Share.Dtos.Document;
using Mike.Application.Share.Interface;
using Mike.Models.Common.Helpers;
using Mike.Models.Common;
using Mike.Models.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace Mike.Application.Services
{
    public class DocumentService : IDocumentService
    {
        private readonly IMapper _mapper;
        private readonly MikeDbContext _context;

        public DocumentService(IMapper mapper, MikeDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        private class QueryInput
        {
            public int? Id { get; set; }

            public int? DocumentCategoryId { get; set; }
        }

        private IQueryable<DocumentDto> DocumentQuery(QueryInput queryInput)
        {
            var id = queryInput.Id;
            var documentCategoryId = queryInput.DocumentCategoryId;

            var query = from obj in _context.Documents
                    .Where(o => o.IsActive && (!id.HasValue || o.Id == id))
                    .Where(o => !documentCategoryId.HasValue || o.DocumentCategoryId == documentCategoryId)
                    .OrderBy(o => o.Order)
                        select new DocumentDto
                        {
                            Id = obj.Id,
                            Name = obj.Name,
                            IsActive = obj.IsActive,
                            Order = obj.Order,
                            DocumentCategoryId = obj.DocumentCategoryId,
                            Image = obj.Image,
                            FileUrl = obj.FileUrl
                        };
            return query;
        }

        public Task<PagedList<DocumentDto>> GetPagedDocumentByDocumentCategory(DocumentParameters documentParameters)
        {
            var queryInput = new QueryInput();
            if (documentParameters.DocumentCategoryId.HasValue)
            {
                queryInput.DocumentCategoryId = documentParameters.DocumentCategoryId;
            }
            return Task.FromResult(PagedList<DocumentDto>.ToPagedList(DocumentQuery(queryInput),
                documentParameters.PageNumber,
                documentParameters.PageSize));
        }

        public async Task<DocumentDto> GetDocumentById(int id)
        {
            var queryInput = new QueryInput()
            {
                Id = id
            };
            var objQuery = DocumentQuery(queryInput);

            var res = await objQuery.FirstOrDefaultAsync();
            return res;
        }

        public async Task PostFile([FromForm] FileUploadRequest fileUpload)
        {
            var saveFilePath = Path.Combine($"{GlobalConfig.UploadPath}/", fileUpload.FileName);
            await using var stream = new FileStream(saveFilePath, FileMode.Create);
            await fileUpload.File.CopyToAsync(stream);
        }

        public async Task<Document> CreateOrEdit(CreateOrEditDocumentDto input)
        {
            input.Image = $"{GlobalConfig.ImageFolderUrl}/{input.Image}";
            input.FileUrl = $"{GlobalConfig.UploadPath}/{input.FileUrl}";
            if (input.Id == null)
            {
                return await Create(input);
            }
            else
            {
                return await Update(input);
            }
        }

        private async Task<Document> Create(CreateOrEditDocumentDto input)
        {
            var obj = _mapper.Map<Document>(input);
            await _context.AddAsync(obj);
            await _context.SaveChangesAsync();
            return obj;
        }

        private async Task<Document> Update(CreateOrEditDocumentDto input)
        {
            var obj = await _context.Documents.FirstOrDefaultAsync(o => o.Id == input.Id);
            if (obj == null) return null;

            _mapper.Map(input, obj);
            await _context.SaveChangesAsync();
            return obj;
        }

        public async Task<Document> Delete(int id)
        {
            var obj = await _context.Documents.FirstOrDefaultAsync(o => o.Id == id);
            if (obj == null) return null;

            _context.Documents.Remove(obj);
            await _context.SaveChangesAsync();
            return obj;
        }
    }
}

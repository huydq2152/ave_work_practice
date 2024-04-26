using Microsoft.AspNetCore.Mvc;
using Mike.Application.Share.Dtos.Document;
using Mike.Models.Common.Helpers;
using Mike.Models.Entities;
using System.Threading.Tasks;

namespace Mike.Application.Share.Interface
{
    public interface IDocumentService
    {
        Task<PagedList<DocumentDto>> GetPagedDocumentByDocumentCategory(DocumentParameters documentParameters);

        public Task<DocumentDto> GetDocumentById(int id);

        public Task PostFile([FromForm] FileUploadRequest fileUpload);

        Task<Document> CreateOrEdit(CreateOrEditDocumentDto input);

        public Task<Document> Delete(int id);
    }
}

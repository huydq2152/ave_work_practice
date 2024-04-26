using Mike.Application.Share.Dtos.Document;
using Mike.Application.Share.Dtos.Navigation;
using Mike.Models.Common.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;
using Mike.Application.Share.Dtos.DocumentCategory;
using Mike.Models.Entities;

namespace Mike.Application.Share.Interface
{
    public interface IDocumentCategoryService
    {
        public Task<List<DocumentCategoryDto>> GetAll();

        public Task<DocumentCategoryDto> GetDocumentCategoryById(int id);

        Task<DocumentCategory> CreateOrEdit(CreateOrEditDocumentCategoryDto input);

        public Task<DocumentCategory> Delete(int id);
    }
}

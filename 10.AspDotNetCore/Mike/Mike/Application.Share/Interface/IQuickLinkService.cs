using Mike.Application.Share.Dtos.QuickLink;
using System.Collections.Generic;
using System.Threading.Tasks;
using Mike.Models.Entities;

namespace Mike.Application.Share.Interface
{
    public interface IQuickLinkService
    {
        public Task<List<QuickLinkDto>> GetAll();

        public Task<QuickLinkDto> GetQuickLinkById(int id);

        Task<QuickLink> CreateOrEdit(CreateOrEditQuickLinkDto input);

        public Task<QuickLink> Delete(int id);
    }
}

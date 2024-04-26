using Mike.Application.Share.Dtos.How;
using Mike.Models.Common.Helpers;
using Mike.Models.Entities;
using System.Threading.Tasks;

namespace Mike.Application.Share.Interface
{
    public interface IHowService
    {
        Task<PagedList<HowDto>> GetPagedAndFilteredHow(HowParameters howParameters);

        public Task<HowDto> GetHowById(int id);

        Task<How> CreateOrEdit(CreateOrEditHowDto input);

        public Task<How> Delete(int id);
    }
}

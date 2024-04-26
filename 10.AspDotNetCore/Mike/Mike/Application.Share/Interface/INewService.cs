using Mike.Application.Share.Dtos.New;
using Mike.Models.Common.Helpers;
using Mike.Models.Entities;
using System.Threading.Tasks;

namespace Mike.Application.Share.Interface
{
    public interface INewService
    {
        Task<PagedList<NewDto>> GetPagedNew(NewParameters newParameters);

        public Task<NewDto> GetNewById(int id);

        Task<New> CreateOrEdit(CreateOrEditNewDto input);

        public Task<New> Delete(int id);
    }
}

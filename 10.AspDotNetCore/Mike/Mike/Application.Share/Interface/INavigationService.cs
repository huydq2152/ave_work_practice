using System.Collections.Generic;
using System.Threading.Tasks;
using Mike.Application.Share.Dtos.Navigation;
using Mike.Models.Entities;

namespace Mike.Application.Share.Interface
{
    public interface INavigationService
    {
        public Task<List<NavigationDto>> GetAll();

        public Task<NavigationDto> GetNavigationById(int id);

        Task<Navigation> CreateOrEdit(CreateOrEditNavigationDto input);

        public Task<Navigation> Delete(int id);
    }
}

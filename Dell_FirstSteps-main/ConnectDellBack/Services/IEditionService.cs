using ConnectDellBack.DTOs;
using ConnectDellBack.Models;

namespace ConnectDellBack.Services
{
    public interface IEditionService
    {
        public Task<int> AddEdition(EditionDTO edition);
        public Task<int> UpdateEdition(EditionDTO editionForm);
        public Task<IEnumerable<UserDTO>> GetUsersNotAdmin();
        public Task<IEnumerable<EditionDTO>> AllEditions(int idProgram);
        public Task<NewEditionDTO> GetEditionInfo(int idEdition);
    }
}
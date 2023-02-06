using ConnectDellBack.DTOs;
using ConnectDellBack.Models;

namespace ConnectDellBack.Services
{
    public interface IEditionService
    {
        //public Task<EditionDTO> GetEdition(int idUser, int role); // grupo 4
        public Task<int> addEdition(EditionDTO edition);
        public Task<int> updateEdition(EditionDTO editionForm);
        public Task<EditionDTO> getEditionInfo(int idProgram, int idEdition);
        public Task<UserDTO> showUser(int idEdition);
        public Task<IEnumerable<UserDTO>> getUsersNotAdmin();

    }

}
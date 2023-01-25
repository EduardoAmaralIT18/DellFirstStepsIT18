using ConnectDellBack.DTOs;
using ConnectDellBack.Models;

namespace ConnectDellBack.Services
{
    public interface IUpdateEditionService
    {
        //public Task<EditionDTO> GetEdition(int idUser, int role); // grupo 4
        public Task<int> addEdition(EditionDTO edition);

    }

}
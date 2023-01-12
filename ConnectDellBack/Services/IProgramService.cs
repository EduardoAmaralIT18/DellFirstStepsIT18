using ConnectDellBack.DTOs;

namespace ConnectDellBack.Services
{
    public interface IProgramService
    {
        public Task<ProgramDTO> GetPrograms(int idUser, string role);
    }
}
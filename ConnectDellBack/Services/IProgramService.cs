using ConnectDellBack.Models;

namespace ConnectDellBack.Services
{
    public interface IProgramService
    {
        public Task<IEnumerable<ProgramModel>> GetPrograms(int idUser, string role);
        public Task<IEnumerable<ProgramModel>> GetMyPrograms(int idUser, string role);
    }
}
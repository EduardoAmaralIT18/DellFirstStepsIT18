using ConnectDellBack.DTOs;
using ConnectDellBack.Models;

namespace ConnectDellBack.Services
{
    public interface IProgramService
    {
        public Task<ProgramDTO> GetPrograms(int idUser, int role);
        public Task<int> addProgram(ProgramModel program);
        public Task<MyProgramDTO> getProgramById (int targetId);
    }

}
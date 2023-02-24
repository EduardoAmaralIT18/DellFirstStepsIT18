using ConnectDellBack.DTOs;
using ConnectDellBack.Models;

namespace ConnectDellBack.Services
{
    public interface IProgramService
    {
        public Task<ProgramDTO> GetPrograms(int idUser, int role);
        public Task<int> addProgram(ProgramModel program);
        public Task<ProgramInfoDTO> getProgramInfo(int id1, int idUser);
        public Task<ProgramInfoDTO> getProgramInfoNoPermission(int id1);
        public Task<int> UpdateProgram(ProgramModel program);
        public Task<ProgramModel> GetProgram(int id);
        public Task<IEnumerable<ProgramInfoDTO>> GetProgramsName();

    }
}
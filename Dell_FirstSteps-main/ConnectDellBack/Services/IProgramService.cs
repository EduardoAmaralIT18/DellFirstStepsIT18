using ConnectDellBack.DTOs;
using ConnectDellBack.Models;

namespace ConnectDellBack.Services
{
    public interface IProgramService
    {
        public Task<ProgramDTO> GetPrograms(int idUser, int role);
        public Task<int> AddProgram(ProgramModel program);
        public Task<ProgramInfoDTO> GetProgramInfo(int id, int userId);
        public Task<ProgramInfoDTO> GetProgramInfoNoPermission(int id1);
        public Task<int> UpdateProgram(ProgramModel program);
        public Task<ProgramModel> GetProgram(int id);
        public Task<IEnumerable<ProgramInfoDTO>> GetProgramsName();

    }
}
using ConnectDellBack.DTOs;
using ConnectDellBack.Models;

namespace ConnectDellBack.Services
{
    public interface IProgramService
    {
        public Task<ProgramDTO> GetPrograms(int idUser, int role);
        public Task<int> addProgram(ProgramModel program);
        public Task<MyProgramDTO> getProgramById (int id);
        public Task<ProgramInfoDTO> getProgramInfo(int id1, int idUser);
        public Task<ProgramModel> getProgramInfoNoPermission(int id1);

    }

}
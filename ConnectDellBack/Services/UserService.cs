using Microsoft.EntityFrameworkCore;
using DellFirstSteps.Models;
using DellFirstSteps.Services;

namespace DellFirstSteps.Services;

public class UserService : IUserService
{
    public readonly ApplicationContext dbUser;

    string IUserService.assignEdition(int idUser, int idEdition)
    {
        throw new NotImplementedException();
    }

    public UserService(ApplicationContext _dbuser)
    {
        dbUser = _dbuser;
    }

    string IUserService.assignProgram(int idUser, int idProgram)
    {
        throw new NotImplementedException();
    }

    string IUserService.createEdition(EditionModel edition)
    {
        throw new NotImplementedException();
    }

    string IUserService.createProgram(ProgramModel program)
    {
        throw new NotImplementedException();
    }

    string IUserService.createUser(UserModel user)
    {
        throw new NotImplementedException();
    }

    Task<IEnumerable<ProgramModel>> IUserService.Get()
    {
        throw new NotImplementedException();

    private readonly ApplicationContext _dbuser;

    public UserService(ApplicationContext dbuser)
    {
        _dbuser = dbuser;

    }

    public async Task<IEnumerable<UserModel>> GetUser()
    {
        return await _dbuser.users
                    .Include(x => x.name)
                    .Include(x => x.ProgramsAdmins)
                    .ToListAsync();
    }
    //coment rapido prar poder rodar o back - pode descomentar depois
    /*
      Task<IEnumerable<ProgramModel>> Get()
      {
            return 
        }

        Task<ProgramModel> Get(int Id)
        {
            return Ok;
        }*/

    IEnumerable<UserModel> IUserService.listUsers()
    {
        var userList = dbUser.users;
        return userList;
    }
}
// RETORNAR OS PROGRAMAS RELACIONADOS AQUELE USER
// VALIDAÇÃO DO ROLE NO FRONT - COOKIES

}

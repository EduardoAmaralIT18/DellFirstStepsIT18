using Microsoft.EntityFrameworkCore;
using ConnectDellBack.Models;
using System.Threading.Tasks;

namespace ConnectDellBack.Services;

public class UserService : IUserService
{
    private readonly ApplicationContext dbUser;

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
    }


    IEnumerable<UserModel> IUserService.listUsers()
    {
        var userList = dbUser.users;
        return userList;
    }
}
// RETORNAR OS PROGRAMAS RELACIONADOS AQUELE USER
// VALIDAÇÃO DO ROLE NO FRONT - COOKIES

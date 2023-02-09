using Microsoft.EntityFrameworkCore;
using ConnectDellBack.Models;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using ConnectDellBack.DTOs;

namespace ConnectDellBack.Services;

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
    }

    public Task<IEnumerable<ProgramModel>> Get()
    {
        throw new NotImplementedException();
    }

    public IEnumerable<UserModel> GetOwners() {
        var owners = dbUser.users.Where(usr => ((int)usr.role) == 0)
                                    .ToArray<UserModel>();
        return owners;
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

    public async Task<IEnumerable<UserModel>> listUsers()
    {
        var userList = await dbUser.users.OrderBy(user => user.email).ToListAsync();
        return userList;
    }

    public async Task<int> changeRole(int user, int role)
    {
        var usr = await dbUser.users.Where(usr => usr.id == user).FirstOrDefaultAsync();
        usr.role = (Role)role;
       
       int entries = await dbUser.SaveChangesAsync();
       return entries;
        
    }
}

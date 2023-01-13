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
    public readonly ApplicationContext _dbUser;

    public UserService(ApplicationContext dbUser)
    {
        _dbUser = dbUser;
    }

    public Task<IEnumerable<ProgramModel>> Get()
    {
        throw new NotImplementedException();
    }

    public IEnumerable<UserModel> GetOwners() {
        var owners = _dbUser.users.Where(usr => ((int)usr.role) == 0)
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


    

}
// RETORNAR OS PROGRAMAS RELACIONADOS AQUELE USER
// VALIDAÇÃO DO ROLE NO FRONT - COOKIES

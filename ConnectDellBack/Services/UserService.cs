using Microsoft.EntityFrameworkCore;
using ConnectDellBack.Models;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConnectDellBack.Services;

public class UserService : IUserService
{
    public readonly ApplicationContext _dbUser;

    public UserService(ApplicationContext dbUser)
    {
        _dbUser = dbUser;
    }

  Task<IEnumerable<ProgramModel>> Get()
  {
        return 
    }

    Task<ProgramModel> Get(int Id)
    {
        return Ok;
    }


}
// RETORNAR OS PROGRAMAS RELACIONADOS AQUELE USER
// VALIDAÇÃO DO ROLE NO FRONT - COOKIES

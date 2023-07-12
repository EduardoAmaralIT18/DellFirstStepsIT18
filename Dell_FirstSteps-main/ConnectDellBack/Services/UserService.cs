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

    public UserService(ApplicationContext _dbuser)
    {
        dbUser = _dbuser;
    }
    public IEnumerable<UserModel> GetOwners() {
        var owners = dbUser.users.Where(usr => ((int)usr.role) == 0)
                                    .ToArray<UserModel>();
        return owners;
    }

    public async Task<IEnumerable<UserModel>> ListUsers()
    {
        var userList = await dbUser.users.OrderBy(user => user.email).ToListAsync();
        return userList;
    }

    public async Task<int> ChangeRole(int userid, int role)
    {
        var usr = await dbUser.users.Where(usr => usr.id == userid).FirstOrDefaultAsync();
        usr.role = (Role)role;
       
       int entries = await dbUser.SaveChangesAsync();
       return entries;
        
    }

    public async Task<int> RemoveUser(int userid)
    {
        var usr = await dbUser.users.Where(usr => usr.id == userid).FirstOrDefaultAsync();

        dbUser.users.Remove(usr);

        var entries = await dbUser.SaveChangesAsync();

        return entries;
    }
}

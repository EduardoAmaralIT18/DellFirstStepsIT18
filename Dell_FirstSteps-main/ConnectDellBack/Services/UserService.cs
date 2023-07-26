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

    public async Task<UserModel> ChangeRole(int userId, int role)
    {
        var existingUser = await dbUser.users.FindAsync(userId);
        if (existingUser == null)
        {
            throw new Exception("User not found");
        }

        existingUser.role = (Role)role;
        var updatedUser = dbUser.users.Update(existingUser);
        
        await dbUser.SaveChangesAsync();
        return updatedUser.Entity;
        
    }

    public async Task RemoveUser(int userId)
    {
        var existingUser = await dbUser.users.FindAsync(userId);
        if (existingUser == null)
        {
            throw new Exception("User not found");
        }
        dbUser.users.Remove(existingUser);
        await dbUser.SaveChangesAsync();
    }
}

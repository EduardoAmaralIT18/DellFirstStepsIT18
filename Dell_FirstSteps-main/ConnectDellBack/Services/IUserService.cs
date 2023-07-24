using Microsoft.EntityFrameworkCore;
using ConnectDellBack.Models;
using ConnectDellBack.DTOs;


namespace ConnectDellBack.Services;

public interface IUserService
{
    IEnumerable<UserModel> GetOwners();

    public Task<IEnumerable<UserModel>> ListUsers();

    public Task<UserModel> ChangeRole(int userId, int role);
    public Task RemoveUser(int userId);
}


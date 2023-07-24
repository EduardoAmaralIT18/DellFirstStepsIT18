using Microsoft.EntityFrameworkCore;
using ConnectDellBack.Models;
using ConnectDellBack.DTOs;


namespace ConnectDellBack.Services;

public interface IUserService
{
    IEnumerable<UserModel> GetOwners();

    public Task<IEnumerable<UserModel>> ListUsers();

    public Task<int> ChangeRole(int userid, int role);
    public Task RemoveUser(int userId);
}


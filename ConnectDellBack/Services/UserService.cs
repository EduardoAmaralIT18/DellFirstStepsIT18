using Microsoft.EntityFrameworkCore;
using DellFirstSteps.Models;
using DellFirstSteps.Services;

namespace DellFirstSteps.Services;

public class UserService : IUserService
{
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

}
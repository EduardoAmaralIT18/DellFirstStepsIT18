using DellFirstSteps.Models;
using System.Threading.Tasks;

namespace DellFirstSteps.Services;
public interface IUserService
 {
    public Task<IEnumerable<UserModel>> GetUser();
 
}

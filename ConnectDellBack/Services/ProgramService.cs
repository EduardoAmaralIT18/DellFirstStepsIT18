using Microsoft.EntityFrameworkCore;
using ConnectDellBack.Models;

namespace ConnectDellBack.Services;

public class ProgramService : IProgramService
{
    private readonly ApplicationContext _dbPrograms;

    public ProgramService(ApplicationContext dbPrograms)
    {
        _dbPrograms = dbPrograms;
    }

    public async Task<IEnumerable<ProgramModel>> GetPrograms(int idUser, string role)
    {
        return await _dbPrograms.programs.OrderBy(p => p.startDate).ToListAsync();
    }

    public async Task<IEnumerable<ProgramModel>> GetMyPrograms(int idUser, string role)
    {
        return await _dbPrograms.programs.OrderBy(p => p.startDate).ToListAsync();
    }
}
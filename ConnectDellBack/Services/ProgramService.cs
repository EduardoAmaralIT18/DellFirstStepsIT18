using Microsoft.EntityFrameworkCore;
using ConnectDellBack.Models;
using ConnectDellBack.DTOs;

namespace ConnectDellBack.Services;

public class ProgramService : IProgramService
{
    private readonly ApplicationContext _dbContext;

    public ProgramService(ApplicationContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<ProgramDTO> GetPrograms(int idUser, string role)
    {
        var programDTO = new ProgramDTO
        {
            Programs = await _dbContext.programs.OrderBy(p => p.startDate).ToListAsync(),
            MyPrograms = await _dbContext.programs.OrderBy(p => p.startDate).ToListAsync()
        };
        return programDTO;
    }

    public async Task<int> addProgram(ProgramModel program)
    {
        for (int i = 0; i < program.owners.Count; i++)
        {
            var user = _dbContext.users.Where(usr => usr.id == program.owners[i].id).FirstOrDefault();
            program.owners[i] = user;
        }
        await _dbContext.programs.AddAsync(program);
        int entries = await _dbContext.SaveChangesAsync();
        return entries;
    }

}
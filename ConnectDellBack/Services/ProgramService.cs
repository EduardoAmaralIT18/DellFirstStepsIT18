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

    public async Task<ProgramDTO> GetPrograms(int idUser, int role)
    {
        var user = _dbContext.users.FirstOrDefault(u => u.id == idUser);
        var programs = await _dbContext.programs.OrderBy(p => p.startDate).ToListAsync();
        
        var myPrograms = new List<ProgramModel>();
        switch (role)
        {
            case 0: //Admin
                myPrograms = programs; //TODO: filter
                break;
            case 1: //Intern
                myPrograms = programs; //TODO: filter
                break;
            default: //Other
                myPrograms = programs; //TODO: filter
                break;
        }

        var programDTO = new ProgramDTO
        {
            Programs = programs.Except(myPrograms).ToList(),
            MyPrograms = myPrograms
        };

        return programDTO;
    }
}
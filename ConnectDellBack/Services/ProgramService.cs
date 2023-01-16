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
@AlexyaOliveiraIT17 AlexyaOliveiraIT17 Pending
Não deve ser pagado

@AlexyaOliveiraIT17	Reply...
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

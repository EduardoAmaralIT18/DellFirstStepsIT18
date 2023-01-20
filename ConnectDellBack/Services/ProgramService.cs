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
        var user = _dbContext.users.Where(u => u.id == idUser)
                                    .Include(user => user.ProgramsAdmins)
                                    .Include(user => user.editionIntern)
                                    .Include(user => user.memberships)
                                    .FirstOrDefault();

        var allPrograms = await _dbContext.programs.OrderBy(p => p.startDate).ToListAsync();

        var programs = new List<MyProgramDTO>();
        var myPrograms = new List<MyProgramDTO>();

        foreach (var item in allPrograms)
        {
            programs.Add(MyProgramDTO.convertToDTOAll(item));
        }

        switch (role)
        {
            case 0: //Admin  
                foreach (var item in user.ProgramsAdmins)
                {
                    myPrograms.Add(MyProgramDTO.convertToDTOAdmin(item));
                }
                break;
            case 1: //Intern
                myPrograms.Add(MyProgramDTO.convertToDTOIntern(user.editionIntern.program, user.editionIntern));
                //TODO: filter
                break;
            default: //Other
                foreach (var item in user.memberships)
                {
                    myPrograms.Add(MyProgramDTO.convertToDTOOthers(item.edition.program, item.edition));
                }
                //TODO: filter
                break;
        }
        
        programs.RemoveAll(p => myPrograms.Any(m => m.id == p.id));

        var programDTO = new ProgramDTO
        {
            Programs = programs,
            MyPrograms = myPrograms,
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

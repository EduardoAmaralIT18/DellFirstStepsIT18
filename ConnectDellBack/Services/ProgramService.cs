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
            MyPrograms = myPrograms,
            // Programs = await _dbContext.programs.OrderBy(p => p.startDate).ToListAsync(),
            // MyPrograms = await _dbContext.programs.OrderBy(p => p.startDate).ToListAsync()
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

    public async Task<ProgramInfoDTO> getProgramInfo(int id1, int idUser)
    {

        var user = await _dbContext.users.Where(u => u.id == idUser)
                                    .Include(user => user.editionIntern)
                                    .ThenInclude(user => user.program)
                                    .Include(user => user.ownerships)
                                    .ThenInclude(user => user.program)
                                    .ThenInclude(user => user.editions)
                                    .Include(user => user.memberships)
                                    .ThenInclude(user => user.edition)
                                    .ThenInclude(user => user.program)
                                    .FirstOrDefaultAsync();
        ProgramInfoDTO program = new ProgramInfoDTO();
        if (user.ownerships.Any(u => u.program.id == id1))
        {
            var ownership = user.ownerships.Where(o => o.program.id == id1).FirstOrDefault();
            program = ProgramInfoDTO.convertModel2DTOAdmin(ownership.program);
        }
        else if (user.role.Equals(Role.Intern) && user.editionIntern.program.id == id1)
        {
            var prog = user.editionIntern.program;
            var edition = user.editionIntern;
            program = ProgramInfoDTO.convertModel2DTOIntern(prog, edition);
        }
        else
        {
            var membership = user.memberships.Where(m => m.edition.program.id == id1).ToList();
            List<EditionModel> editions = new List<EditionModel>();
            foreach (var i in membership)
            {
                editions.Add(i.edition);
            }
            program = ProgramInfoDTO.convertModel2DTOOthers(membership[0].edition.program, editions);
        }

        return program;
    }

    public async Task<ProgramModel> getProgramInfoNoPermission(int id1)
    {
        var program = await _dbContext.programs.Where(p => p.id == id1).FirstOrDefaultAsync();
        return program;
    }
    
}

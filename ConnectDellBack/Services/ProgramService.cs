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
                                    .ThenInclude(edt => edt.program)
                                    .Include(user => user.memberships)
                                    .ThenInclude(memb => memb.edition)
                                    .ThenInclude(edt => edt.program)
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
            case 0:
                foreach (var item in user.ProgramsAdmins)
                {
                    myPrograms.Add(MyProgramDTO.convertToDTOAdmin(item));
                }
                break;
            case 1:
                myPrograms.Add(MyProgramDTO.convertToDTOIntern(user.editionIntern.program, user.editionIntern));

                break;
            default:
                foreach (var item in user.memberships)
                {
                    myPrograms.Add(MyProgramDTO.convertToDTOOthers(item.edition.program, item.edition));
                }

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
  

    public async Task<ProgramInfoDTO> getProgramInfo(int id1, int idUser)
    {
        var user = await _dbContext.users.Where(u => u.id == idUser)
                                    .Include(user => user.editionIntern)
                                    .ThenInclude(user => user.program)
                                    .ThenInclude(user => user.owners)
                                    .ThenInclude(user => user.ownerships)
                                    .Include(user => user.ownerships)
                                    .ThenInclude(user => user.program)
                                    .ThenInclude(user => user.editions)
                                    .Include(user => user.memberships)
                                    .ThenInclude(user => user.edition)
                                    .ThenInclude(user => user.program)
                                    .ThenInclude(user => user.owners)
                                    .ThenInclude(user => user.ownerships)
                                    .FirstOrDefaultAsync();

        ProgramInfoDTO program = new ProgramInfoDTO();
        if (user.ownerships.Any(u => u.program.id == id1))
        {
            var multipleOwner = await _dbContext.programs.Where(p => p.id == id1)
                                    .Include(p => p.owners)
                                    .Include(p => p.ownerships)
                                    .FirstOrDefaultAsync();

            var ownership = user.ownerships.Where(o => o.program.id == id1).ToList();
            program = ProgramInfoDTO.convertModel2DTOAdmin(ownership, multipleOwner);
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

    public async Task<ProgramInfoDTO> getProgramInfoNoPermission(int id1)
    {
        var program = await _dbContext.programs.Where(p => p.id == id1)
                                                .Include(p => p.owners)
                                                .Include(p => p.ownerships)
                                                .FirstOrDefaultAsync();
        return ProgramInfoDTO.convertModel2DTONoPermission(program);
    }

    
    public async Task<int> UpdateProgram(ProgramModel program)
    {
         var ownerships = _dbContext.OwnershipModel.Where(o => o.program.id == program.id);
        _dbContext.OwnershipModel.RemoveRange(ownerships);
        await _dbContext.SaveChangesAsync();

        _dbContext.programs.Update(program);

        int entries = await _dbContext.SaveChangesAsync();
        return entries;
    }

    public async Task<ProgramModel> GetProgram(int id)
    {
        var program = await _dbContext.programs.Where(p => p.id == id)
                                               .Include(p => p.owners)
                                               .FirstOrDefaultAsync();
        return program;
    }
}
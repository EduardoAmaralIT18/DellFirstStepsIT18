using Microsoft.EntityFrameworkCore;
using ConnectDellBack.Models;
using ConnectDellBack.DTOs;
namespace ConnectDellBack.Services;
public class EditionService : IEditionService
{
    private readonly ApplicationContext _dbContext;
    public EditionService(ApplicationContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<int> AddEdition(EditionDTO edition)
    {
        var aux = new List<UserModel>();
        if (edition.members != null)
        {
            foreach (var item in edition.members)
            {
                var member = _dbContext.users.Where(usr => usr.id == item.id).FirstOrDefault();
                aux.Add(member);
            }
        }

        var targetInterns = aux;
        targetInterns.Where(usr => usr.role == Role.Intern).ToList();

        var edt = new EditionModel()
        {
            name = edition.name,
            startDate = edition.startDate,
            endDate = edition.endDate,
            description = edition.description,
            curriculum = edition.curriculum,
            numberOfInterns = edition.numberOfInterns,
            members = aux,
            interns = targetInterns,

            mode = (Mode)edition.mode,
            program = _dbContext.programs.Where(prog => prog.id == edition.program).FirstOrDefault(),
        };

        await _dbContext.editions.AddAsync(edt);
        int entries = await _dbContext.SaveChangesAsync();
        return entries;
    }


    public async Task<int> UpdateEdition(EditionDTO dto)
    {
        var program = await _dbContext.programs.FindAsync(dto.program);
        var model = NewEditionDTO.ToModel(dto, program);
       

        var edition = _dbContext.editions.Where(ed => ed.id == model.id)
                                         .Include(ed => ed.members)
                                         .FirstOrDefault();

        if (edition != null)
        {
            edition.name = model.name;
            edition.startDate = model.startDate;
            edition.endDate = model.endDate;
            edition.endDate = model.endDate.AddDays(1);
            edition.description = model.description;
            edition.curriculum = model.curriculum;
            edition.numberOfInterns = model.numberOfInterns;
            List<UserModel> members = new List<UserModel>();

            edition.members.Clear();
            foreach (var item in model.members)
            {
                members.Add(await _dbContext.users.Where(user => user.id == item.id).FirstOrDefaultAsync());
            }
            edition.mode = model.mode;
            edition.members.AddRange(members);
            
            int entries = await _dbContext.SaveChangesAsync();
            return 1;
        }
        else
        {
            return 0;
        }
    }

    public async Task<NewEditionDTO> GetEditionInfo( int idEdition)
    {
        var edition = await _dbContext.editions.Where(ed => ed.id == idEdition)
                                                .Include(ed => ed.program)
                                                .Include(ed => ed.events)
                                                .Include(ed => ed.interns)
                                                .Include(ed => ed.members)
                                                .FirstOrDefaultAsync();
        return NewEditionDTO.ConvertModel2DTO(edition);
    }
 
    public async Task<IEnumerable<UserDTO>> GetUsersNotAdmin()
    {
        var aux = await _dbContext.users.Where(usr => ((int)usr.role) != 0)
                                        .OrderBy(usr => usr.name)
                                        .ToArrayAsync<UserModel>();

        var members = new List<UserDTO>();
        foreach (var item in aux)
        {
            members.Add(UserDTO.ConvertToDTO(item));
        }
        return members;
    }

    public async Task<IEnumerable<EditionDTO>> AllEditions(int idProgram)
    {
        var editions = await _dbContext.editions.Where(edit => edit.program.id == idProgram)
                                                .Include(ed => ed.program)
                                                .ToArrayAsync<EditionModel>();
        List<EditionDTO> aux = new List<EditionDTO>();
        foreach (var edition in editions)
        {
            aux.Add(EditionDTO.ConvertModel2DTOJustName(edition));
        }
        return aux;
    }

}

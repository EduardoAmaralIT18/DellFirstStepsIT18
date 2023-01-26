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

    public async Task<int> addEdition(EditionDTO edition)
    {
        var edt = new EditionModel()
        {
            name = edition.name,
            startDate = edition.startDate,
            endDate = edition.endDate,
            description = edition.description,
            curriculum = edition.curriculum,
            numberOfInterns = edition.numberOfInterns,
            numberOfMembers = edition.numberOfMembers,
            mode = (Mode)edition.mode,
            program = _dbContext.programs.Where(prog => prog.id == edition.program).FirstOrDefault(),
        };

        await _dbContext.editions.AddAsync(edt);
        int entries = await _dbContext.SaveChangesAsync();
            return entries;
    }


    public async Task<int> updateEdition(EditionDTO editionForm)
    {
        //Puxar objeto do database
        //mexer nas váriáveis dele na mão
        //Descobrir como enviar esse objeto atualizado, sem criar um novo.

        //                                                      !
        var edition =  _dbContext.editions.Where(ed => ed.id == 1).FirstOrDefault();

        if(edition != null) {
            edition.name = editionForm.name;
            edition.startDate = editionForm.startDate;
            edition.endDate = editionForm.endDate;
            edition.description = editionForm.description;
            edition.curriculum = editionForm.curriculum;
            edition.numberOfMembers = editionForm.numberOfMembers;
            edition.numberOfInterns = editionForm.numberOfInterns;
            edition.mode = (Mode) editionForm.mode;

            int entries = await _dbContext.SaveChangesAsync();
            return 1;

        } else {

            return 0;

        }

    }

    public async Task<EditionDTO> getEditionInfo(int idProgram, int idEdition) {
        var edition = await _dbContext.editions.Where(ed => ed.id == idEdition)
                                                .Include(ed => ed.program)
                                                .FirstOrDefaultAsync();
        return EditionDTO.convertModel2DTO(edition);
    }

}

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

    
}

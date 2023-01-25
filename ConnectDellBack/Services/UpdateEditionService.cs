using Microsoft.EntityFrameworkCore;
using ConnectDellBack.Models;
using ConnectDellBack.DTOs;

namespace ConnectDellBack.Services;
public class UpdateEditionService : IUpdateEditionService
{
    private readonly ApplicationContext _dbContext;
    public UpdateEditionService(ApplicationContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<int> addEdition(EditionDTO edition)
    {
        throw new NotImplementedException();
    }

    // public async Task<int> updateEdition(EditionDTO edition)
    // {
    //     var edt = new EditionModel()
    //     {
    //         name = edition.name,
    //         startDate = edition.startDate,
    //         endDate = edition.endDate,
    //         description = edition.description,
    //         curriculum = edition.curriculum,
    //         numberOfInterns = edition.numberOfInterns,
    //         numberOfMembers = edition.numberOfMembers,
    //         mode = (Mode)edition.mode,
    //         program = edition.program
    //     };

    //     await _dbContext.editions.AddAsync(edt);
    //     int entries = await _dbContext.SaveChangesAsync();
    //         return entries;
    // }


}

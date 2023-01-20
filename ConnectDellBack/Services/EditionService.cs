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


    //// GRUPO 4 ////
   /* public async Task<ProgramDTO> GetEditions(int idUser, int role)

    {
        var user = _dbContext.users.FirstOrDefault(u => u.id == idUser);

        var editions = await _dbContext.programs.OrderBy(p => p.startDate).ToListAsync();

        var myEditions = new List<EditionModel>();
        switch (role)
        {
            case 0: //Admin
                myEditions = editions; //TODO: filter
                break;
            // case 1: //Intern
            //     myEditions = programs; //TODO: filter
            //     break;
            // default: //Other
            //     myPrograms = programs; //TODO: filter
            //     break;
        }

        var editionDTO = new editionDTO
        {
            Editions = editions.Except(myEditions).ToList(),
            MyEditions = myEditions,
            // Programs = await _dbContext.programs.OrderBy(p => p.startDate).ToListAsync(),
            // MyPrograms = await _dbContext.programs.OrderBy(p => p.startDate).ToListAsync()
        };

        return editionDTO;
    }
*/
    public async Task<int> addEdition(EditionModel edition)
    {
        
        await _dbContext.editions.AddAsync(edition);
        int entries = await _dbContext.SaveChangesAsync();
        return entries;
        
     }

    
}

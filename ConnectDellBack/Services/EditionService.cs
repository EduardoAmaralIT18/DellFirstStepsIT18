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


    // public async Task<EditionDTO> updateEdition(int editionId, int idProgram) {
    //     //Referencias: https://stackoverflow.com/questions/18604714/update-database-from-dataset
    //     // using (SqlConnection connection = new SqlConnection(connString))
    //     // using (SqlCommand cmd = new SqlCommand("UPDATE Inventory SET qty = @qty WHERE sku = @sku", connection))
    //     // {
    //     //     connection.Open();
    //     //     var paramqty=  cmd.Parameters.Add("@qty", SqlDbType.Int);
    //     //     var parasku = cmd.Parameters.Add("@sku", SqlDbType.VarChar);
    //     // foreach (DataRow row in amzInventoryDataSet.Tables[0].Rows)
    //     //     {
    //     //         parasku.Value = row["seller-sku"].ToString();
    //     //         paramqty.Value = int.Parse(row["quantity"].ToString());
    //     //         cmd.ExecuteNonQuery();
    //     //     }
    //     // }


    //     //Segunda opção
    //     // public async Task<int> UpdateProgram(ProgramModel program)
    //     // {
    //     //     var ownerships = _dbContext.OwnershipModel.Where(o => o.program.id == program.id);
    //     //     _dbContext.OwnershipModel.RemoveRange(ownerships);
    //     //     await _dbContext.SaveChangesAsync();

    //     //     _dbContext.programs.Update(program);

    //     //     int entries = await _dbContext.SaveChangesAsync();
    //     //     return entries;
    //     // }
    // }

    public async Task<EditionDTO> getEditionInfo(int idProgram, int idEdition) {
        var edition = await _dbContext.editions.Where(ed => ed.id == idEdition)
                                                .Include(ed => ed.program)
                                                .FirstOrDefaultAsync();
        return EditionDTO.convertModel2DTO(edition);
    }

}

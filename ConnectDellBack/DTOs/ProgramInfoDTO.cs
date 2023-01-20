using ConnectDellBack.Models;

namespace ConnectDellBack.DTOs;

public class ProgramInfoDTO
{
    public string name { get; set; } = null!;
    public DateTime startDate { get; set; }
    public DateTime? endDate { get; set; }
    public string description { get; set; }
    public List<EditionModel>? editions { get; set; } = new List<EditionModel>();
    public List<UserModel> owners { get; set; } = new List<UserModel>();

    public static ProgramInfoDTO convertModel2DTO(ProgramModel program)
    {
        ProgramInfoDTO aux = new ProgramInfoDTO();
        aux.name = program.name;
        aux.startDate = program.startDate;
        if (program.endDate != null)
        {
            aux.endDate = program.endDate;
        }
        aux.description = program.description;
        foreach (var item in program.editions)
        {
            aux.editions.Add(new EditionModel()
            {
                name = item.name,
                description = item.description,
                startDate = item.startDate
            });
        }
        // aux.Sort((x, y) => DateTime.Compare(x.Created, y.Created));
        foreach (var item in program.owners)
        {
            aux.owners.Add(new UserModel()
            {
                name = item.name,
                id = item.id
            });
        }
        return aux;
    }
}
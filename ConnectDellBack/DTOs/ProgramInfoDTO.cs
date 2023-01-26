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

    public static ProgramInfoDTO convertModel2DTOAdmin(List<OwnershipModel> ownership, ProgramModel programOwners)
    {
        ProgramInfoDTO aux = new ProgramInfoDTO();
        aux.name = ownership[0].program.name;
        aux.startDate = ownership[0].program.startDate;
        if (ownership[0].program.endDate != null)
        {
            aux.endDate = ownership[0].program.endDate;
        }
        aux.description = ownership[0].program.description;
        foreach (var item in ownership[0].program.editions)
        {
            aux.editions.Add(new EditionModel()
            {
                name = item.name,
                description = item.description,
                startDate = item.startDate
            });
        }
        aux.editions = aux.editions.OrderByDescending(i => i.startDate).ToList<EditionModel>();
        foreach (var item in programOwners.owners)
        {
            aux.owners.Add(new UserModel()
            {
                name = item.name,
                id = item.id
            });
        }
        return aux;
    }

    public static ProgramInfoDTO convertModel2DTOIntern(ProgramModel program, EditionModel edition)
    {
        ProgramInfoDTO aux = new ProgramInfoDTO();
        if (program != null)
        {
            aux.name = program.name;
            aux.startDate = program.startDate;
            if (program.endDate != null)
            {
                aux.endDate = program.endDate;
            }
            aux.description = program.description;
            aux.editions.Add(new EditionModel()
            {
                name = edition.name,
                description = edition.description,
                startDate = edition.startDate
            });

            foreach (var item in program.owners)
            {
                aux.owners.Add(new UserModel()
                {
                    name = item.name
                });
            }
        }
        return aux;
    }

    public static ProgramInfoDTO convertModel2DTOOthers(ProgramModel program, List<EditionModel> editions)
    {
        ProgramInfoDTO aux = new ProgramInfoDTO();
        if (program != null)
        {
            aux.name = program.name;
            aux.startDate = program.startDate;
            if (program.endDate != null)        
            {            
                aux.endDate = program.endDate;
            }        
            aux.description = program.description;        
            foreach (var item in editions)        
            {            
                aux.editions.Add(new EditionModel()            
            {                name = item.name,                description = item.description,                startDate = item.startDate,                id = item.id            });        }        foreach (var item in program.owners)        {            aux.owners.Add(new UserModel()            {                name = item.name,            });        }
        }
        aux.editions = aux.editions.OrderByDescending(i => i.startDate).ToList<EditionModel>();
        foreach (var item in program.owners)
        {
            aux.owners.Add(new UserModel()
            {
                aux.editions.Add(new EditionModel()
                {
                    name = item.name,
                    description = item.description,
                    startDate = item.startDate
                });
            }
            foreach (var item in program.owners)
            {
                aux.owners.Add(new UserModel()
                {
                    name = item.name,
                });
            }
        }
        return aux;
    }

    public static ProgramInfoDTO convertModel2DTONoPermission(ProgramModel program)
    {
        ProgramInfoDTO aux = new ProgramInfoDTO();
        if (program!= null) { 
            aux.name = program.name;
            aux.startDate = program.startDate;
            if (program.endDate != null)
            {
                aux.endDate = program.endDate;
            }
            aux.description = program.description;
            foreach (var item in program.owners)
            {
                aux.owners.Add(new UserModel()
                {
                    name = item.name,
                });
            }
        }
        return aux;
    }

}

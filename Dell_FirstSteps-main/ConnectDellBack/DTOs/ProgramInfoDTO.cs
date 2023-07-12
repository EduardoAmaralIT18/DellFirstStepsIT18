using ConnectDellBack.Models;

namespace ConnectDellBack.DTOs;

public class ProgramInfoDTO
{
    public string name { get; set; } = null!;
    public DateTime startDate { get; set; }
    public DateTime? endDate { get; set; }
    public string description { get; set; }
    public List<EditionDTO>? editions { get; set; } = new List<EditionDTO>();
    public List<UserModel> owners { get; set; } = new List<UserModel>();

    public static ProgramInfoDTO ConvertModel2DTOAdmin(List<OwnershipModel> ownership, ProgramModel programOwners)
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
            aux.editions.Add(new EditionDTO()
            {
                name = item.name,
                description = item.description,
                startDate = item.startDate,
                endDate = item.endDate,
                calendarEndDate = item.endDate.AddDays(1),
                id = item.id
            });
        }
        aux.editions = aux.editions.OrderByDescending(i => i.startDate).ToList<EditionDTO>();
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

    public static ProgramInfoDTO ConvertModel2DTOIntern(ProgramModel program, EditionDTO edition)
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
            aux.editions.Add(new EditionDTO()
            {
                id = edition.id,
                name = edition.name,
                description = edition.description,
                startDate = edition.startDate,
                endDate = edition.endDate,
                calendarEndDate = edition.endDate.AddDays(1)
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

    public static ProgramInfoDTO ConvertModel2DTOOthers(ProgramModel program, List<EditionDTO> editions)
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
                aux.editions.Add(new EditionDTO()
                { name = item.name, description = item.description, startDate = item.startDate, id = item.id, endDate = item.endDate, calendarEndDate = item.calendarEndDate});
            }
            aux.editions = aux.editions.OrderByDescending(i => i.startDate).ToList<EditionDTO>();
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

    public static ProgramInfoDTO ConvertModel2DTONoPermission(ProgramModel program)
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

public static ProgramInfoDTO ConvertModel2DTOProgramsName(ProgramModel program)
    {
        ProgramInfoDTO aux = new ProgramInfoDTO();
        if (program != null)
        {
            aux.name = program.name;
        }
        return aux;
    }
}
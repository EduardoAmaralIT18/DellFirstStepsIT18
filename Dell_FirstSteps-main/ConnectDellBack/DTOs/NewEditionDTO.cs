namespace ConnectDellBack.DTOs;
using ConnectDellBack.Models;
public class NewEditionDTO
{
    public int id { get; set; }
    public string name { get; set; } = null!;
    public int numberOfInterns { get; set; }
    public string description { get; set; }
    public string curriculum { get; set; }
    public int mode { get; set; }
    public DateTime startDate { get; set; }
    public DateTime endDate { get; set; }
    // Necessary for the calendar component, since its end date is exclusive and I couldn't add one day through Vue
    public DateTime calendarEndDate { get; set; }
    public int program { get; set; }
    public string programName { get; set; }

    public List<UserDTO> members {get;set;}  = new List<UserDTO>();
    public List<UserDTO> interns {get;set;} = new List<UserDTO>();
    public List<NewEventDTO> events {get;set;} = new List<NewEventDTO>();
    
    public static NewEditionDTO ConvertModel2DTO(EditionModel edition)
    {
        NewEditionDTO aux = new NewEditionDTO();
        aux.id = edition.id;
        aux.name = edition.name;
        aux.numberOfInterns = edition.numberOfInterns;

        foreach (var item in edition.members)
        {
            aux.members.Add(UserDTO.ConvertToDTO(item));
        }
        foreach (var item in edition.interns)
        {
            aux.interns.Add(UserDTO.ConvertToDTO(item));
        }
        foreach (var item in edition.events)
        {
            aux.events.Add(NewEventDTO.ConvertModel2DTO(item));
        }
        aux.description = edition.description;
        aux.curriculum = edition.curriculum;
        aux.mode = (int)edition.mode;
        aux.startDate = edition.startDate;
        aux.endDate = edition.endDate;
        aux.calendarEndDate = edition.endDate.AddDays(1);
        aux.program = edition.program.id;
        aux.programName = edition.program.name;
        return aux;
    }

    public static EditionDTO ConvertModel2DTOJustName (EditionModel edition) {
        EditionDTO aux = new EditionDTO();
        aux.name = edition.name;
        return aux;
    }

    public static EditionModel ToModel(EditionDTO dto, ProgramModel model)
    {
        return new EditionModel
        {
            curriculum = dto.curriculum,
            startDate = dto.startDate,
            numberOfInterns = dto.numberOfInterns,
            description = dto.description,
            events = dto.events,
            id = dto.id,
            interns = dto.interns,
            members = dto.members,
            mode = (Mode)dto.mode,
            name = dto.name,
            program = model,
            endDate = dto.endDate,
            memberships = dto.memberships
        };
    }
}
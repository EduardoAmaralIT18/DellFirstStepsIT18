using System.ComponentModel.DataAnnotations;

namespace ConnectDellBack.DTOs;
using ConnectDellBack.Models;
public class EditionDTO
{
    public int id { get; set; }
    [MinLength(5)]
    public string name { get; set; } = null!;
    [MinLength(1)]
    public int numberOfInterns { get; set; }
    [MinLength(5)]
    public string description { get; set; }
    public string curriculum { get; set; }
    public int mode { get; set; }
    public DateTime startDate { get; set; }
    public DateTime endDate { get; set; }
    // Necessary for the calendar component, since its end date is exclusive and I couldn't add one day through Vue
    public DateTime calendarEndDate { get; set; }
    public int program { get; set; }
    public string programName { get; set; }

    public List<UserModel> members {get;set;}  = new List<UserModel>();
    public List<MembershipModel> memberships {get;set;} = new List<MembershipModel>();
    public List<UserModel> interns {get;set;} = new List<UserModel>();
    public List<EventsModel> events {get;set;} = new List<EventsModel>();
    
    public static EditionDTO ConvertModel2DTO(EditionModel edition)
    {
        EditionDTO aux = new EditionDTO();
        aux.id = edition.id;
        aux.name = edition.name;
        aux.numberOfInterns = edition.numberOfInterns;

        foreach (var item in edition.members)
        {
            //edition.members.Add(item)
            aux.members.Add(item);
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
}
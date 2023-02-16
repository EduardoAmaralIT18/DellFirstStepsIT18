namespace ConnectDellBack.DTOs;
using ConnectDellBack.Models;
public class EditionDTO
{
    public int id { get; set; }
    public string name { get; set; } = null!;
    public int numberOfInterns { get; set; }
    public string description { get; set; }
    public string curriculum { get; set; }
    public int mode { get; set; }
    public DateTime startDate { get; set; }
    public DateTime? endDate { get; set; }
    public int program { get; set; }
    public string programName { get; set; }

    public List<UserModel> members {get;set;}  = new List<UserModel>();
    public List<MembershipModel> memberships {get;set;} = new List<MembershipModel>();
    public List<UserModel> interns {get;set;} = new List<UserModel>();
    public List<PhasesModel> phases {get;set;} = new List<PhasesModel>();
    
    public static EditionDTO convertModel2DTO(EditionModel edition)
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
        aux.program = edition.program.id;
        aux.programName = edition.program.name;
        return aux;
    }

    public static EditionDTO convertModel2DTOJustName (EditionModel edition) {
        EditionDTO aux = new EditionDTO();
        aux.name = edition.name;
        return aux;
    }
}
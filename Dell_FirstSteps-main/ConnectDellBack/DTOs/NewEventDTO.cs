namespace ConnectDellBack.DTOs;
using ConnectDellBack.Models;

public class NewEventDTO
{ 
    public int id {get;set;}
    public string name {get;set;} = null!;
    public int eventType {get; set;}
    public int phaseType {get;set;}
    public DateTime startDate {get;set;}
    public DateTime endDate {get;set;}
    public DateTime calendarEndDate {get; set;}
    public string where {get;set;} = null!;
    public int editionID {get;set;}
    public List<UserDTO> peopleInvolved {get;set;} = new List<UserDTO>();

    public static NewEventDTO ConvertModel2DTO(EventsModel evnt)
    {
        NewEventDTO aux = new NewEventDTO();
        if (evnt != null)
        {
            aux.id = evnt.id;
            aux.name = evnt.name;
            aux.phaseType = (int)evnt.phaseType;
            aux.eventType = (int)evnt.eventType;
            aux.startDate = evnt.startDate;
            aux.endDate = evnt.endDate;
            aux.where = evnt.where;
            aux.calendarEndDate = evnt.endDate.AddDays(1);

            List<UserDTO> aux2 = new List<UserDTO>();
            if (evnt.peopleInvolved != null)
            {
                foreach (var p in evnt.peopleInvolved)
                {
                    aux2.Add(UserDTO.ConvertToDTO(p));
                }
                aux.peopleInvolved = aux2;

            }

            return aux;
        }

        return null;


    }

}

namespace ConnectDellBack.DTOs;
using ConnectDellBack.Models;

public class EventDTO
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
    public List<UserModel> peopleInvolved {get;set;} = new List<UserModel>();

    public static EventDTO ConvertModel2DTO(EventsModel evnt)
    {
        EventDTO aux = new EventDTO();
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

            List<UserModel> aux2 = new List<UserModel>();
            if (evnt.peopleInvolved != null)
            {
                foreach (var p in evnt.peopleInvolved)
                {
                    aux2.Add(p);
                }
                aux.peopleInvolved = aux2;

            }

            return aux;
        }

        return null;


    }

}

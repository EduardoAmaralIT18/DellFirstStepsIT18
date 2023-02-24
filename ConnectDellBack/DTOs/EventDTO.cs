namespace ConnectDellBack.DTOs;
using ConnectDellBack.Models;

public class EventDTO
{ 
    public int id {get;set;}
    public string name {get;set;} = null!;
    public EventType eventType {get;set;}
    public PhaseType phaseType {get;set;}
    public DateTime startDate {get;set;}
    public DateTime endDate {get;set;}
    public DateTime calendarEndDate {get; set;}
    public string where {get;set;} = null!;
    public int editionID {get;set;} 
    public List<UserModel> peopleInvolved {get;set;} = new List<UserModel>();

    public static EventDTO convertModel2DTO(EventsModel evnt) {
        EventDTO aux = new EventDTO();
        aux.id = evnt.id;
        aux.name = evnt.name;
        aux.phaseType = evnt.phaseType;
        aux.eventType = evnt.eventType;
        aux.startDate = evnt.startDate;
        aux.endDate = evnt.endDate;
        aux.calendarEndDate = evnt.endDate.AddDays(1);
        aux.where = evnt.where;

        List<UserModel> aux2 = new List<UserModel>();
        foreach(var p in evnt.peopleInvolved) {
            aux2.Add(p);
        }
        aux.peopleInvolved = aux2;
        return aux;
    }

}

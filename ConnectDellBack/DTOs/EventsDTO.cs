using ConnectDellBack.Models;

namespace ConnectDellBack.DTOs
{
    public class EventsDTO 
    {
       public int id;
       public int editionId;
       public int PhaseType;
       public int EventType;
       public string name;
       public DateTime startDate;

        public DateTime? endDate;
        public string? where;
        public List<int> peopleInvolved;

        public static EventsDTO ConvertModel2DTO(EventsModel model){
            
            EventsDTO aux = new EventsDTO();

            aux.id = model.id;
            aux.editionId = model.edition.id;
            aux.PhaseType = (int)model.phaseType;
            aux.EventType = (int)model.eventType;
            aux.name = model.name;
            aux.startDate = model.startDate;
            aux.where = model.where;
            foreach (UserModel member in model.peopleInvolved){
                aux.peopleInvolved.Add(member.id); 
            }
        }
    }
}
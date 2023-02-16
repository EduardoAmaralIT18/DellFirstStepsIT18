using ConnectDellBack.Models;

namespace ConnectDellBack.DTOs
{
    public class EventsDTO 
    {
       public int id;
       public int editionId;
       public string PhaseType;
       public int EventType;
       public string name;
       public DateTime startDate;

        public DateTime? endDate;
        public string? where;
        public int peopleInvolved;

        public static EventsDTO ConvertModel2DTO(EventsModel model){
            
            EventsDTO aux = new EventsDTO();

            aux.id = model.id;
            aux.editionId = model.edition.id;
            switch (model.phaseType){
                case 0:

                    aux.PhaseType = "Set Up";
                    break;
                case 1:
                    aux.PhaseType = "Training";
                    break;
            }
        }
    }
}
using ConnectDellBack.DTOs;
using ConnectDellBack.Models;

namespace ConnectDellBack.Services
{
    public interface IEventService
    {
       public Task<int> AddEvent(EventDTO events);
        //update
        public Task<int> UpdateEvent(EventsModel eventsForm);

        //get pro formulario
        public Task<EventsModel> GetEventToUpdate(int eventId);

        //Pega todos os eventos de uma edição especifica.
        public Task<IEnumerable<EventDTO>> GetAllEvents(int editionId);

    }


}
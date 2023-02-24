using ConnectDellBack.DTOs;
using ConnectDellBack.Models;

namespace ConnectDellBack.Services
{
    public interface IEventService
    {
       public Task<int> addEvent(EventDTO events);
       public Task<int> removeEvent(int events);
        //update
        public Task<int> updateEvent(EventsModel eventsForm);

        //get pro formulario
        public Task<EventDTO> getEvent(int eventId);

        //Pega todos os eventos de uma edição especifica.
        public Task<IEnumerable<EventDTO>> getAllEvents(int editionId);

    }


}
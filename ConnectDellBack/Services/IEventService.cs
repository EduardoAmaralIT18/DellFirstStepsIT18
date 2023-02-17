using ConnectDellBack.DTOs;
using ConnectDellBack.Models;

namespace ConnectDellBack.Services
{
    public interface IEventService
    {
        //update
        public Task<int> updateEvent(EventsModel eventsForm);

        //get pro formulario
        public Task<EventDTO> getEvent(int eventId);

    }

}
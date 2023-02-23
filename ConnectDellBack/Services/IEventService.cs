using ConnectDellBack.DTOs;
using ConnectDellBack.Models;

namespace ConnectDellBack.Services
{
    public interface IEventService
    {
        //update
        public Task<int> updateEvent(EventsModel eventsForm);

        //get pro formulario
        public Task<EventsModel> getEvent(int eventId);

        public Task<int> addEvent(EventDTO events);

    }

}
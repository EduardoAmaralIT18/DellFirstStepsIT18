using ConnectDellBack.DTOs;
using ConnectDellBack.Models;

namespace ConnectDellBack.Services
{
    public interface IEventService
    {
       public Task<int> addEvent(EventsDTO events);
       public Task<int> removeEvent(int idEvent);

    }


}
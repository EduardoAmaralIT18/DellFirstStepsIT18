using ConnectDellBack.DTOs;
using ConnectDellBack.Models;

namespace ConnectDellBack.Services
{
    public interface IEventService
    {
       public Task<int> addEvent(EventDTO events);
       public Task<int> removeEvent(int events);
    }


}
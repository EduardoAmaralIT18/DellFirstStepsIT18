using ConnectDellBack.Models;

using ConnectDellBack.DTOs;
namespace ConnectDellBack.Services;

public interface IEventService
{
    public Task<IEnumerable<EventsDTO>> GetEventsByEditionId(int id);
}
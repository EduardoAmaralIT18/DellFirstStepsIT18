using Microsoft.EntityFrameworkCore;
using ConnectDellBack.Models;
using ConnectDellBack.DTOs;

namespace ConnectDellBack.Services;

public class EventService : IEventService
{
    private readonly ApplicationContext _dbContext;
    public EventService(ApplicationContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<int> addEvent(EventsModel events)
    {
        for (int i = 0; i < events.peopleInvolved.Count; i++)
        {
            var user = _dbContext.users.Where(usr => usr.id == events.peopleInvolved[i].id).FirstOrDefault();
            events.peopleInvolved[i] = user;
        }
        await _dbContext.events.AddAsync(events);
        int entries = await _dbContext.SaveChangesAsync();
        return entries;
    }

}
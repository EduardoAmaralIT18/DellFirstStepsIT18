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

    public async Task<int> addEvent(EventDTO events)
    {
        for (int i = 0; i < events.peopleInvolved.Count; i++)
        {
            var user = _dbContext.users.Where(usr => usr.id == events.peopleInvolved[i].id).FirstOrDefault();
            events.peopleInvolved[i] = user;
        }

        var dbEvent = new EventsModel()
        {
            name = events.name,
            eventType = (EventType)(int)events.eventType,
            phaseType = (PhaseType)(int)events.phaseType,
            startDate = events.startDate,
            endDate = events.endDate,
            where = events.where,
            peopleInvolved = events.peopleInvolved,
            edition = _dbContext.editions.Where(edition => edition.id == events.editionID).FirstOrDefault(),
        };

        await _dbContext.events.AddAsync(dbEvent);
        int entries = await _dbContext.SaveChangesAsync();

        return entries;
    }

}
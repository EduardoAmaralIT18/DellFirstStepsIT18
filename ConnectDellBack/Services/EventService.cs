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

    public async Task<EventDTO> getEvent(int eventId)
    {
        var calendarEvent = await _dbContext.events.Where(e => e.id == eventId)
                                                    .Include(e => e.peopleInvolved)
                                            .FirstOrDefaultAsync();
        return EventDTO.convertModel2DTO(calendarEvent);
    }

    public async Task<int> updateEvent(EventsModel eventsForm)
    {
        var eventFromDb = await _dbContext.events.Where(e => e.id == eventsForm.id)
                                            .Include(e => e.peopleInvolved)
                                            .FirstOrDefaultAsync();

        if (eventFromDb != null)
        {
            eventFromDb.name = eventsForm.name;
            eventFromDb.phaseType = eventsForm.phaseType;
            eventFromDb.eventType = eventsForm.eventType;
            eventFromDb.startDate = eventsForm.startDate;
            eventFromDb.endDate = eventsForm.endDate;
            eventFromDb.where = eventsForm.where;

            List<UserModel> peopleInvolvedAux = new List<UserModel>();

            foreach (var item in eventFromDb.peopleInvolved)
            {
                peopleInvolvedAux.Add(await _dbContext.users.Where(user => user.id == item.id).FirstOrDefaultAsync());
            }
            eventFromDb.peopleInvolved.Clear();
            eventFromDb.peopleInvolved.AddRange(peopleInvolvedAux);

            int entries = await _dbContext.SaveChangesAsync();
            return 1;
        } else
        {
            return 0;
        }
    }
}

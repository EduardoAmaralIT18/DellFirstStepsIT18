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

    public async Task<int> AddEvent(EventDTO events)
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

    public async Task<EventsModel> GetEventToUpdate(int eventId)
    {
        var calendarEvent = await _dbContext.events.Where(e => e.id == eventId)
                                                    .Include(e => e.peopleInvolved)   
                                                    .Include(e => e.participations)
                                                    .ThenInclude(u => u.participant)
                                                    .FirstOrDefaultAsync();
        return calendarEvent;
    }

    public async Task<int> UpdateEvent(EventsModel eventsForm)
    {
        var eventFromDb = await _dbContext.events.Where(e => e.id == eventsForm.id)
                                            .Include(e => e.peopleInvolved)
                                            .Include(e => e.participations)
                                            .FirstOrDefaultAsync();

        if (eventFromDb != null)
        {
            eventFromDb.name = eventsForm.name;
            eventFromDb.phaseType = eventsForm.phaseType;
            eventFromDb.eventType = eventsForm.eventType;
            eventFromDb.startDate = eventsForm.startDate;
            eventFromDb.endDate = eventsForm.endDate;
            eventFromDb.where = eventsForm.where; 
            eventFromDb.peopleInvolved.Clear();

            List<UserModel> peopleInvolvedAux = new List<UserModel>();

            foreach (var item in eventsForm.peopleInvolved)
            {
                peopleInvolvedAux.Add(await _dbContext.users.Where(user => user.id == item.id).FirstOrDefaultAsync());
            }
           
            eventFromDb.peopleInvolved.AddRange(peopleInvolvedAux);

            int entries = await _dbContext.SaveChangesAsync();
            return 1;
        } else
        {
            return 0;
        }
    }

    

    public async Task<IEnumerable<EventDTO>> GetAllEvents(int editionId) {
        EventsModel[]? eventFromDb = null;

        eventFromDb = await _dbContext.events.Where(ev => ev.edition.id == editionId)
                                                 //.FirstOrDefaultAsync();
                                                 .ToArrayAsync<EventsModel>();
        List<EventDTO> aux = new List<EventDTO>();

        if (eventFromDb == null) {
            aux = null;
            return aux;
        } else {
        
            foreach (var item in eventFromDb)
            {
                aux.Add(EventDTO.ConvertModel2DTO(item));
            }
        
            return aux;
        }

    }
}

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


}
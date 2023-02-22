using Microsoft.AspNetCore.Mvc;
using ConnectDellBack.Services;
using ConnectDellBack.DTOs;
using ConnectDellBack.Models;

namespace ConnectDellBack.Controllers;

[ApiController]
[Route("[controller]")]
public class EventController : ControllerBase
{

    private readonly ILogger<EventController> _logger;
    private readonly IEventService _service;

    public EventController(ILogger<EventController> logger, IEventService service)
    {
        _logger = logger;
        _service = service;
    }

    [HttpPost("addEvent")]
    public async Task<ActionResult> addEvent(EventsDTO events)
    {
        int entries = await _service.addEvent(events);
        if (entries > 0)
        {
            return Ok();
        }
        else
        {
            return NotFound();
        }
    }

   
    

}
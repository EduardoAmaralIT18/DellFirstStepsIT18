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

    [HttpGet("getEventToUpdate")]
    public async Task<ActionResult<EventDTO>> getEventToUpdate(int eventId)
    {
        var result = await _service.getEvent(eventId);
        return result == null ? NoContent() : Ok(result);
    }

    [HttpPost("updateEvent")] 
    public async Task<ActionResult> updateEvent(EventsModel eventForm) {
        int entries = await _service.updateEvent(eventForm);
        if (entries > 0) {
            return Ok();
        } else {
            return NotFound();
        }
    }

    [HttpGet("getAllEvents")]
    public async Task<ActionResult<IEnumerable<EventDTO>>> getAllEvents(int editionId) {
        var result = await _service.getAllEvents(editionId);
        return result == null ? NoContent() : Ok(result);
    }

}
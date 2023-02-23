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
        EventDTO eventDTO = EventDTO.convertModel2DTO(result);
        return result == null ? NotFound() : Ok(eventDTO);
    }

    [HttpPost("updateEvent")]
    public async Task<ActionResult> updateEvent(EventsModel eventForm)
    {
        int entries = await _service.updateEvent(eventForm);
        if (entries > 0)
        {
            return Ok();
        }
        else
        {
            return NotFound();
        }
    }


    [HttpPost("addEvent")]
    public async Task<ActionResult> addEvent(EventDTO events)
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
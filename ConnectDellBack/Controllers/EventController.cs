using Microsoft.AspNetCore.Mvc;
using ConnectDellBack.Services;
using ConnectDellBack.DTOs;
using ConnectDellBack.Models;
using System.Collections.Generic;

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

    [HttpGet("removeEvent")]
    public async Task<ActionResult> removeEvent(int evnt)
    {
        var entries = await _service.removeEvent(evnt);
        if (entries > 0)
        {
            return Ok();
        }
        else
        {
            return NotFound();
        }
    }
    [HttpGet("getEventToUpdate")]
    public async Task<ActionResult<EventDTO>> getEventToUpdate(int eventId)
    {
        var result = await _service.getEvent(eventId);
        return result == null ? NoContent() : Ok(result);
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

    [HttpGet("getAllEvents")]
    public async Task<ActionResult<IEnumerable<EventDTO>>> getAllEvents(int editionId)
    {
        var result = await _service.getAllEvents(editionId);

        if (result.Count() > 0)
        {
            return Ok(result);
        }
        else if (result.Count() == 0)
        {
            return NoContent();
        }
        else
        {
            return BadRequest();

        }
    }

}
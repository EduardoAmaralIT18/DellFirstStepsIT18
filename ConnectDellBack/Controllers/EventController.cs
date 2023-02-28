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
    public async Task<ActionResult> AddEvent(EventDTO events)
    {
        int entries = await _service.AddEvent(events);
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
    public async Task<ActionResult<EventDTO>> GetEventToUpdate(int eventId)
    {
        var result = await _service.GetEventToUpdate(eventId);
        EventDTO eventDTO = EventDTO.ConvertModel2DTO(result);
        return result == null ? NotFound() : Ok(eventDTO);
    }

    [HttpPost("updateEvent")]
    public async Task<ActionResult> UpdateEvent(EventsModel eventForm)
    {
        int entries = await _service.UpdateEvent(eventForm);
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
    public async Task<ActionResult<IEnumerable<EventDTO>>> GetAllEvents(int editionId)
    {
        var result = await _service.GetAllEvents(editionId);

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
using Microsoft.AspNetCore.Mvc;
using ConnectDellBack.Services;
using ConnectDellBack.DTOs;
using ConnectDellBack.Models;

namespace ConnectDellBack.Controllers;

[ApiController]
[Route("[controller]")]
public class EditionController : ControllerBase
{
    private readonly ILogger<EditionController> _logger;
    private readonly IEditionService _service;

    public EditionController(ILogger<EditionController> logger, IEditionService service)
    {
        _logger = logger;
        _service = service;
    }

    [HttpPost("addEdition")]
    public async Task<ActionResult> AddEdition(EditionDTO edition)
    {
        int entries = await _service.AddEdition(edition);
        if (entries > 0)
        {
            return Accepted();
        }
        else
        {
            return BadRequest();
        }
    }

    [HttpPost("updateEdition")]
    public async Task<ActionResult> UpdateEdition(EditionModel editionForm)
    {
        int entries = await _service.UpdateEdition(editionForm);
        if (entries > 0)
        {
            return Accepted();
        }
        else
        {
            return BadRequest();
        }
    }

    [HttpGet("showInfoEdition")]
    public async Task<ActionResult<EditionDTO>> ShowInfoEdition(int idProgram, int idEdition)
    {
        var result = await _service.GetEditionInfo(idProgram, idEdition);
        return result == null ? NotFound() : Ok(result);
    }

    [HttpGet("getUsersNotAdmin")]
    public async Task<ActionResult<UserDTO>> GetUsersNotAdmin()
    {
        var result = await _service.GetUsersNotAdmin();
        return result == null ? NoContent() : Ok(result);
    }

    [HttpGet("getEditionsNames")]
    public async Task<ActionResult<EditionDTO>> GetEditionsNames(int idProgram)
    {
        var result = await _service.AllEditions(idProgram);
        return result == null ? NoContent() : Ok(result);
    }
}
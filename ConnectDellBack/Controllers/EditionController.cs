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
    public async Task<ActionResult> addEdition(EditionDTO edition)
    {
        int entries = await _service.addEdition(edition);
        if (entries > 0)
        {
            return Ok();
        }
        else
        {
            return NotFound();
        }
    }

    [HttpPost("updateEdition")] 
    public async Task<ActionResult> updateEdition(EditionModel editionForm) {
        int entries = await _service.updateEdition(editionForm);
        if (entries > 0) {
            return Ok();
        } else {
            return NotFound();
        }
    }


    [HttpGet("showInfoEdition")]
    public async Task<ActionResult<EditionDTO>> showInfoEdition(int idProgram, int idEdition)
    {
        var result = await _service.getEditionInfo(idProgram, idEdition);
        return result == null ? NoContent() : Ok(result);
    }

    //GetUsers que não são admins. 
    [HttpGet("getUsersNotAdmin")]
    public async Task<ActionResult<UserDTO>> getUsersNotAdmin() {
        var result = await _service.getUsersNotAdmin();
        return result == null ? NoContent() : Ok(result);
    }

    [HttpGet("getEditionsNames")]
    public async Task<ActionResult<EditionDTO>> getEditionsNames(int idProgram) {
         var result = await _service.allEditions(idProgram);
        return result == null ? NoContent() : Ok(result);
    }

    

}
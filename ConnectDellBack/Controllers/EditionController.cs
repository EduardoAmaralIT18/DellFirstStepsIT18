using Microsoft.AspNetCore.Mvc;
using ConnectDellBack.Services;
using ConnectDellBack.DTOs;
using ConnectDellBack.Models;

namespace ConnectDellBack.Controllers;

[ApiController]
[Route("[controller]")]
public class EditionController : ControllerBase{

    private readonly ILogger<EditionController> _logger;
    private readonly IEditionService _service;

    public EditionController(ILogger<EditionController> logger, IEditionService service)
    {
        _logger = logger;
        _service = service;
    }

    ///// GRUPO 4 ////
   /* [HttpGet("GetPrograms")]
    public async Task<ActionResult<ProgramDTO>> GetPrograms(int idUser,int role)
    {
        var result = await _service.GetPrograms(idUser, role);
        return result == null ? NotFound() : Ok(result);
    }
*/
    [HttpPost("addEdition")]
    public async Task<ActionResult> addEdition(EditionDTO edition) {        
        int entries = await _service.addEdition(edition);
        if (entries > 0) {
            return Ok();
        } else {
            return NotFound();
        }
    }



}
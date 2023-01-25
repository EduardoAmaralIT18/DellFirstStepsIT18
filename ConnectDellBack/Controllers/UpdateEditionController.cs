using Microsoft.AspNetCore.Mvc;
using ConnectDellBack.Services;
using ConnectDellBack.DTOs;
using ConnectDellBack.Models;

namespace ConnectDellBack.Controllers;

[ApiController]
[Route("[controller]")]

public class UpdateEditionController : ControllerBase {

    private readonly ILogger<UpdateEditionController> _logger;
    private readonly IUpdateEditionService _service;

    public UpdateEditionController(ILogger<UpdateEditionController> logger, IUpdateEditionService service)
    {
        _logger = logger;
        _service = service;
    }

    [HttpPost("UpdateEdition")]
    public async Task<ActionResult> addEdition(EditionDTO edition) {
        int entries = await _service.addEdition(edition);
        if (entries > 0) {
            return Ok();
        } else {
            return NotFound();
        }
    }


}
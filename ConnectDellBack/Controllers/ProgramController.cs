using Microsoft.AspNetCore.Mvc;
using ConnectDellBack.Services;
using ConnectDellBack.DTOs;

namespace ConnectDellBack.Controllers;

[ApiController]
[Route("[controller]")]
public class ProgramController : ControllerBase
{
    private readonly ILogger<ProgramController> _logger;
    private readonly IProgramService _service;

    public ProgramController(ILogger<ProgramController> logger, IProgramService service)
    {
        _logger = logger;
        _service = service;
    }

    [HttpGet("GetPrograms")]
    public async Task<ActionResult<ProgramDTO>> GetPrograms(int idUser, string role)
    {
        var result = await _service.GetPrograms(idUser, role);
        return result == null ? NotFound() : Ok(result);
    }
}
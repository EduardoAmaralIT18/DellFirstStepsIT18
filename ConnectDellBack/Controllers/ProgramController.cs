using Microsoft.AspNetCore.Mvc;
using ConnectDellBack.Services;
using ConnectDellBack.DTOs;
using ConnectDellBack.Models;

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
    public async Task<ActionResult<ProgramDTO>> GetPrograms(int idUser,int role)
    {
        var result = await _service.GetPrograms(idUser, role);
        return result == null ? NotFound() : Ok(result);
    }

    [HttpPost("addProgram")]
    public async Task<ActionResult> addProgram(ProgramModel program) {
        int entries = await _service.addProgram(program);
        if (entries > 0) {
            return Ok();
        } else {
            return NotFound();
        }
    }

    [HttpGet("showInfoProgram")]
    public async Task<ActionResult<ProgramInfoDTO>> showInfoProgram(int id1, int idUser) {
        var result = await _service.getProgramInfo(id1, idUser);
        return result == null ? NoContent() : Ok(result);
    }

    [HttpGet("showBasicInfo")]
    public async Task<ActionResult<ProgramInfoDTO>> showBasicInfo(int id1) {
        var result = await _service.getProgramInfoNoPermission(id1);
        return result;
    }

}
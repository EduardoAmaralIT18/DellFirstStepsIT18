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

    [HttpGet("getPrograms")]
    public async Task<ActionResult<ProgramDTO>> GetPrograms(int idUser, int role)
    {
        var result = await _service.GetPrograms(idUser, role);
        return result == null ? NotFound() : Ok(result);
    }

    [HttpPost("addProgram")]
    public async Task<ActionResult> AddProgram(ProgramModel program)
    {
        int entries = await _service.AddProgram(program);
        if (entries > 0)
        {
            return Accepted();
        }
        else
        {
            return BadRequest();
        }
    }

    [HttpGet("showInfoProgram")]
    public async Task<ActionResult<ProgramInfoDTO>> ShowInfoProgram(int id, int userId)
    {
        var result = await _service.GetProgramInfo(id, userId);
        return result == null ? NoContent() : Ok(result);
    }

    [HttpGet("showBasicInfo")]
    public async Task<ActionResult<ProgramInfoDTO>> ShowBasicInfo(int id)
    {
        var result = await _service.GetProgramInfoNoPermission(id);
        return result == null ? NoContent() : Ok(result);
    }

    [HttpPost("updateProgram")]
    public async Task<ActionResult> UpdateProgram(ProgramModel program)
    {
        int entries = await _service.UpdateProgram(program);
        return entries > 0 ? Ok() : BadRequest();
    }

    [HttpGet("getProgram")]
    public async Task<ActionResult<ProgramModel>> GetProgram(int id)
    {
        var result = await _service.GetProgram(id);
        return result == null ? NotFound() : Ok(result);
    }

    [HttpGet("getProgramsName")]
    public async Task<ActionResult<IEnumerable<ProgramInfoDTO>>> GetProgramsName()
    {
        var result = await _service.GetProgramsName();
        return result == null ? NoContent() : Ok(result);
    }
}
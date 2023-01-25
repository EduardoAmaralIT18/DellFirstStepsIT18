using Microsoft.AspNetCore.Mvc;
using ConnectDellBack.Services;
using ConnectDellBack.Models;
using ConnectDellBack.DTOs;

namespace ConnectDellBack.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly ILogger<UserController> _logger;
    private readonly IUserService _service;

    public UserController(ILogger<UserController> logger, IUserService service)
    {
        _logger = logger;
        _service = service;
    }

    [HttpGet("GetOwners")]
    public IEnumerable<UserModel> GetOwners()
    {
        var owners = _service.GetOwners();
        // var ownersDTO = new List<OwnerDTO>();
        // foreach(var item in owners) {
        //     ownersDTO.Add(OwnerDTO.convertModel2DTO(item));
        // }
        return owners;
    }

    // [HttpPost("createProgram")]
    // public async Task<ActionResult<string>> createProgram(ProgramModel program) {

    // }
}
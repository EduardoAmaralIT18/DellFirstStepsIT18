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


    [HttpGet("listUsers")]
    public async Task<ActionResult<IEnumerable<UserDTO>>> ListUsers()
    {
        var list = await _service.listUsers();
        var listUser = new List<UserDTO>();
        foreach (var item in list)
        {
            listUser.Add(UserDTO.convertToDTO(item));
        }
        return listUser == null ? NotFound() : Ok(listUser);
    }
}

    // [HttpPost("createProgram")]
    // public async Task<ActionResult<string>> createProgram(ProgramModel program) {

    // }

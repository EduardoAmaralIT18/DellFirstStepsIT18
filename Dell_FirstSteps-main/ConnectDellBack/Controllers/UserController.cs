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

    [HttpGet("getOwners")]
    public IEnumerable<UserModel> GetOwners()
    {
        var owners = _service.GetOwners();
        return owners;
    }

    [HttpGet("listUsers")]
    public async Task<ActionResult<IEnumerable<UserDTO>>> ListUsers()
    {
        var list = await _service.ListUsers();
        var listUser = new List<UserDTO>();
        foreach (var item in list)
        {
            listUser.Add(UserDTO.ConvertToDTO(item));
        }
        return listUser == null ? NotFound() : Ok(listUser);
    }

    [HttpGet("changeRole")]
    public async Task<ActionResult> ChangeRole(int user, int role)
    {
        var entries = await _service.ChangeRole(user, role);
        if (entries > 0)
        {
            return Ok();
       }
        else
        {
            return NotFound();
        }
    }

    [HttpGet("removeUser")]
    public async Task<ActionResult> RemoveUser(int user)
    {
        var entries = await _service.RemoveUser(user);
        if (entries > 0)
        {
            return Ok();
        }
        else
        {
            return NotFound();
        }
    }
}
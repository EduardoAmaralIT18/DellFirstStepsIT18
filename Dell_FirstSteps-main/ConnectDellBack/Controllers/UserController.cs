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

    [HttpPatch("changeRole")]
    public async Task<ActionResult> ChangeRole(int userId, int role)
    {
        try
        {
            var updatedUser = await _service.ChangeRole(userId, role);
            return Ok(UserDTO.ConvertToDTO(updatedUser));
        }
        catch
        {
            return BadRequest();
        }
    }

    [HttpDelete("removeUser/{id}")]
    public async Task<ActionResult> RemoveUser(int id)
    {
        try
        {
            await _service.RemoveUser(id);
            return Ok();
        }
        catch
        {
            return NotFound();
        }
    }
}
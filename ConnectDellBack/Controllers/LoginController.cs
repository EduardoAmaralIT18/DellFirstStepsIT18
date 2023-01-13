using Microsoft.AspNetCore.Mvc;
using ConnectDellBack.Services;
using ConnectDellBack.Models;

namespace ConnectDellBack.Controllers;

[ApiController]
[Route("[controller]")]
public class LoginController : Controller{
    private readonly ILogger<LoginController> logger;
    private readonly IUserService user;

    public LoginController(ILogger<LoginController> _logger, IUserService _user){
        logger = _logger;
        user = _user;
    }

    [Route("getUserList")]
    [HttpGet("getUserList")]
    public IEnumerable<UserModel> GetAllUsers()
    {
        var list = user.listUsers();
        return list;
    }
    
}
using Microsoft.AspNetCore.Mvc;
using ConnectDellBack.Services;
using ConnectDellBack.DTOs;
using ConnectDellBack.Models;

namespace ConnectDellBack.Controllers;

[ApiController]
[Route("[controller]")]
public class EventController : ControllerBase
{

    private readonly ILogger<EditionController> _logger;
    private readonly IEditionService _service;

    public EventController(ILogger<EditionController> logger, IEditionService service)
    {
        _logger = logger;
        _service = service;
    }


   
    

}
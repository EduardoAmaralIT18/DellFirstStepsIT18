using Microsoft.AspNetCore.Mvc;
using ConnectDellBack.Services;
using ConnectDellBack.Models;
using ConnectDellBack.DTOs;

namespace ConnectDellBack.Controllers;

[ApiController]
[Route("[controller]")]
public class NewsController : ControllerBase
{
    private readonly ILogger<NewsController> _logger;
    private readonly INewsService _newsService;

    public NewsController(ILogger<NewsController> logger, INewsService newsService)
    {
        _logger = logger;
        _newsService = newsService;
    }

    [HttpGet("getNews")]
    public async Task<ActionResult<IEnumerable<NewsDTO>>> GetNews()
    {
        //abacaxi
        var news = await _newsService.getNews();

        var newsDTO = new List<NewsDTO>();
        foreach (var item in news)        
        {
            newsDTO.Add(NewsDTO.convertModel2DTO(item));            
        }

        return news == null ? NotFound() : Ok(newsDTO);
    }

    [HttpPost("addContent")]
    public async Task<ActionResult> AddContent([FromForm] ContentDTO content){
        Console.WriteLine(content.author);
        Console.WriteLine(content.program);
        Console.WriteLine(content.title);
        Console.WriteLine(content.text);
        Console.WriteLine(content.imageName);
        Console.WriteLine(content.image);

        return Ok();

    }
}
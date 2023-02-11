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
        var news = await _newsService.getNews();

        var newsDTO = new List<NewsDTO>();
        foreach (var item in news)
        {
            newsDTO.Add(NewsDTO.convertModel2DTO(item));
        }

        return news == null ? NotFound() : Ok(newsDTO);
    }

    [HttpPost("addContent")]
    public async Task<ActionResult> AddContent([FromForm] ContentDTO content)
    {
        // var cookies = Request.Cookies;

        // if (cookies["role"].Equals("0"))
        // {
        var result = await _newsService.addContent(content);

        if (result)
        {
            return Ok();
        }
        else
        {
            return NotFound();
        }
        // }
        // else
        // {
        //     return BadRequest();
        // }
    }

    [HttpGet("getSpecificNews")]
    public async Task<ActionResult<NewsDTO>> GetSpecificNews(int id)
    {
        var news = await _newsService.getSpecificNews(id);
        NewsDTO newsDTO = NewsDTO.convertModel2DTO(news);
        return news == null ? NotFound() : Ok(newsDTO);
    }

    [HttpPost("updateNews")]
    public async Task<ActionResult> UpdateNews([FromForm] ContentDTO contentForm)
    {
        var result = await _newsService.updateNews(contentForm);

        if (result)
        {
            return Ok();
        }
        else
        {
            return NotFound();
        }
    }
}
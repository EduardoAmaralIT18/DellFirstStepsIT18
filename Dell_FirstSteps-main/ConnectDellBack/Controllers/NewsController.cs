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
        var news = await _newsService.GetNews();

        var newsDTO = new List<NewsDTO>();
        foreach (var item in news)
        {
            newsDTO.Add(NewsDTO.ConvertModel2DTO(item));
        }

        return news == null ? NoContent() : Ok(newsDTO);
    }

    [HttpPost("addContent")]
    public async Task<ActionResult> AddContent([FromForm] ContentDTO content)
    {
        var result = await _newsService.AddContent(content);

        if (result)
        {
            return Accepted();
        }
        else
        {
            return BadRequest();
        }
    }

    [HttpGet("getSpecificNews")]
    public async Task<ActionResult<NewsDTO>> GetSpecificNews(int id)
    {
        var news = await _newsService.GetSpecificNews(id);
        NewsDTO newsDTO = NewsDTO.ConvertModel2DTO(news);
        return news == null ? NotFound() : Ok(newsDTO);
    }

    [HttpPost("updateNews")]
    public async Task<ActionResult> UpdateNews([FromForm] ContentDTO contentForm)
    {
        var result = await _newsService.UpdateNews(contentForm);

        if (result)
        {
            return Accepted();
        }
        else
        {
            return BadRequest();
        }
    }
}
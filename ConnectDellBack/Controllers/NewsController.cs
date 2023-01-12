using Microsoft.AspNetCore.Mvc;
using ConnectDellBack.Services;
using ConnectDellBack.Models;

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

    [Route("getNews")]
    [HttpGet("getNews")]
    public async Task<ActionResult<IEnumerable<NewsModel>>> GetNews()
    {
        var news = await _newsService.getNews();
        return news == null ? NotFound() : Ok(news);
    }
}
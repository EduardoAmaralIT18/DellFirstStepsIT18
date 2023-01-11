using Microsoft.EntityFrameworkCore;
using ConnectDellBack.Models;

namespace ConnectDellBack.Services;

public class NewsService : INewsService
{
    private readonly ApplicationContext dbnews;

    public NewsService(ApplicationContext _dbnews){
        dbnews = _dbnews;
    }

    public async Task<IEnumerable<NewsModel>> getNews()
    {
        var news = await dbnews.news.Include(news => news.program)
                                    .Include(news => news.author)
                                    .OrderBy(news => news.date).ToListAsync();
        return news;
    }
}
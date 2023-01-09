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
        return await dbnews.news.OrderBy(news => news.date).ToListAsync();
    }
}
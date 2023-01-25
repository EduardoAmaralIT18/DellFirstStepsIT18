using Microsoft.EntityFrameworkCore;
using ConnectDellBack.Models;
using ConnectDellBack.DTOs;

namespace ConnectDellBack.Services;

public class NewsService : INewsService
{
    private readonly ApplicationContext dbnews;

    public NewsService(ApplicationContext _dbnews){
        dbnews = _dbnews;
    }

    public async Task<IEnumerable<NewsModel>> getNews()
    {
        //bananinha
        var news = await dbnews.news.Include(news => news.program)
                                    .Include(news => news.author)
                                    .OrderByDescending(news => news.date).ToListAsync();
        return news;
    }

    public async Task<int> addContent(ContentDTO content)
    {
        throw new NotImplementedException();
    }

}

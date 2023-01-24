using Microsoft.EntityFrameworkCore;
using ConnectDellBack.Models;
using ConnectDellBack.DTOs;

namespace ConnectDellBack.Services;

public class NewsService : INewsService
{
    private readonly ApplicationContext dbnews;

    public NewsService(ApplicationContext _dbnews)
    {
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

    public async Task<bool> addContent(ContentDTO content)
    {
        MemoryStream ms = new MemoryStream();
        content.image.CopyTo(ms);

        var image = new ImageModel()
        {
            imageTitle = content.imageName,
            imageData = ms.ToArray(),
        };

        await dbnews.images.AddAsync(image);

        var news = new NewsModel()
        {
            title = content.title,
            text = content.text,
            program = dbnews.programs.Where(prog => prog.id == content.program).FirstOrDefault(),
            author = dbnews.users.Where(user => user.id == content.author).FirstOrDefault(),
            date = DateTime.Now,
        };

        await dbnews.news.AddAsync(news);
        await dbnews.SaveChangesAsync();

        image.news = news;
        image.newsId = news.id;
        news.image = image;
        
        var task = await dbnews.SaveChangesAsync();
        if(task > 0){
            return true;
        } else {
            return false;
        }

    }
}
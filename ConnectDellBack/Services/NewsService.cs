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
                                    .Include(news => news.image)
                                    .OrderByDescending(news => news.date).ToListAsync();
        return news;
    }

    public async Task<NewsModel> getSpecificNews(int formId){

        var news = await dbnews.news.Include(news => news.program)
                                    .Include(news => news.author)
                                    .Include(news => news.image)
                                    .Where(news => news.id == formId).FirstOrDefaultAsync();

        return news;
    }

    public async Task<bool> addContent(ContentDTO content)
    {
        var news = new NewsModel()
        {
            title = content.title,
            text = content.text,
            program = dbnews.programs.Where(prog => prog.id == content.program).FirstOrDefault(),
            author = dbnews.users.Where(user => user.id == content.author).FirstOrDefault(),
            date = DateTime.Now,
        };

        await dbnews.news.AddAsync(news);
        var task = await dbnews.SaveChangesAsync();

        if (content.image is not null)
        {
            MemoryStream ms = new MemoryStream();
            await content.image.CopyToAsync(ms);

            if(ms.Length > 2097152) return false;

            var image = new ImageModel()
            {
                imageTitle = content.imageName,
                imageData = ms.ToArray(),
            };

            ms.Close();
            ms.Dispose();

            await dbnews.images.AddAsync(image);

            image.news = news;
            image.newsId = news.id;
            news.image = image;

            task = await dbnews.SaveChangesAsync();
        }

        if (task > 0)
        {
            return true;
        }
        else
        {
            return false;
        }

    }

    public async Task<bool> updateNews(ContentDTO contentForm){

        var news = dbnews.news.Where(news => news.id == contentForm.id).FirstOrDefault();

        if(news != null){
            news.title = contentForm.title;
            news.text = contentForm.text;

            var task = await dbnews.SaveChangesAsync();

            if (contentForm.image is not null)
                    {
                        news.image = null;
                        MemoryStream ms = new MemoryStream();
                        await contentForm.image.CopyToAsync(ms);

                        if(ms.Length > 2097152) return false;

                        var image = new ImageModel()
                        {
                            imageTitle = contentForm.imageName,
                            imageData = ms.ToArray(),
                        };

                        ms.Close();
                        ms.Dispose();

                        await dbnews.images.AddAsync(image);

                        image.news = news;
                        image.newsId = news.id;
                        news.image = image;
                        
                        task = await dbnews.SaveChangesAsync();
                }  

            if (task > 0){
                return true;
            } else {
                return false;
            }
        } else {
            return false;
        }
    }
} 
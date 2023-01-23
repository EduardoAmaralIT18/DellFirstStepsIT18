using ConnectDellBack.Models;

namespace ConnectDellBack.Services;

public interface INewsService
{
    public Task<IEnumerable<NewsModel>> getNews();   

    public Task<int> addContent(ContentModel content);
}
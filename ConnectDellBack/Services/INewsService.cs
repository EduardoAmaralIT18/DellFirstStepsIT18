using ConnectDellBack.Models;

using ConnectDellBack.DTOs;
namespace ConnectDellBack.Services;

public interface INewsService
{
    public Task<IEnumerable<NewsModel>> getNews();   
    public Task<NewsModel> getSpecificNews(int id);

    public Task<bool> addContent(ContentDTO content);

    public Task<bool> updateNews(ContentDTO contentForm);
}
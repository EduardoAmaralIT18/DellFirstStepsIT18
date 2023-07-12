using ConnectDellBack.Models;

using ConnectDellBack.DTOs;
namespace ConnectDellBack.Services;

public interface INewsService
{
    public Task<IEnumerable<NewsModel>> GetNews();
    public Task<NewsModel> GetSpecificNews(int id);

    public Task<bool> AddContent(ContentDTO content);

    public Task<bool> UpdateNews(ContentDTO contentForm);
}
using ConnectDellBack.Models;

namespace ConnectDellBack.Services;

public interface INewsService
{
    public Task<IEnumerable<NewsModel>> getNews();
  //  public showNewsId(String id); //mostrar o id de cada noticias

    
    
}

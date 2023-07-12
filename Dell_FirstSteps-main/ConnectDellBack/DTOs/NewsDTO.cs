using ConnectDellBack.Models;

namespace ConnectDellBack.DTOs;

public class NewsDTO
{
    public int id { get; set; }
    public string title { get; set; } = null!;
    public string text { get; set; } = null!;
    public string program { get; set; } = null!;
     public int programId { get; set; }
    public string author { get; set; } = null!;
    public int authorId { get; set; }
    public string image { get; set; }
    public string date { get; set; } = null!;

    public static NewsDTO ConvertModel2DTO(NewsModel news)
    {
        NewsDTO aux = new NewsDTO();
        aux.id = news.id;
        aux.title = news.title;
        aux.text = news.text;
        aux.program = news.program.name;
        aux.programId = news.program.id;
        aux.author = news.author.name;
        aux.authorId = news.author.id;
        if (news.image is not null)
        {
            string imageBase64Data = Convert.ToBase64String(news.image.imageData);
            aux.image = string.Format("data:image/jpg;base64,{0}", imageBase64Data);
        }
        aux.date = news.date.ToLongDateString() + " - " + news.date.ToShortTimeString();
        return aux;
    }

}
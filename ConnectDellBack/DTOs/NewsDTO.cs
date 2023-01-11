using ConnectDellBack.Models;

namespace ConnectDellBack.DTOs;

public class NewsDTO{

    public string title {get;set;} = null!;
    public string text {get;set;} = null!;

    public string program {get;set;} = null!;

    public string author {get; set;} = null!;

    public ImageModel? image {get; set;}

    public string date {get; set;} = null!;

    public static NewsDTO converteModel2DTO(NewsModel news){
        NewsDTO aux = new NewsDTO();
        aux.title = news.title;
        aux.text = news.text;
        aux.program = news.program.name;
        aux.author = news.author.name;
        aux.image = news.image;
        aux.date = news.date.ToLongDateString()+" - "+news.date.ToShortTimeString();
        return aux;
    }

}
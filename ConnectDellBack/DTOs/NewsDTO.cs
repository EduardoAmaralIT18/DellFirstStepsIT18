using ConnectDellBack.Models;

namespace ConnectDellBack.DTOs;

public class NewsDTO
{
    public string title { get; set; } = null!;
    public string text { get; set; } = null!;

    public string program { get; set; } = null!;

    public string author { get; set; } = null!;

    public string image { get; set; }

    public string date { get; set; } = null!;

    public static NewsDTO convertModel2DTO(NewsModel news)
    {
        //uhul obg alexya
        NewsDTO aux = new NewsDTO();
        aux.title = news.title;
        aux.text = news.text;
        aux.program = news.program.name;
        aux.author = news.author.name;
        aux.image = news.image.imageTitle;
        aux.date = news.date.ToLongDateString() + " - " + news.date.ToShortTimeString();
        return aux;
    }
    // public string getImage(int imageID)
    // {

    //     ImageModel? img = db.images.OrderByDescending(i => i.imageId)
    //                             .FirstOrDefault();

    //     if (img != null)
    //     {
    //         string imageBase64Data = Convert.ToBase64String(img.imageData);

    //         string imageDataURL =
    //             string.Format("data:image/jpg;base64,{0}", imageBase64Data);

    //         return imageDataURL;
    //     }

    //     return "";
    // }

}
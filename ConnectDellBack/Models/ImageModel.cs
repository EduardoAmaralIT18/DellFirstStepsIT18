using System.ComponentModel.DataAnnotations;

namespace ConnectDellBack.Models;
public class ImageModel
{
    public int id { get; set; }

    [Required]
    public string imageTitle { get; set; } = null!;
    [Required]
    public byte[] imageData { get; set; } = null!;

    public int newsId { get; set; }
    public NewsModel news {get; set;} = null!;

}
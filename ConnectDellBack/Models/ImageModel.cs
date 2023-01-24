using System.ComponentModel.DataAnnotations;

namespace ConnectDellBack.Models;
public class ImageModel
{
    //lelelel
    [Key]
    public int imageId { get; set; }

    [Required]
    public string imageTitle { get; set; }
    [Required]
    public byte[] imageData { get; set; }

    public int newsId { get; set; }
    public NewsModel news {get; set;}

}
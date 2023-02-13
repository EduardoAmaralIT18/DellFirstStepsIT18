using System.ComponentModel.DataAnnotations;

namespace ConnectDellBack.Models;

public class NewsModel
{

    public int id { get; set; }

    [Required]
    [StringLength(100, MinimumLength = 10, ErrorMessage = "The length of the news title should be at least 10 characters.")]
    public string title { get; set; } = null!;

    [Required]
    [StringLength(5000, MinimumLength = 10, ErrorMessage = "The length of the news text should be at least 10 characters.")]
    public string text { get; set; } = null!;
    public ProgramModel program { get; set; } = null!;

    public UserModel author { get; set; } = null!;

    public ImageModel? image { get; set; }

    public DateTime date { get; set; }
}

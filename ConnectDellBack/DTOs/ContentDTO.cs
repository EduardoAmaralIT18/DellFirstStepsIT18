namespace ConnectDellBack.DTOs;

public class ContentDTO{
    public string title { get; set; } = null!;
    public string text { get; set; } = null!;
    public string? imageName { get; set; }
    public IFormFile? image { get; set; }
    public int author { get; set; }
    public int program { get; set; }

}
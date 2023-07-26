using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace ConnectDellBack.DTOs;

public class ContentDTO{
    public int? id {get; set;}
    [Required]
    public string title { get; set; } = null!;
    [Required]
    public string text { get; set; } = null!;
    public string? imageName { get; set; }
    public IFormFile? image { get; set; }
    [Required]
    public int author { get; set; }
    [Required]
    public int program { get; set; }

}
using System.ComponentModel.DataAnnotations;

namespace ConnectDellBack.Models;

public class ProgramModel{

    public int id {get;set;}

    [Required]
    [StringLength(50, MinimumLength = 5, ErrorMessage = "The program's name must be at most 50 characters.")]
    public string name {get;set;} = null!;
   
    [Required]
    public DateTime startDate {get;set;}
    
    public DateTime? endDate {get;set;}

    [Required]
    [StringLength(500, MinimumLength = 10, ErrorMessage = "The program's description must be at most 500 characters.")]
    public string description {get;set;} = null!;

    [Required]
    public List<EditionModel> editions {get;set;} = null!;
    [Required]
    public List<NewsModel> news {get;set;} = null!;
    [Required]
    public List<UserModel> owners {get;set;} = null!;

    public List<OwnershipModel> ownerships {get;set;} = null!;
}
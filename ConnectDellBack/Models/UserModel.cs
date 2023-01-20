using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ConnectDellBack.Models;

//parking
public enum Role
{
    Admin,
    Intern,
    DellManager,
    DellMember,
    PucrsStaff
}

public class UserModel{

    public int id { get; set; }
    public String name { get; set; } =  null!;
    [Required(ErrorMessage = "Email can't be empty.")]
    [EmailAddress]
    [RegularExpression(@".+\@dell(team){0,1}\.com$")]
    public String email { get; set; } =  null!;
    [Required]
    public Role role { get; set; }
    // intership log (text to fill with information about which activities were performed.)
    [StringLength(5000, ErrorMessage = "The length of the notes exceeds the limit.")]
    public String notes { get; set; } =  null!; 

    public List<EditionModel>? listEditions {get;set;}
    public EditionModel? editionIntern {get;set;}
    public List<OwnershipModel>? ownerships {get;set;}
    public List<ProgramModel>? ProgramsAdmins {get;set;}
    public List<MembershipModel>? memberships {get;set;}
    public List<NewsModel>? listNews {get; set;}

    //Comentando Projeto 

}
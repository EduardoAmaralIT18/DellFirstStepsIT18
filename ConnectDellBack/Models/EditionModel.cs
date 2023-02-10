using System.ComponentModel.DataAnnotations;

namespace ConnectDellBack.Models;

public enum Mode {
    Remote,
    Hybrid,
    InOffice
}

public class EditionModel {

    public int id {get;set;}

    [Required]
    [StringLength(50, MinimumLength = 5, ErrorMessage = "The program's name must be at most 50 characters.")]
    //[RegularExpression(@"[A-Za-z0-9]*")]
    public string name {get;set;}

    [Required]
    public DateTime startDate {get;set;}

    //[IsValidEndDate ("startDate")]
    [Required]
    public DateTime? endDate {get;set;}

    [StringLength(500, MinimumLength = 10, ErrorMessage = "The program's description must be at most 500 characters.")]
    public string description {get;set;}

    [Range (1,25, ErrorMessage = "The program must have at least 1 member!")] //ask PO about the maximum number
    [RegularExpression(@"\b([1-9]|[1-9][0-9])\b")]
    public int numberOfMembers {get;set;}

    [Range (1,21, ErrorMessage = "The program must have at least 1 intern!")] // ask PO about the maximum number of interns
    [RegularExpression(@"\b([1-9]|[1-9][0-9])\b")]
    public int numberOfInterns {get;set;}

    public Mode mode {get;set;}

    [StringLength(500, MinimumLength = 10, ErrorMessage = "The program's curriculum must be at most 500 characters.")]
    public string curriculum {get;set;}

    public ProgramModel program {get;set;}
    public List<UserModel> members {get;set;}  = new List<UserModel>();
    public List<MembershipModel> memberships {get;set;} = new List<MembershipModel>();
    public List<UserModel> interns {get;set;} = new List<UserModel>();
    public List<PhasesModel> phases {get;set;} = new List<PhasesModel>();

    // public static implicit operator EditionModel(EditionModel v)
    // {
    //     throw new NotImplementedException();
    // }
}

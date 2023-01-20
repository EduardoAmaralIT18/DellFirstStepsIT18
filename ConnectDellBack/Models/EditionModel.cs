using System.ComponentModel.DataAnnotations;

namespace ConnectDellBack.Models;

public enum Mode {
    Remote,
    Hybrid,
    InOffice
}

public class EditionModel{

    public int id {get;set;}
    
    [Required]
    [StringLength(50, MinimumLength = 5, ErrorMessage = "The program's name must be at most 50 characters.")]
    public string name {get;set;} = null!;
   
    [Required]
    public DateTime startDate {get;set;}

    public DateTime? endDate {get;set;}

    [StringLength(500, MinimumLength = 10, ErrorMessage = "The program's description must be at most 500 characters.")]
    public string description {get;set;} = null!;

    [Range (1,25, ErrorMessage = "The program must have at least 1 member!")] //ask PO about the maximum number
    public int numberOfMembers {get;set;}

    [Range (1,25, ErrorMessage = "The program must have at least 1 intern!")] // ask PO about the maximum number of interns
    public int numberOfInterns {get;set;}
    
    public Mode mode {get;set;}

    [StringLength(500, MinimumLength = 10, ErrorMessage = "The program's curriculum must be at most 500 characters.")]
    public string curriculum {get;set;} = null!;

    public ProgramModel program {get;set;} = null!;
    public List<UserModel> members {get;set;} = new List<UserModel>();
    public List<MembershipModel> memberships {get;set;} = new List<MembershipModel>();
    public List<UserModel>? interns {get;set;} = new List<UserModel>();
    public List<PhasesModel>? phases {get;set;} = new List<PhasesModel>();
    
}

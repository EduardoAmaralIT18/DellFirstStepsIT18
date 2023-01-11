using System.ComponentModel.DataAnnotations;

namespace ConnectDellBack.Models;

public enum Type {
    Set_Up,
    Training,
    Sprints,
    HandsOn
}

public class PhasesModel {

    public int id {get;set;}
    [Required]
    [StringLength(50, MinimumLength = 5, ErrorMessage = "The program's name must be at most 50 characters.")]
    public string name {get;set;} = null!;

    [Required]
    [StringLength(500, MinimumLength = 10, ErrorMessage = "The program's description must be at most 500 characters.")]
    public string description {get;set;} = null!;
   
    [Required]
    public DateTime startDate {get;set;}
    
    public DateTime? endDate {get;set;}

    [Required]
    [StringLength(500, MinimumLength = 10, ErrorMessage = "The program's member list must be at most 500 characters.")]
    public string peopleInvolved {get;set;} = null!;

    [Required]
    public Type type {get;set;}

    public EditionModel edition {get;set;} = null!;

    //aaaaaaaa
}
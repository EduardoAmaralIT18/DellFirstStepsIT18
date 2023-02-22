using System.ComponentModel.DataAnnotations;
using ConnectDellBack.Models;

namespace ConnectDellBack.DTOs;

public class EventsDTO {
    [Required]
    [StringLength(50, MinimumLength = 5, ErrorMessage = "The event's name must be at most 25 characters.")]
    public string name {get;set;} = null!;

    [Required]
    public int eventType {get;set;}

    public int phaseType {get;set;}

    [Required]
    public DateTime startDate {get;set;}
    
    [Required]
    //[IsValidEndDate ("startDate")]
    public DateTime endDate {get;set;}

    public string where {get;set;} = null!;

    //Lista de Usuários Envolvidos
    public List<UserModel> peopleInvolved {get;set;} = new List<UserModel>();

    public int editionID {get;set;} 
}
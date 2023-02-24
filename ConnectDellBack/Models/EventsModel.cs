using System.ComponentModel.DataAnnotations;

namespace ConnectDellBack.Models;

public enum PhaseType
{
    Set_Up,
    Training,
    Sprints,
    HandsOn,
    None
}

public enum EventType
{
    Phase,
    Activity
}

public class EventsModel
{

    public int id { get; set; }
    [Required]
    [StringLength(50, MinimumLength = 5, ErrorMessage = "The event's name must be at most 30 characters.")]
    public string name {get;set;} = null!;

    [Required]
    public EventType eventType { get; set; }

    public PhaseType phaseType { get; set; }

    [Required]
    public DateTime startDate { get; set; }

    [Required]
    //[IsValidEndDate ("startDate")]
    public DateTime endDate { get; set; }

    public string? where { get;set; }

    //Lista de Usuários Envolvidos
    public List<UserModel> peopleInvolved { get; set; } = new List<UserModel>();

    public List<ParticipationModel> participations { get; set; } = new List<ParticipationModel>();

    public EditionModel edition { get; set; } = null!;
}

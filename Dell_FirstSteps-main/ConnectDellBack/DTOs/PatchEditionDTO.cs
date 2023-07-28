namespace ConnectDellBack.DTOs;

public class PatchEditionDTO
{
    public int id { get; set; }
    public string name { get; set; } = null!;
    public int numberOfInterns { get; set; }
    public string description { get; set; }
    public string curriculum { get; set; }
    public int mode { get; set; }
    public DateTime startDate { get; set; }
    public DateTime endDate { get; set; }
    // Necessary for the calendar component, since its end date is exclusive and I couldn't add one day through Vue
    public DateTime calendarEndDate { get; set; }
    public int program { get; set; }
    public string programName { get; set; }

    public List<UserDTO> members {get;set;}  = new List<UserDTO>();
    public List<UserDTO> interns {get;set;} = new List<UserDTO>();
    public List<NewEventDTO> events {get;set;} = new List<NewEventDTO>();
}
namespace ConnectDellBack.DTOs;
using ConnectDellBack.Models;



public class EditionDTO {
    public string name { get; set; } = null!;
    public int numberOfInterns {get; set;} 
    public int numberOfMembers {get; set;}
    public string description {get; set;}
    public string courses {get; set;}
    public int mode {get; set;}
    public DateTime startDate {get; set;}
    public DateTime? endDate {get; set;}
    public int program {get; set;}

}
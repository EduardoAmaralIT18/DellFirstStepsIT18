namespace ConnectDellBack.DTOs;
using ConnectDellBack.Models;



public class EditionDTO {
    public int id { get; set; }
    public string name { get; set; } = null!;
    public int numberOfInterns {get; set;} 
    public int numberOfMembers {get; set;}
    public string description {get; set;}
    public string curriculum { get; set;}
    public int mode {get; set;}
    public DateTime startDate {get; set;}
    public DateTime? endDate {get; set;}
    public int program {get; set;}

    public static EditionDTO convertModel2DTO(EditionModel edition)
    {
        EditionDTO aux = new EditionDTO();
        aux.id = edition.id;
        aux.name = edition.name;
        aux.numberOfInterns = edition.numberOfInterns;
        aux.numberOfMembers = edition.numberOfMembers;
        aux.description = edition.description;
        aux.curriculum = edition.curriculum;
        aux.mode = (int)edition.mode;
        aux.startDate = edition.startDate;
        aux.endDate = edition.endDate;
        aux.program = edition.program.id;
        return aux;
    }
}
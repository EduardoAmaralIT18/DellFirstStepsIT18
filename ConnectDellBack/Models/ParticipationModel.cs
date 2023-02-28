using System.ComponentModel.DataAnnotations;

namespace ConnectDellBack.Models;

public class ParticipationModel{
    public EventsModel events {get;set;} = null!;
    public UserModel participant {get;set;} = null!;
}
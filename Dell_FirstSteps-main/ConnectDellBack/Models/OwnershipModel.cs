using System.ComponentModel.DataAnnotations;

namespace ConnectDellBack.Models;

public class OwnershipModel{
    public ProgramModel program {get;set;} = null!;
    public UserModel owner {get;set;} = null!;
}
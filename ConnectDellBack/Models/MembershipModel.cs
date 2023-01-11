using System.ComponentModel.DataAnnotations;

namespace ConnectDellBack.Models;

public class MembershipModel{
    public EditionModel edition {get;set;} = null!;
    public UserModel member {get;set;} = null!;
}
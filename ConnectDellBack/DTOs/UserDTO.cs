namespace ConnectDellBack.DTOs;
using ConnectDellBack.Models;



public class UserDTO
{

    public int id { get; set; }
    public string name { get; set; }
    public string email { get; set; }
    public Role role { get; set; }
    public string roleName {get; set;}


    public static UserDTO convertToDTO(UserModel usr)
    {
        var aux = new UserDTO();
        aux.id = usr.id;
        aux.name = usr.name;
        aux.email = usr.email;
        aux.role = usr.role;
        aux.roleName = Enum.GetName(typeof(Role), usr.role);
        return aux;
    }

}
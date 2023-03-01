using ConnectDellBack.Models;

namespace ConnectDellBack.DTOs;

public class OwnerDTO
{
    public int id { get; set; }
    public string name { get; set; } = null!;

    public static OwnerDTO ConvertModel2DTO(UserModel user)
    {
        OwnerDTO aux = new OwnerDTO();
        aux.id = user.id;
        aux.name = user.name;
        return aux;
    }
}

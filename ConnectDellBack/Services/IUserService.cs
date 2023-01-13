using Microsoft.EntityFrameworkCore;
using ConnectDellBack.Models;
using ConnectDellBack.DTOs;


namespace ConnectDellBack.Services;

    public interface IUserService
    {

    Task<IEnumerable<ProgramModel>> Get();
    IEnumerable<UserModel> GetOwners();


    //Task<ProgramModel> Get(int Id);


    }



//criar usuário
/*public string createUser (UserModel user);

//ligando usuário ao programa
public string assignProgram (int idUser, int idProgram);

public string createProgram(ProgramModel program);

public string assignEdition(int idUser, int idEdition);

public string createEdition(EditionModel edition);


//public changeRole(); //?????????????????????????

public IEnumerable<UserModel> listUser(); */
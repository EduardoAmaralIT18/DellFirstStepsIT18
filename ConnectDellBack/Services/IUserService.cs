using Microsoft.EntityFrameworkCore;
using ConnectDellBack.Models;
using System.Threading.Tasks;

namespace ConnectDellBack.Services;

    public interface IUserService
    {
    
    Task<IEnumerable<ProgramModel>> Get();
        //criar usuário
        public string createUser (UserModel user);

        //ligando usuário ao programa
        public string assignProgram (int idUser, int idProgram);
        
        public string createProgram(ProgramModel program);

        public string assignEdition(int idUser, int idEdition);

        public string createEdition(EditionModel edition); // quem fez??

        //public changeRole(); //?????????????????????????

        public IEnumerable<UserModel> listUsers();
    }


        
        
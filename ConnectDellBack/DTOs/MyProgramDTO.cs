using ConnectDellBack.Models;

namespace ConnectDellBack.DTOs
{
    public class MyProgramDTO 
    {
        public int id {get; set;}
        public string name { get; set; }
        public DateTime startDate { get; set; }
        public DateTime? endDate { get; set; }
        public string description { get; set; }
        public List<EditionModel>? editions { get; set; } = new List<EditionModel>();

        public static MyProgramDTO ConvertToDTOAll(ProgramModel prog)
        {
            var aux = new MyProgramDTO();
            aux.id = prog.id;
            aux.name = prog.name;
            aux.startDate = prog.startDate;
            aux.endDate = prog.endDate;
            aux.description = prog.description;
            return aux;
        }
        public static MyProgramDTO ConvertToDTOAdmin(ProgramModel prog)
        {
            var aux = new MyProgramDTO();
            aux.id = prog.id;
            aux.name = prog.name;
            aux.startDate = prog.startDate;
            aux.endDate = prog.endDate;
            aux.description = prog.description;
            foreach (var item in prog.editions)
            {
                aux.editions.Add(new EditionModel()
                {
                    id = item.id,
                    name = item.name,
                    description = item.description
                });
            }
            return aux;
        }

        public static MyProgramDTO ConvertToDTOIntern(ProgramModel prog, EditionModel edition)
        {
            var aux = new MyProgramDTO();
            aux.id = prog.id;
            aux.name = prog.name;
            aux.startDate = prog.startDate;
            aux.endDate = prog.endDate;
            aux.description = prog.description;
            aux.editions.Add(new EditionModel()
            {
                id = edition.id,
                name = edition.name,
                description = edition.description
            });
            return aux;
        }

        public static MyProgramDTO ConvertToDTOOthers(ProgramModel prog, EditionModel edition)
        {
            var aux = new MyProgramDTO();
            aux.id = prog.id;
            aux.name = prog.name;
            aux.startDate = prog.startDate;
            aux.endDate = prog.endDate;
            aux.description = prog.description;
            aux.editions.Add(new EditionModel()
            {
                id = edition.id,
                name = edition.name,
                description = edition.description
            });
            return aux;
        }

       
    }
}
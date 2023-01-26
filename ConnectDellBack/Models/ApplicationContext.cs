using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ConnectDellBack.Models;
// //////// ALTERADO
public class ApplicationContext : DbContext
{

    public DbSet<UserModel> users { get; set;} = null!; 
    public DbSet<ProgramModel> programs { get; set;} = null!;
    public DbSet<EditionModel> editions { get; set;} = null!;
    public DbSet<PhasesModel> phases { get; set;} = null!;
    public DbSet<NewsModel> news { get; set;} = null!;
    public DbSet<ImageModel> images {get; set;} = null!;

    
    public ApplicationContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserModel>()
                    .HasMany(user => user.ProgramsAdmins)
                    .WithMany(program => program.owners)
                    .UsingEntity<OwnershipModel>();

        modelBuilder.Entity<EditionModel>()
                    .HasMany(edit => edit.members)
                    .WithMany(user => user.listEditions)
                    .UsingEntity<MembershipModel>();

        modelBuilder.Entity<UserModel>()
                    .HasOne(user => user.editionIntern)
                    .WithMany(edition => edition.interns);

        modelBuilder.Entity<NewsModel>()
                    .HasOne(n => n.image)
                    .WithOne(i => i.news)
                    .HasForeignKey<ImageModel>(i => i.imageId);

        //CRIAÇÃO DOS PROGRAMAS NA DATABASE
        modelBuilder.Entity<ProgramModel>().HasData(
           new {
                id = 1,
                name = "IT Academy",  
                startDate = new DateTime(2022,10,08),
                description = "Internship Program in partnership with PUCRS, focused in software development",
            }
        );
        modelBuilder.Entity<ProgramModel>().HasData(
           new {
                id = 2,
                name = "Design Academy",  
                startDate = new DateTime(2022,10,08),
                description = "The Design Academy is a capacitation program for students from Unisinos, focusing on Digital Product Design activities, with the goal to qualify interns to execute final functions on the Information Communication Technologies (ICT) area. It focuses on supplying the companies needs of digital design professionals, more specifically related to User Experience and User Interface, and to allow young professionals to complete their academic journey with a scientific and technical knowledge and to be oriented by the market needs. ",
            }
        );
        modelBuilder.Entity<ProgramModel>().HasData(
           new {
                id = 3,
                name = "Infrastructure Residence",  
                startDate = new DateTime(2022,10,08),
                description = "The Infrastructure Residence on IT focuses on implementing and executing a training and experience program in different IT infrastructure areas, allowing the members to participate in an immersive training program, merging technical knowledge with the latest research and innovation trends in the field and hands-on experience in a lab with the same materials and conditions that they will be involved in the future labor market. The term 'residence' was chosen to characterize exactly those practical aspects and capacitation experiences. Since the Infrastructure area requires a multistack and multidisciplinary formation, the residency program will innovate and provide the needed familiarity with the area so the students with medium to advanced knowledge can become Infrastructure professionals able to deal with all of the challenges on the field.",
            }
        );

        //CRIAÇÃO DOS USUÁRIOS
        modelBuilder.Entity<UserModel>().HasData(

            //admins
            new UserModel {
                id = 1,
                name = "Tassia Borochedes",
                email = "tassia.borochedes@dell.com",
                role = Role.Admin,
                notes = "N/A"
            },
            new UserModel {
                id = 2,
                name = "Felipe Barreto",
                email = "felipe.barreto@dell.com",
                role = Role.Admin,
                notes = "N/A"
            },
            new UserModel {
                id = 3,
                name = "Marcio Borges",
                email = "marcio.borges@dell.com",
                role = Role.Admin,
                notes = "N/A"
            },
            new UserModel {
                id = 4,
                name = "Michael Dell",
                email = "michael.dell@dell.com",
                role = Role.Admin,
                notes = "N/A"
            },

            //dell manager
            new UserModel(){
                id = 5,
                name = "Nelson Muller",
                email = "nelson.muller@dell.com",
                role = Role.DellManager,
                notes = "N/A"
            },
            new UserModel(){
                id = 6,
                name = "Marcelo Soares",
                email = "marcelo.soares@dell.com",
                role = Role.DellManager,
                notes = "N/A"
            },
            new UserModel(){
                id = 7,
                name = "Norton Zamboni",
                email = "norton.zamboni@dellteam.com",
                role = Role.DellMember,
                notes = "N/A"
            },

            //pucrs staff
            new UserModel(){
                id = 8,
                name = "Daniel Callegari",
                email = "daniel.callegari@dell.com",
                role = Role.PucrsStaff,
                notes = "N/A"
            },
            new UserModel(){
                id = 9,
                name = "Edson Moreno",
                email = "edson.moreno@dell.com",
                role = Role.PucrsStaff,
                notes = "N/A"
            },
            new UserModel(){
                id = 10,
                name = "Tuani Alves",
                email = "tuani.alves@edupucrs.com",
                role = Role.PucrsStaff,
                notes = "N/A"
            },
            new UserModel(){
                id = 11,
                name = "Natalya Goelzer",
                email = "natalya.goelzer@edu.pucrs.br",
                role = Role.PucrsStaff,
                notes = "N/A"
            },

            //interns
            new {
                id = 12,
                editionInternid = 1,
                name = "Laura",
                email = "laura.teixeira@dellteam.com",
                role = Role.Intern,
                notes = "N/A"
            },
            new {
                id = 13,
                editionInternid = 1,
                name = "Kristen Arguello",
                email = "kristen.arguello@dellteam.com",
                role = Role.Intern,
                notes = "N/A"
            },
            new {
                id = 14,
                editionInternid = 1,
                name = "Isadora Brust",
                email = "isadora.brust@dellteam.com",
                role = Role.Intern,
                notes = "N/A"
            },
            new {
                id = 15,
                editionInternid = 1,
                name = "Yolanda Colombo",
                email = "yolanda.colombo@dellteam.com",
                role = Role.Intern,
                notes = "N/A"
            },
            new {
                id = 16,
                editionInternid = 1,
                name = "Andressa Correa",
                email = "andressa.correa@dellteam.com",
                role = Role.Intern,
                notes = "N/A"
            },
            new {
                id = 17,
                editionInternid = 1,
                name = "Kauana Galan",
                email = "kauana.galan@dellteam.com",
                role = Role.Intern,
                notes = "N/A"
            },
            new {
                id = 18,
                editionInternid = 1,
                name = "Taise Goulart",
                email = "taise.goulart@dellteam.com",
                role = Role.Intern,
                notes = "N/A"
            },
            new {
                id = 19,
                editionInternid = 1,
                name = "Jessica Haushahn",
                email = "jessica.haushahn@dellteam.com",
                role = Role.Intern,
                notes = "N/A"
            },
            new {
                id = 20,
                editionInternid = 1,
                name = "Heloisa Farias",
                email = "heloisa.farias@dellteam.com",
                role = Role.Intern,
                notes = "N/A"
            },
            new {
                id = 21,
                editionInternid = 1,
                name = "Paola Lopes",
                email = "paola.lopes@dellteam.com",
                role = Role.Intern,
                notes = "N/A"
            },
            new {
                id = 22,
                editionInternid = 1,
                name = "Juliana Santos",
                email = "juliana.santos@dellteam.com",
                role = Role.Intern,
                notes = "N/A"
            },
            new {
                id = 23,
                editionInternid = 1,
                name = "Yasmin Nunes",
                email = "yasmin.nunes@dellteam.com",
                role = Role.Intern,
                notes = "N/A"
            },
            new {
                id = 24,
                editionInternid = 1,
                name = "Alexya Oliveira",
                email = "alexya.oliveira@dellteam.com",
                role = Role.Intern,
                notes = "N/A"
            },
            new {
                id = 25,
                editionInternid = 1,
                name = "Yanni Partichelli",
                email = "yanni.partichelli@dellteam.com",
                role = Role.Intern,
                notes = "N/A"
            },
            new {
                id = 26,
                editionInternid = 1,
                name = "Gabrielle Rodrigues",
                email = "gabrielle.rodrigues@dellteam.com",
                role = Role.Intern,
                notes = "N/A"
            },
            new {
                id = 27,
                editionInternid = 1,
                name = "Larissa Rosa",
                email = "larissa.rosa@dellteam.com",
                role = Role.Intern,
                notes = "N/A"
            },
            new {
                id = 28,
                editionInternid = 1,
                name = "Renata Rosa",
                email = "renata.rosa@dellteam.com",
                role = Role.Intern,
                notes = "N/A"
            },
            new {
                id = 29,
                editionInternid = 1,
                name = "Jordana Santos",
                email = "jordana.santos@dellteam.com",
                role = Role.Intern,
                notes = "N/A"
            },
            new {
                id = 30,
                editionInternid = 1,
                name = "Adriana Serpa",
                email = "adriana.serpa@dellteam.com",
                role = Role.Intern,
                notes = "N/A"
            },
            new {
                id = 31,
                editionInternid = 1,
                name = "Gabriela Machado",
                email = "gabriela.machado@dellteam.com",
                role = Role.Intern,
                notes = "N/A"
            },
            new {
                id = 32,
                editionInternid = 1,
                name = "Leandra Torbes",
                email = "leandra.torbes@dellteam.com",
                role = Role.Intern,
                notes = "N/A"
            }
            
        );

        modelBuilder.Entity<EditionModel>().HasData(

            //edições it academy
            new {
                id = 1,
                programid = 1,
                name = "Edição 17",
                startDate = new DateTime(2022,10,10),
                endDate = new DateTime(2023,05,28),
                description = "Seventeenth edition of the IT Academy program focused solely on the self-titled female audience.",
                numberOfMembers = 20,
                numberOfInterns = 21, 
                mode = Mode.Hybrid,
                curriculum = "CSS, HTML, C#, JavaScript, SQL Server, Entity Framework, Asp.NET, Vue.js entre outros.",
            },
            new {
                id = 2,
                programid = 1,
                name = "Edição 16",
                startDate = new DateTime(2021,10,10),
                endDate = new DateTime(2022,09,10),
                description = "Sixteenth edition of the IT Academy program aimed at undergraduate students in computer science courses.",
                numberOfMembers = 25,
                numberOfInterns = 20, 
                mode = Mode.Remote,
                curriculum = "CSS, HTML, C#, JavaScript, SQL Server, Entity Framework, Asp.NET, Vue.js",
            },
            new {
                id = 3,
                programid = 1,
                name = "Edição 18",
                startDate = new DateTime(2023,10,10),
                endDate = new DateTime(2024,02,28),
                description = "Eighteenth edition of the IT Academy program aimed at undergraduate students in computer science courses.",
                numberOfMembers = 25,
                numberOfInterns = 21, 
                mode = Mode.InOffice,
                curriculum = "CSS, HTML, C#, JavaScript, SQL Server, Entity Framework, Asp.NET, Vue.js",
            },

            //edições design academy
            new {
                id = 4,
                programid = 2,
                name = "Edição 17",
                startDate = new DateTime(2022,10,10),
                endDate = new DateTime(2023,05,28),
                description = "Seventeenth edition of the Design Academy program",
                numberOfMembers = 25,
                numberOfInterns = 21, 
                mode = Mode.Hybrid,
                curriculum = "User Experience and User Interface",
            },
            new {
                id = 5,
                programid = 2,
                name = "Edição 16",
                startDate = new DateTime(2021,10,10),
                endDate = new DateTime(2022,02,28),
                description = "Sixteenth edition of the Design Academy program",
                numberOfMembers = 25,
                numberOfInterns = 21, 
                mode = Mode.Hybrid,
                curriculum = "User Experience and User Interface",
            },

            //edições infrastructure residence
            new {
                id = 6,
                programid = 3,
                name = "Edição 17",
                startDate = new DateTime(2022,10,10),
                endDate = new DateTime(2023,05,28),
                description = "Seventeenth edition of the Infrastructure Resindece program",
                numberOfMembers = 25,
                numberOfInterns = 21, 
                mode = Mode.Hybrid,
                curriculum = "Computer Architecture, Cloud Computing, Database, and Security and IT environments",
            },
            new {
                id = 7,
                programid = 3,
                name = "Edição 16",
                startDate = new DateTime(2021,10,10),
                endDate = new DateTime(2022,02,28),
                description = "Sixteenth edition of the Infrastructure Resindece program",
                numberOfMembers = 25,
                numberOfInterns = 21, 
                mode = Mode.Hybrid,
                curriculum = "Computer Architecture, Cloud Computing, Database, and Security and IT environments",
            }

        );

        modelBuilder.Entity<PhasesModel>().HasData(
            new {
                id = 1,
                editionid = 1,
                newsmodelid = 1,
                name = "Enrollment",
                startDate = new DateTime(2022,08,10),
                endDate = new DateTime(2022,08,23),
                peopleInvolved = "Puc and Dell Staff",
                description = "Enrollment stage",
                type = Type.Set_Up,
        });

        modelBuilder.Entity<NewsModel>().HasData(
             new {
                id = 1,
                authorid = 1,
                programid = 1,
                title = "IT 17 team starts development of the Dell FirstSteps Project",
                text = "The all-girls team starts development of the Dell FirstSteps Project, that will help organize all contents about Dell's Internship Programs.",
                date = new DateTime(2022,01,04),
            }
         );

        modelBuilder.Entity<OwnershipModel>().HasData(
            
            //Tassia owner do IT Academy
            new {
                programid = 1,
                ownerid = 1
            },
            //Felipe owner do Design Academy
            new {
                programid = 2,
                ownerid = 2
            },
            //Marcio owner do Infrastructure Residence
            new {
                programid = 3,
                ownerid = 3
            }

         );

         modelBuilder.Entity<MembershipModel>().HasData(
            
            //colocando membros na edição 17 do it academy
            new {
                editionid = 1,
                memberid = 1
            },
            new {
                editionid = 1,
                memberid = 5
            },
            new {
                editionid = 1,
                memberid = 6
            },
            new {
                editionid = 1,
                memberid = 7
            },
            new {
                editionid = 1,
                memberid = 8
            },
            new {
                editionid = 1,
                memberid = 9
            },
            new {
                editionid = 1,
                memberid = 10
            },
            new {
                editionid = 1,
                memberid = 11
            },

            //colocando membros na edição 16 do it academy
            new {
                editionid = 2,
                memberid = 1
            },
            new {
                editionid = 2,
                memberid = 5
            },
            new {
                editionid = 2,
                memberid = 6
            },
            new {
                editionid = 2,
                memberid = 8
            },
            new {
                editionid = 2,
                memberid = 9
            },
            new {
                editionid = 2,
                memberid = 10
            },
            new {
                editionid = 2,
                memberid = 11
            },

            //colocando membros na edição 18 do it academy
            new {
                editionid = 3,
                memberid = 1
            },
            new {
                editionid = 3,
                memberid = 5
            },
            new {
                editionid = 3,
                memberid = 6
            },
            new {
                editionid = 3,
                memberid = 8
            },
            new {
                editionid = 3,
                memberid = 9
            },
            new {
                editionid = 3,
                memberid = 10
            },
            new {
                editionid = 3,
                memberid = 11
            },

            //colocando membros na edição 17 do design academy
            new {
                editionid = 4,
                memberid = 2
            },
            new {
                editionid = 4,
                memberid = 5
            },
            
            //colocando membros na edição 16 do design academy
            new {
                editionid = 5,
                memberid = 2
            },
            new {
                editionid = 5,
                memberid = 5
            },

            //colocando membros na edição 17 do infrastructure residence
            new {
                editionid = 6,
                memberid = 2
            },
            new {
                editionid = 6,
                memberid = 5
            },
            new {
                editionid = 6,
                memberid = 10
            },

            //colocando membros na edição 16 do infrastructure residence
            new {
                editionid = 7,
                memberid = 2
            },
            new {
                editionid = 7,
                memberid = 5
            },
            new {
                editionid = 7,
                memberid = 10
            }

         );
    }
}
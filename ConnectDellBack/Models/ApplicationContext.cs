using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ConnectDellBack.Models;

public class ApplicationContext : DbContext
{

    public DbSet<UserModel> users { get; set;} = null!; 
    public DbSet<ProgramModel> programs { get; set;} = null!;
    public DbSet<EditionModel> editions { get; set;} = null!;
    public DbSet<PhasesModel> phases { get; set;} = null!;
    public DbSet<NewsModel> news { get; set;} = null!;

    
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

        modelBuilder.Entity<ProgramModel>().HasData(
            new {
                id = 1,
                name = "IT Academy",  
                startDate = new DateTime(08/10/2022),
                description = "Internship Program in partnership with PUCRS, focused in software development",
            }
        );
        modelBuilder.Entity<UserModel>().HasData(
            new UserModel {
                id = 1,
                name = "Tassia",
                email = "tassia.borochedes@dell.com",
                role = Role.Admin,
                notes = "N/A"
            },
            new UserModel(){
                id = 2,
                name = "Nelson",
                email = "nelson.muller@dell.com",
                role = Role.DellManager,
                notes = "N/A"
            },
            new UserModel(){
                id = 3,
                name = "Marcelo",
                email = "marcelo.soares@dell.com",
                role = Role.DellManager,
                notes = "N/A"
            },
            new UserModel(){
                id = 4,
                name = "Norton",
                email = "norton.zamboni@dellteam.com",
                role = Role.DellMember,
                notes = "N/A"
            },
            new UserModel(){
                id = 5,
                name = "Daniel",
                email = "daniel.callegari@dell.com",
                role = Role.PucrsStaff,
                notes = "N/A"
            },
            new UserModel(){
                id = 6,
                name = "Edson",
                email = "edson.moreno@dell.com",
                role = Role.PucrsStaff,
                notes = "N/A"
            },
            new UserModel(){
                id = 7,
                name = "Tuani",
                email = "tuani.alves@edupucrs.com",
                role = Role.PucrsStaff,
                notes = "N/A"
            },
            new UserModel(){
                id = 8,
                name = "Natalya",
                email = "natalya.goelzer@edu.pucrs.br",
                role = Role.PucrsStaff,
                notes = "N/A"
            },

            new {
                id = 9,
                editionInternid = 1,
                name = "Alexya",
                email = "alexya.oliveira@dellteam.com",
                role = Role.Intern,
                notes = "Wish we had more Vue.js lessons, due to this we had difficulties doing our integration project. But the team is awesome and we managed to overcome this difficulty together"
            },
            new {
                id = 10,
                editionInternid = 1,
                name = "Juliana",
                email = "juliana.maulzolfsantos@dellteam.com",
                role = Role.Intern,
                notes = "Entity framework is difficult to understand and integrating the DB via code is still complicated to me"
            },
            new {
                id = 11,
                editionInternid = 1,
                name = "Yolanda",
                email = " yolanda.colombo@dellteam.com",
                role = Role.Intern,
                notes = "I need to learn Vue.js."
            },
            new {
                id = 12,
                editionInternid = 1,
                name = "Gabrielle",
                email = "gabrielle.rodrigues@dellteam.com",
                role = Role.Intern,
                notes = "Entity framework is very difficult and I need more Vue.js lessons"
            },
            new {
                id = 13,
                editionInternid = 1,
                name = "Heloisa",
                email = "heloisa.lopesfarias@dellteam.com",
                role = Role.Intern,
                notes = "I learned a lot about C# and Dotnet, but need to learn more about Vue.js."
            },
            new {
                id = 14,
                editionInternid = 1,
                name = "Adriana",
                email = "adriana.serpa@dellteam.com",
                role = Role.Intern,
                notes = "I need to review the Entity framework lessons and study Vue.Js"
            },
            new {
                id = 15,
                editionInternid = 1,
                name = "Larissa",
                email = "larissa.rosa@dellteam.com",
                role = Role.Intern,
                notes = "I like Entity Framework but need to review Vue.js"
            }
        );
        modelBuilder.Entity<EditionModel>().HasData(
            new {
                id = 1,
                programid = 1,
                name = "IT Academy 17",
                startDate = new DateTime(10/10/2022),
                endDate = new DateTime(02/28/2023),
                description = "First edition of the IT Academy program focused solely on the self-titled female audience",
                numberOfMembers = 25,
                numberOfInterns = 21, 
                mode = Mode.Hybrid,
                curriculum = "CSS, HTML, C#, JavaScript, SQL Server, Entity Framework, Asp.NET, Vue.js entre outros",
            }
        );
        modelBuilder.Entity<PhasesModel>().HasData(
            new {
                id = 1,
                editionid = 1,
                newsmodelid = 1,
                name = "Enrollment",
                startDate = new DateTime(08/10/2022),
                endDate = new DateTime(08/23/22),
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
                date = new DateTime(01/04/2022),
            }
         );
        modelBuilder.Entity<OwnershipModel>().HasData(
            new {
                programid = 1,
                ownerid = 1
            }
         );
         modelBuilder.Entity<MembershipModel>().HasData(
            new {
                editionid = 1,
                memberid = 1
            },
            new {
                editionid = 1,
                memberid = 2
            },
            new {
                editionid = 1,
                memberid = 3
            },
            new {
                editionid = 1,
                memberid = 4
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
            }
         );
    }
}
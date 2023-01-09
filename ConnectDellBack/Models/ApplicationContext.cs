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
    }

    // Criando uma instância dentro da primeira Migration (InicialCreate) para conseguir o Seed 
    internal static ApplicationContext CreateContext()  
    {  
        return new ApplicationContext(new DbContextOptionsBuilder<ApplicationContext>().UseSqlServer(  
               new ConfigurationBuilder()  
                     .AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), $"appsettings.json"))  
                     .AddEnvironmentVariables()  
                     .Build()  
                     .GetConnectionString("ApplicationContext")  
                 ).Options);  
    } 

    public class ApplicationContextFactory : IDesignTimeDbContextFactory<ApplicationContext>  
    {  
        public ApplicationContext CreateDbContext(string[] args)  
        {  
            var dbContext = ApplicationContext.CreateContext();  
            dbContext.Database.Migrate();  
            return dbContext;  
        }  
    } 
}


using Microsoft.EntityFrameworkCore;
using ConnectDellBack.Models;
using ConnectDellBack.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<ApplicationContext>(
    opcoes =>{
        opcoes.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
        opcoes.EnableSensitiveDataLogging().LogTo(Console.WriteLine);
    }
);

builder.Services.AddScoped<INewsService, NewsService>();
builder.Services.AddScoped<IProgramService, ProgramService>();
builder.Services.AddScoped<IUserService, UserService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(builder => builder
   .AllowAnyOrigin()
   .AllowAnyMethod()
   .AllowAnyHeader());

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();

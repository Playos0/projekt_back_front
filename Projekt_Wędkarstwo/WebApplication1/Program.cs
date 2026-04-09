using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using WebApplication1.Data;
using WebApplication1.Services;
using WebApplication1.Services.Interfaces;
using WebApplication1.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
//builder.Services.AddOpenApi();


//builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Serwis do hasel
builder.Services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
builder.Services.AddScoped<IPasswordService, PasswordService>();

//Serwis do autoryzacji
builder.Services.AddScoped<IAuthService, AuthService>();


//tutaj powiozanie z baza danych
builder.Services.AddDbContext<AppDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

    options.UseMySql(connectionString, new MySqlServerVersion(new Version(8,0,0)));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();

}

//tu strefa do debugowania ca³ego syfu itd

app.UseAuthorization();

app.MapControllers();

app.Run();

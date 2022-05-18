using Dyder.API.Configuration;
using Dyder.Repository;
using Dyder.Repository.Auth;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;

// Add services to the container.

// For Entity Framework
//Para altear o banco trocar aqui
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(
        configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(
            new Version(8, 0, 29))));//Aqui você coloca a versão do seu MySql

// For Identity
builder.Services.AddIdentityConfiguration(builder.Configuration);

builder.Services.AddControllers();
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

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();

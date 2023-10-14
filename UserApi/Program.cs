using UserApi.Data;
using Microsoft.EntityFrameworkCore;
using UserApi.Models;
using Microsoft.AspNetCore.Identity;
using UserApi.Services;

var builder = WebApplication.CreateBuilder(args);


var connectionString = builder.Configuration.GetConnectionString("UsuarioConnection");

// Add services to the container.
//Contaact with databse
builder.Services.AddDbContext<UserDbContext>(opts =>
{
    opts.UseMySql(
       connectionString, ServerVersion.AutoDetect(connectionString));
});


//conf Identity 
builder.Services
    .AddIdentity<User, IdentityRole>()
.AddEntityFrameworkStores<UserDbContext>()
.AddDefaultTokenProviders();

//cong automapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//temos que adicionar o serviço
builder.Services.AddScoped<RegisterAndLoginService>();

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

app.UseAuthorization();

app.MapControllers();

app.Run();

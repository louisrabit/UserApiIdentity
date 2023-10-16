using UserApi.Data;
using Microsoft.EntityFrameworkCore;
using UserApi.Models;
using Microsoft.AspNetCore.Identity;
using UserApi.Services;
using UserApi.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

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

builder.Services.AddScoped<RegisterAndLoginService>();

builder.Services.AddScoped<TokenServicce>();

builder.Services.AddAuthorization(opt =>
{
    opt.AddPolicy("MinAge", policy => policy.AddRequirements(new MinAge(18)));
});

builder.Services.AddSingleton<IAuthorizationHandler, AgeAuthorization>();

// Autenticaçao
builder.Services.AddAuthentication(opt =>
{
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(opt =>
{
    opt.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("123swdwecwXZSCERCDSDEWCECXWECCEWC45")),
        ValidateAudience = false,
        ValidateIssuer = false,
        ClockSkew = TimeSpan.Zero
};
});


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

// dizer á app que utiliza autenticaçao
app.UseAuthentication();


app.UseAuthorization();

app.MapControllers();

app.Run();

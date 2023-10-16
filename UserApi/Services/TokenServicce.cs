using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UserApi.Models;

namespace UserApi.Services;

public   class TokenServicce
{
    private IConfiguration _configuration;

    public TokenServicce(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string GenerateToken(User user)
    {
        Claim[] claims = new Claim[]
        {
            new Claim("username", user.UserName),
            new Claim("id", user.Id),
            new Claim(ClaimTypes.DateOfBirth, user.DataNascimento.ToString())
        };



        var chave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["SymmetricSecurityKey"]));
        var signingCredentials = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            expires: DateTime.Now.AddMinutes(10),
            claims: claims,
            signingCredentials: signingCredentials
            );


        return new JwtSecurityTokenHandler().WriteToken(token);
    }
    // o Usuario necessita de confirmar a autenticaçao dentro do sistema . Forma mais comum JWT ( Json Web Tokens).
    //JWT --> forma padrao de transmitir , navegar ou armazenar de forma compacta e protegida objectos Json entre aplicaçoes .
    // Jwt é um codigo pssado , quando passamos alguns parametros 
    //É um algoritmo encoding , onde podemos passar dados --> nao é suposto por dados sensiveiis porque facilmente pode ser revertido !!7
    // As validaçoes e depuraçoes sao feitas do lado do cliente 


}
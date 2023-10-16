using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace UserApi.Authorization;


// Precisamos que esta classe seja o gerenciador , reconhecido pelo .net  , de autorizaçao e interceçao 
//fazemos a extençao -- > authorizationhandler 
public class AgeAuthorization : AuthorizationHandler<MinAge>
{
    // O HandleRequirementAsync , ja fornece AuthorizationHandlerContext e o nosso requirement => MinAge
    // atraves do context , conseguimos acessar as inf dos Users , que esta protegido 
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, MinAge requirement)
    {
        // vamos recuperar o token /jwt --> e vamos pegar a inf do claim, dateOfBirth
        // O que estamos a fazer é , pega a claim que possui dateofbirth
        var dataBirthClaim = context.User.FindFirst( claim => claim.Type == ClaimTypes.DateOfBirth );

        // Se a inf nao existir : 
        if (dataBirthClaim == null)
        {
            return Task.CompletedTask;
        }
            // Estamos a pegar na inf do jwt , de datebirth e a converter para um DateTime 
            var dataNascimento = Convert.ToDateTime(dataBirthClaim.Value);

            //calcular a idade do user
            var IdadeUser = DateTime.Today.Year - dataNascimento.Year;


        if (dataNascimento > DateTime.Today.AddYears(-IdadeUser))
        {
            IdadeUser--;
        }


        if (IdadeUser >= requirement.Age)
        {
            context.Succeed(requirement);
        }

        return Task.CompletedTask;

    }
    }


using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UserApi.Models;

namespace UserApi.Data;


// Diferença , nao vai ser mais um Dbcontext vai ser um IdentityDbContext , que vai fazer referencia ao User 
// User é o modelo que nos estamos a mappear um User para o Banco 
public class UserDbContext : IdentityDbContext<User>
{
    public UserDbContext(DbContextOptions<UserDbContext> opts) : base(opts)
    {

    }
}

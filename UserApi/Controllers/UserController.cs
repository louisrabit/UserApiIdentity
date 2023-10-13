using Microsoft.AspNetCore.Mvc;
using UserApi.Data.DTOs;

namespace UserApi.Controllers;



[ApiController]
[Route("[Controller]")]
public class UserController : ControllerBase
{

    [HttpPost]
    public IActionResult RegistUser(UserCreateDTO dto) // No momento que tivemos a receber o dto e implementar a logica de cadastro , vamos criar um User 
    {


    }


}

using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UserApi.Data.DTOs;
using UserApi.Models;

namespace UserApi.Controllers;



[ApiController]
[Route("[Controller]")]
public class UserController : ControllerBase
{
    private IMapper _mapper;
    //ja estamos a criar o User
    private UserManager<User> _userManager;

    public UserController(IMapper mapper, UserManager<User> userManager)
    {
        _mapper = mapper;

        //ja estamos a criar o User
        _userManager = userManager;
    }




    [HttpPost]
    //Metodo que pode ou nao retornar um valor
    //tipo de retorno Async tem que Ser uma Task , etc etc --> tem obrigatoriedades 
    public async Task<IActionResult> RegistUser(UserCreateDTO dto) // No momento que tivemos a receber o dto e implementar a logica de cadastro , vamos criar um User 
    {
        User user = _mapper.Map<User>(dto); // --> apartir deste mususario precisamos de registrar no banco 

        // Precisamos de registar no banco --> identity ja fornece um metodo 
        //ja estamos a criar o User

        IdentityResult result = await  _userManager.CreateAsync(user, dto.Password); // È uma Task<IdentifyResult> -->  Queremos que o CreateAsync seja executado , para
        // perceber se foi bem executado ou nao !! Esperamos o resultado  devido ao await 

        //precisamos de informar
        if(result.Succeeded)
        {
            return Ok("Usuario Cadastrado");
        }
        else {
            return BadRequest();
        }
    }


}

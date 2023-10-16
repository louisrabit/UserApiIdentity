using Microsoft.AspNetCore.Identity;
using UserApi.Data.DTOs;
using UserApi.Models;
using AutoMapper;

namespace UserApi.Services;

public class RegisterAndLoginService
{

    private IMapper _mapper;
    //ja estamos a criar o User
    private UserManager<User> _userManager;
    private SignInManager<User> _signInManager;
    private TokenServicce _tokenService;

    public RegisterAndLoginService(IMapper mapper, UserManager<User> userManager, SignInManager<User> signInManager, TokenServicce tokenService = null)
    {
        _mapper = mapper;

        //ja estamos a criar o User
        _userManager = userManager;
        _signInManager = signInManager;
        _tokenService = tokenService;
    }

    public async Task Register(UserCreateDTO dto)
    {
        User user = _mapper.Map<User>(dto);
        IdentityResult result = await _userManager.CreateAsync(user, dto.Password); // È uma Task<IdentifyResult> -->  Queremos que o CreateAsync seja executado , para
        if (!result.Succeeded) { throw new ApplicationException("Usuario nao cadastrado"); }



    }

    public async Task<string> Login(LoginUserDto dto)
    {
        var result = await _signInManager.PasswordSignInAsync(dto.UserNome, dto.Password, false, false);
        if (!result.Succeeded)
        {
            throw new ApplicationException("User Nao autenticado");
        }

        // o que fizemos ? SignInManager - acessa gerenciador de usuario - na lista de usrs  - pega 1 usuario em que o normalizedusername seja igual dto.toupper
        var user = _signInManager
            .UserManager
            .Users
            .FirstOrDefault(user => user.NormalizedUserName == dto.UserNome.ToUpper());
        //Se efetuarmos o Login , vamos criar um Token para o User
      var token =   _tokenService.GenerateToken(user);

        return token;
    }
}

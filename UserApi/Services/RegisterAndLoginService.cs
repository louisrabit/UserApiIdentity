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

    public RegisterAndLoginService(IMapper mapper, UserManager<User> userManager, SignInManager<User> signInManager)
    {
        _mapper = mapper;

        //ja estamos a criar o User
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public async Task Register(UserCreateDTO dto)
    {
        User user = _mapper.Map<User>(dto);
        IdentityResult result = await _userManager.CreateAsync(user, dto.Password); // È uma Task<IdentifyResult> -->  Queremos que o CreateAsync seja executado , para
        if (!result.Succeeded) { throw new ApplicationException("Usuario nao cadastrado"); }



    }

    public async Task Login(LoginUserDto dto)
    {
        var result = await _signInManager.PasswordSignInAsync(dto.UserNome, dto.Password, false, false);
        if (!result.Succeeded)
        {
            throw new ApplicationException("User Nao autenticado");
        }
    }
}

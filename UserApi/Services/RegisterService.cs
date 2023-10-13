using Microsoft.AspNetCore.Identity;
using UserApi.Data.DTOs;
using UserApi.Models;
using AutoMapper;

namespace UserApi.Services;

public class RegisterService
{

    private IMapper _mapper;
    //ja estamos a criar o User
    private UserManager<User> _userManager;

    public RegisterService(IMapper mapper, UserManager<User> userManager)
    {
        _mapper = mapper;

        //ja estamos a criar o User
        _userManager = userManager;
    }

    public async Task Register(UserCreateDTO dto)
    {
        User user = _mapper.Map<User>(dto);
        IdentityResult result = await _userManager.CreateAsync(user, dto.Password); // È uma Task<IdentifyResult> -->  Queremos que o CreateAsync seja executado , para
        if (!result.Succeeded) { throw new ApplicationException("Usuario nao cadastrado"); }
           


    }
}

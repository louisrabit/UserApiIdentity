using AutoMapper;
using UserApi.Data.DTOs;
using UserApi.Models;

namespace UserApi.Profiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
            CreateMap<UserCreateDTO, User>();

    }
}

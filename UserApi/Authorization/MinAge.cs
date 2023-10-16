using Microsoft.AspNetCore.Authorization;

namespace UserApi.Authorization;

public class MinAge :  IAuthorizationRequirement
{
    public MinAge(int age)
    {
        Age = age;
    }
    public int Age { get; set; }
}


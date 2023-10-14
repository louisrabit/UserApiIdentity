using System.ComponentModel.DataAnnotations;

namespace UserApi.Data.DTOs;

public class LoginUserDto
{
    [Required]
    public string UserNome { get; set; }

    [Required]
    public string Password { get; set; }
}
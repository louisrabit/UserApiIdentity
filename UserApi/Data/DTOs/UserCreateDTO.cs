using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace UserApi.Data.DTOs;

public class UserCreateDTO
{
    [Required]
    public string Username { get; set; }

    [Required]
    public DateTime DataBirth { get; set; }


    [Required]
    [DataType(DataType.Password)] // Explicita-mos que deve ser tratado como uma senha 
    public string Password { get; set; }
    [Required]
    [Compare("Password")]
    public string RePassword { get; set; }
}

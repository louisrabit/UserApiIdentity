using Microsoft.AspNetCore.Identity;

namespace UserApi.Models;


// vamos deixar o user vazio porque a ideia é o Identity prenncher futuramnete 
public class User :  IdentityUser   // dentro do Indentity tem varios Parametros Ja predfenidos !!
{ 
    
    //Quando instanciar um usuario vai chamar um contrutor da SuperClasse IdentityUser
    // Defenimos que o nosso user alem de todas as propriedades do IdentityUser Tb tem DataNascimento
    public User() : base() { }
    



    // dentro do Identity nao tem DataNascimento 
    public DateTime DataNascimento { get; set; }

   


}

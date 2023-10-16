
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace UserApi.Controllers;




[ApiController]
[Route("[Controller]")]
public class AccessController : ControllerBase
{

    // Vai validar o nosso acesso apartir do token ||
    [HttpGet]
    [Authorize(Policy = "MinAge")]
    public IActionResult Get()
    {
        return Ok("Allow Access");
    }
}

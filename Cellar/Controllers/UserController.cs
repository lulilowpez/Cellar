using Common.DTOs;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace Cellar.Controllers
{
    [Route("Api/[Controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost]
        public IActionResult CreateUser([FromBody] CreateUserDto dto) //se le pasa por parametro los atributos del objeto -dto- por body
        {
            _userService.CreateUser(dto); //llamo al metodo del servicio que crea un usuario y le paso por parametro el nuevo usuario
            return Ok(dto);

        }
    }
}

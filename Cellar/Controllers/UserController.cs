using Microsoft.AspNetCore.Mvc;

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
        public IActionResult CreateUser([FromBody] CreateUserDto dto)
        {
            _userService.CreateUser(dto);
            return Ok(dto);

        }
    }
}

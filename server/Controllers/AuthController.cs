using server.Models;
using server.Services;
using Microsoft.AspNetCore.Mvc;

namespace server.Controllers{
    [ApiController]
    [Route("[controller]")]
    public class AuthController: ControllerBase{
        private readonly AuthService _service;

        public AuthController(AuthService service){
            _service = service;
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginUser (LoginDto user){
            var token = await _service.LoginUser(user);
            if (token==null){
                return BadRequest();
            }
            return Ok(token);
        }
        
        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] User user){
            var token = await _service.RegisterUser(user);
            return Ok(token);
        }
        
    }
}

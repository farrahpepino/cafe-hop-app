using server.Models;
using server.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;


namespace server.Controllers{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class UserController: ControllerBase{
        private readonly UserService _service;
        public UserController (UserService service){
            _service = service;
        }

        [HttpGet("email")]
        public async Task<IActionResult> GetUser(string email){
            var user = await _service.GetUser(email);
            if(user==null){
                return NotFound();
            }
            return Ok(user);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers(){
            var users = await _service.GetAllUsers();
            if (users==null){
                return NoContent();
            }
            return Ok(users);
        }


    }
}

       
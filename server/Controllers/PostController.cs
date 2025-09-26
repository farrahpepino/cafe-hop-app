using server.Models;
using server.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace server.Controllers{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class PostController: ControllerBase{
        private readonly PostService _service;
        public PostController(PostService service){
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePost([FromBody] Post post){
            await _service.CreatePost(post);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPosts(){
            var posts = await _service.GetAllPosts();
            if (posts==null){
                return NoContent();
            }
            return Ok(posts);
        }

        [HttpDelete]
        public async Task<IActionResult> DeletePost([FromQuery] string id){
            await _service.DeletePost(id);
            return NoContent();
        }

    }
}


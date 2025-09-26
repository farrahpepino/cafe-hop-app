using server.Models;
using server.Services;
using Microsoft.AspNetCore.Mvc;

namespace server.Controllers{
    [ApiController]
    [Route("[controller]")]
    public class PostController: ControllerBase{
        private readonly PostService _service;
        public PostController(PostService service){
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePost(Post post){
            var createdPost = await _service.CreatePost(post);
            return Ok(createdPost);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPosts(){
            var posts = await _service.GetAllPosts();
            if (posts==null){
                return NoContent();
            }
            return Ok(posts);
        }

    }
}


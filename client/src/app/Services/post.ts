import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class Post {
  
}



// [HttpPost]
// public async Task<IActionResult> CreatePost(Post post){
//     var createdPost = await _service.CreatePost(post);
//     return Ok(createdPost);
// }

// [HttpGet]
// public async Task<IActionResult> GetAllPosts(){
//     var posts = await _service.GetAllPosts();
//     if (posts==null){
//         return NoContent();
//     }
//     return Ok(posts);
// }
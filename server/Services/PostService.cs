using server.Models;
using server.Repositories;

namespace server.Services{
    public class PostService{
        
        private readonly IPostRepository _repository;

        public PostService(IPostRepository repository){
            _repository = repository;
        }

        public async Task CreatePost(Post post){
            await _repository.CreatePost(post);
        }

        public async Task<IEnumerable<PostDto>> GetAllPosts(){
            return await _repository.GetAllPosts();
        }   

        public async Task DeletePost(string id){
            await _repository.DeletePost(id);
        }
        
    }
}
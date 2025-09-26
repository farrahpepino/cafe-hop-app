using server.Models;
using server.Repositories;

namespace server.Services{
    public class PostService{
        
        private readonly IPostRepository _repository;

        public PostService(IPostRepository repository){
            _repository = repository;
        }

        public async Task<Post> CreatePost(Post post){
            return await _repository.CreatePost(post);
        }

        public async Task<IEnumerable<Post>> GetAllPosts(){
            return await _repository.GetAllPosts();
        }   
        
    }
}
using server.Models;

namespace server.Repositories{
    public interface IPostRepository{
        Task<Post> CreatePost(Post post);
        Task<IEnumerable<Post>> GetAllPosts();
        
    }
}
using server.Models;

namespace server.Repositories{
    public interface IPostRepository{
        Task CreatePost(Post post);
        Task<IEnumerable<PostDto>> GetAllPosts();
        Task DeletePost(string id);  
    }
}
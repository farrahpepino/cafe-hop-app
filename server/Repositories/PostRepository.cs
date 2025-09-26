using server.Data;
using server.Models;
using Microsoft.EntityFrameworkCore;


namespace server.Repositories{
    
    public class PostRepository: IPostRepository{
        private readonly AppDbContext _context;
        public PostRepository (AppDbContext context){
            _context = context;
        }

        public async Task<Post> CreatePost(Post post){
            _context.Posts.Add(post);
            await _context.SaveChangesAsync();
            return post;

        }

        public async Task<IEnumerable<Post>> GetAllPosts(){
            return await _context.Posts.ToListAsync();
        }
    }
}


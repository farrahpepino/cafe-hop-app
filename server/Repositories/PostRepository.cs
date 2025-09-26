using server.Data;
using server.Models;
using Microsoft.EntityFrameworkCore;


namespace server.Repositories{
    
    public class PostRepository: IPostRepository{
        private readonly AppDbContext _context;
        public PostRepository (AppDbContext context){
            _context = context;
        }

        public async Task CreatePost(Post post){
            _context.Posts.Add(post);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<PostDto>> GetAllPosts(){
            return await _context.Posts
                    .Include(post => post.User)
                    .Select(post => new PostDto{
                        Id= post.Id,
                        CafeName = post.CafeName,
                        Location = post.Location,
                        Content = post.Content,
                        CreatedAt = post.CreatedAt,
                        UserId = post.UserId,
                        Name = post.User.Name ?? string.Empty
                    })
                    .ToListAsync();
        }

        public async Task DeletePost(string id){
             var post = await _context.Posts.FindAsync(id);
            if (post != null){
                _context.Posts.Remove(post);
                await _context.SaveChangesAsync();
            }
        }
    }
}


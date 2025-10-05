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
            
            var posts = (from p in _context.Posts 
                        join u in _context.Users on p.UserId equals u.Id
                        orderby p.CreatedAt descending
                        select new PostDto {
                            Id= p.Id,
                            CafeName = p.CafeName,
                            Location = p.Location,
                            Content = p.Content,
                            CreatedAt = p.CreatedAt,
                            UserId = p.UserId,
                            Name = u.Name ?? string.Empty,
                            Rate = p.Rate 
                        });

            return posts;
        }

        public async Task DeletePost(string id){
             var post = (from p in _context.Posts
                        where p.Id == id
                        select p).FirstOrDefaultAsync();
             
            if (post != null){
                _context.Posts.Remove(post);
                await _context.SaveChangesAsync();
            }
        }
    }
}


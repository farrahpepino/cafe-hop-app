using server.Data;
using server.Models;
using Microsoft.EntityFrameworkCore;

namespace server.Repositories{
    public class UserRepository: IUserRepository{
        private readonly AppDbContext _context;
        public UserRepository (AppDbContext context){
            _context = context;
        }

        public async Task<UserDto> GetUser (string email){
            var user  = await (from u in _context.Users
                        where u.Email == email
                        select new UserDto{
                            Id = u.Id,
                            Name = u.Name,
                            Email = u.Email,
                            CreatedAt = u.CreatedAt
                        }).FirstOrDefaultAsync();

            return user;
        }

        public async Task<IEnumerable<UserDto>> GetAllUsers(){

             var users  = await (from u in _context.Users
                        select new UserDto{
                            Id = u.Id,
                            Name = u.Name,
                            Email = u.Email,
                            CreatedAt = u.CreatedAt
                        }).ToListAsync();

            return users;
        }
    }
}


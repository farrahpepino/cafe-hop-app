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
            return await _context.Users.Where(user=> user.Email == email)
                                        .Select(user => new UserDto{
                                            Id = user.Id,
                                            Name = user.Name,
                                            Email = user.Email,
                                            CreatedAt = user.CreatedAt
                                        })
                                        .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<UserDto>> GetAllUsers(){
            return await  _context.Users
                        .Select(user => new UserDto{
                            Id = user.Id,
                            Name = user.Name,
                            Email = user.Email,
                            CreatedAt = user.CreatedAt
                        })
                        .ToListAsync();
        }
    }
}


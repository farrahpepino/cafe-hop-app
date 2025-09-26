using server.Data;
using server.Models;
using Microsoft.EntityFrameworkCore;


namespace server.Repositories{
    public class UserRepository: IUserRepository{
        private readonly AppDbContext _context;
        public UserRepository (AppDbContext context){
            _context = context;
        }

        public async Task<User> GetUser (string email){
            return await _context.Users.FirstOrDefaultAsync(user=> user.Email == email);
        }

        public async Task<IEnumerable<User>> GetAllUsers(){
            return await _context.Users.ToListAsync(); 
        }
    }
}


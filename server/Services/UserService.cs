using server.Models;
using server.Repositories;

namespace server.Services{
    public class UserService{
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository){
            _repository = repository;
        }
        
        public async Task<User> GetUser (string email){
            return await _repository.GetUser(email);
        }

        public async Task<IEnumerable<User>> GetAllUsers(){
            return await _repository.GetAllUsers();
        }   
        
    }
}
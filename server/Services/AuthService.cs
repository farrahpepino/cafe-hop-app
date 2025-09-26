using server.Models;
using server.Services;
using server.Repositories;

namespace server.Services{
    public class AuthService{
        private readonly IAuthRepository _repository;
        private readonly IJwtService _jwtService;

        public AuthService(IAuthRepository repository, IJwtService jwtService){
            _repository = repository;
            _jwtService = jwtService;
        }

        public async Task<string> RegisterUser (User user){
            await _repository.RegisterUser(user);
            string token = _jwtService.GenerateToken(user.Email);
            return token;
        }

        public async Task<string> LoginUser (LoginDto user){
            var valid = await _repository.LoginUser(user);
            if (!valid){
                return null;
            }
            string token = _jwtService.GenerateToken(user.Email);
            return token;
        }
    }
}
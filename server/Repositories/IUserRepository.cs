using server.Models;

namespace server.Repositories{
    public interface IUserRepository{
        Task<UserDto> GetUser (string email);
        Task<IEnumerable<UserDto>> GetAllUsers ();
    }
}
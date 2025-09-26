using server.Models;

namespace server.Repositories{
    public interface IUserRepository{
        Task<User> GetUser (string email);
        Task<IEnumerable<User>> GetAllUsers ();
    }
}
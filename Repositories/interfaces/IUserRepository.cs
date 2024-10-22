using Delivery.Models;

namespace Delivery.Repository.Interface
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllUser();
        Task<User?> GetUserById(Guid id);
        Task<User?> UserAlreadyExist(string Email);
        Task<User> AddUser(User user);
        Task<User> UpdateUser(Guid id, User user);
        Task<bool> RemoveUser(Guid id);
    }
}
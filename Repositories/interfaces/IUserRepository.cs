using Delivery.Model.User;

namespace Delivery.Repository.Interface
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllUser();
        Task<User?> GetUserById(Guid id);
        Task<User?> UserAlreadyExist(string Email);
        Task<User> AddUser(User user);
        Task<User> UpdateUser(User user);
        Task<bool> RemoveUser(Guid ID);
    }
}
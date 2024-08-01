using Delivery.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using Delivery.Model.User;
using Delivery.Data;

namespace Delivery.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDBContext _dbContext;

        public UserRepository(AppDBContext appDBContext)
        {
            _dbContext = appDBContext;
        }

        public async Task<List<User>> GetAllUser()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<User?> GetUserById(Guid id)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(user => user.ID == id);
        }

        public async Task<User?> UserAlreadyExist(string email)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(user => user.Email == email);
        }

        public async Task<User> AddUser(User user)
        {
            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();
            return user;
        }

        public async Task<User> UpdateUser(User user)
        {
            _dbContext.Users.Update(user);
            await _dbContext.SaveChangesAsync();
            return user;
        }

        public async Task<bool> RemoveUser(Guid id)
        {
            var user = await _dbContext.Users.FindAsync(id);
            if (user == null)
            {
                return false;
            }

            _dbContext.Users.Remove(user);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}

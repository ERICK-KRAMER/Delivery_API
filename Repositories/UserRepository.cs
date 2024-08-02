using Delivery.Data;
using Delivery.Models;
using Delivery.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Delivery.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDBContext _dbContext;

        public UserRepository(AppDBContext context)
        {
            _dbContext = context;
        }

        public async Task<User> AddUser(User user)
        {
            if (user.Email != null)
            {
                var userAlreadyExist = await UserAlreadyExist(user.Email);
                if (userAlreadyExist == null)
                {
                    await _dbContext.Users.AddAsync(user);
                    await _dbContext.SaveChangesAsync();
                }
            }
            return user;
        }

        public async Task<List<User>> GetAllUser()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<User?> GetUserById(Guid id)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(user => user.ID == id);
        }

        public async Task<bool> RemoveUser(Guid id)
        {
            var findUser = await GetUserById(id);
            if (findUser != null)
            {
                _dbContext.Users.Remove(findUser);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<User> UpdateUser(Guid id, User user)
        {
            var findUser = await GetUserById(id);
            if (findUser != null)
            {
                findUser.Name = user.Name;
                findUser.Email = user.Email;
                await _dbContext.SaveChangesAsync();
            }
            return findUser!;
        }

        public async Task<User?> UserAlreadyExist(string email)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(user => user.Email == email);
        }
    }
}

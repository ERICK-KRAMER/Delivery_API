using Delivery.Data;
using Delivery.Helpers;
using Delivery.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Delivery.Repository
{
    public class LoginRepository : ILoginRepository
    {
        private readonly AppDBContext _dbContext;

        public LoginRepository(AppDBContext appDbContext)
        {
            _dbContext = appDbContext;
        }

        public async Task<bool> SignIn(string email, string password)
        {
            var findUser = await _dbContext.Users.FirstOrDefaultAsync(user => user.Email == email);
            if (findUser == null || findUser.Password == null)
            {
                throw new Exception("Email or Password incorrect!");
            }

            bool passwordMatch = PasswordHelper.VerifyPassword(findUser.Password, password);
            if (!passwordMatch)
            {
                throw new Exception("Email or Password incorrect!");
            }

            return true;
        }
    }
}

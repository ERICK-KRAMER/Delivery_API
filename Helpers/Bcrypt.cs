using BCrypt.Net;

namespace Delivery.Helpers;
public class PasswordHelper
{
    // Hash a senha usando BCrypt
    public static string HashPassword(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password);
    }

    public static bool VerifyPassword(string hashedPassword, string password)
    {
        return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
    }
}

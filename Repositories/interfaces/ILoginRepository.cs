namespace Delivery.Repository.Interface;

public interface ILoginRepository
{
    Task<bool> SignIn(string email, string password);

}
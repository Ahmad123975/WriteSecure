using WriteSecureFrontend.Model;

namespace WriteSecureFrontend.Managers
{
    public interface ILoginManger
    {
        Task<string> CreateUser(RegisterModel obj);
        Task<string> Login(LoginTb obj);
    }
}

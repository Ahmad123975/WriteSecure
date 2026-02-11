using WriteSecure.Models;

namespace WriteSecure.Managers.JwtTokenManager
{
    public interface ITokenManager
    {
        Task<string> CreateToken(User user);
    }
}

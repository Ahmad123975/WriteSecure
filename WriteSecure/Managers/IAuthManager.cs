using WriteSecure.DTOs;

namespace WriteSecure.Managers
{
    public interface IAuthManager
    {
        Task<string?> CreateUserAsync(UserDto register);
        Task<string?> LoginAsync(LoginDto login);

    }
}

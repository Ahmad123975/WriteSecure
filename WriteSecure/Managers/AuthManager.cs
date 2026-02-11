using WriteSecure.AppDbContext;
using WriteSecure.Common;
using WriteSecure.DTOs;
using WriteSecure.Managers.JwtTokenManager;
using WriteSecure.Mappers;

namespace WriteSecure.Managers
{
    public class AuthManager : IAuthManager
    {
        private readonly Applicationdbcontext _context;
        private readonly ITokenManager _tokenmanager;
        public AuthManager(Applicationdbcontext context, ITokenManager tokenmanager)
        {
            _context = context;
            _tokenmanager = tokenmanager;
        }
        public async Task<string> CreateUserAsync(UserDto register)
        {
            if (_context.UserRegistratoins.Any(x => x.Username == register.Username))
            {
                return "Credential is already Available";
            }
            var data = register.MaptoDomain();
            await _context.UserRegistratoins.AddAsync(data);
            await _context.SaveChangesAsync();
            return "Data Save Successfully";
        }

        public async Task<string> LoginAsync(LoginDto login)
        {
            var data = _context.UserRegistratoins.Where(x => x.Username == login.Credential || x.Email == login.Credential).FirstOrDefault();
            if (data != null)
            {
                if (PasswordEncyptorDecryptor.VerifyPasswordHash(login.Password, data.PasswordHash, data.PasswordSalt))
                {
                    return await _tokenmanager.CreateToken(data);
                }
                return "Credential Not Avalable";

            }
            return "Credential Not Avalable";

        }
    }
}

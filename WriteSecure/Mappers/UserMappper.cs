using WriteSecure.Common;
using WriteSecure.DTOs;
using WriteSecure.Models;

namespace WriteSecure.Mappers
{
    public static class UserMappper
    {
        public static User MaptoDomain(this UserDto userdto)
        {
            PasswordEncyptorDecryptor.CreatePasswordHashSalt(userdto.Password, out byte[] passwordHash, out byte[] passwordSalt);
            return new User
            {
                Id= Guid.NewGuid(),
                Username = userdto.Username,
                Email = userdto.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Role = RoleType.User,
            };
        }
    }
}

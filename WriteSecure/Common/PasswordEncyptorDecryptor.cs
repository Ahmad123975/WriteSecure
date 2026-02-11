using System.Security.Cryptography;

namespace WriteSecure.Common
{
    public static class PasswordEncyptorDecryptor
    {
        public static void CreatePasswordHashSalt(string Password,out byte[] PasswordHash,out byte[] PasswordSalt)
        {
            using var hmac=new HMACSHA512();
            PasswordSalt=hmac.Key;
            PasswordHash=hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(Password));
        }
        public static bool VerifyPasswordHash(string Password, byte[] PasswordHash, byte[] PasswordSalt)
        {
            using var hmac=new HMACSHA512(PasswordSalt);
            var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(Password));
            return computedHash.SequenceEqual(PasswordHash);
        }
    }
}

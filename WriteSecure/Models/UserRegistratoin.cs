namespace WriteSecure.Models
{
    public class UserRegistratoin
    {
        public Guid Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public byte[] PasswordHash { get; set; } 
        public byte[] PasswordSalt { get; set; }
        public RoleType Role { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace WriteSecureFrontend.Model
{
    public class LoginTb
    {
            [Required] public string Username { get; set; }
            [Required] public string Password { get; set; }
    }
}

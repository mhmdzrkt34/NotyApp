using System.ComponentModel.DataAnnotations;

namespace NotyApp.api.requests.AuthRequest
{
    public class SignInRequest
    {
        [EmailAddress]
        [Required]
        public string email { get; set; }


        [Required]
        [MinLength(10, ErrorMessage = "Password must be at least 10 characters long.")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[\W_]).{10,}$",
            ErrorMessage = "Password must be at least 10 characters long and contain at least one lowercase letter, one uppercase letter, one digit, and one special character.")]
        public string password { get; set; }
    }
}

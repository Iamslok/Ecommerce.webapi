using System.ComponentModel.DataAnnotations;

namespace demo.webapi.demo.Models
{
    public class LoginResponse
    {
        public LoginResponse()
        {
            ErrorMessage = string.Empty;
        }
        public bool IsSuccess => string.IsNullOrEmpty(ErrorMessage) && string.IsNullOrWhiteSpace(ErrorMessage);
        public string ErrorMessage { get; set; }
        public TokenModel TokenModel { get; set; }
    }

    public class TokenModel
    {
        public string Token { get; set; }
        public DateTime DateExpires { get; set; }
    }

    public class LoginDto
    {
        [Required]
        public string Email { get; set; }

        [Required]
        [StringLength(200)]
        public string Password { get; set; }
    }
}

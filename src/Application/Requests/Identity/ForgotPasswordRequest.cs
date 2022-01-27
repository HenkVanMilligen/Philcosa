using System.ComponentModel.DataAnnotations;

namespace TestApi2.Application.Requests.Identity
{
    public class ForgotPasswordRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;

namespace Philcosa.Application.Requests.Identity
{
    public class ForgotPasswordRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace ProduceDeliveryApp.Application.Accounts.Commands
{
    public class LoginCmd : IRequest<(bool status, string error)>
    {
        [Required(ErrorMessage = "Email or username is required")]
        [EmailAddress(ErrorMessage ="Please enter valid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage = "Password must be 8 characters or long")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}

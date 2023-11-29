using System.ComponentModel.DataAnnotations;

namespace ProduceDeliveryApp.Application.Accounts.Commands
{
    public class ResetPasswordCmd
    {
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage = "Password must be 8 characters or long")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password is required")]
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage = "Confirm Password must be 8 characters or long")]
        [Compare("Password",ErrorMessage ="Confirm Password must be matched")]
        public string ConfirmPassword { get; set; }
    }
}

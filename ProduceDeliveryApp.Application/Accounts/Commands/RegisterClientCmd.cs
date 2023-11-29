using MediatR;
using System;
using System.ComponentModel.DataAnnotations;

namespace ProduceDeliveryApp.Application.Accounts.Commands
{
    public class RegisterClientCmd : IRequest<Guid>
    {
        [Required(ErrorMessage = "First name is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Please enter valid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [MinLength(8, ErrorMessage = "Passwor is must be greater than 8 characters")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Confirm Password is required")]
        [MinLength(8, ErrorMessage = "Confirm Password is must be greater than 8 characters")]
        [Compare("Password",ErrorMessage ="Confirm Password must be matched")]
        public string ConfirmPassword { get; set; }

        public Guid? ImageId { get; set; }

    }
}

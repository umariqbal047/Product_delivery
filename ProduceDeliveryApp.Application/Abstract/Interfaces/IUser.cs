using System;

namespace ProduceDeliveryApp.Application.Abstract.Interfaces
{
    public interface IUser
    {
        Guid Id { get; set; }
        bool IsActive { get; set; }
        string UserName { get; set; }
        string Email { get; set; }
        bool EmailConfirmed { get; set; }
        string PhoneNumber { get; set; }
        bool PhoneNumberConfirmed { get; set; }
    }

}

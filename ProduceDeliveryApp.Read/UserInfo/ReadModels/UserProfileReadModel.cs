
using ProduceDeliveryApp.Domain.Enums;
using System;

namespace ProduceDeliveryApp.DataRead.UsersInfo.ReadModels
{
    public class UserProfileReadModel
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public byte RoleId { get; set; }
        public Guid ImageId { get; set; }
        public DateTime CreatedOn { get; set; }

    }
}

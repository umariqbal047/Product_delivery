using ProduceDeliveryApp.Application.Abstract.Interfaces;
using ProduceDeliveryApp.Persistence.IdentityModels;
using System;

namespace ESchool.Domain.IdentityModels
{
    public class UserFactory : IUserFactory
    {
        public IUser CreateUser(
            Guid id,
            bool isActive,
            string userName,
            string email,
            bool emailConfirmed = false)
        {
            return new ApplicationUser
            {
                Id = id,
                IsActive = isActive,
                UserName = userName,
                Email = email,
                EmailConfirmed = emailConfirmed,
            };
        }
    }
}

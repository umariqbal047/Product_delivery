using System;

namespace ProduceDeliveryApp.Application.Abstract.Interfaces
{
    public interface IUserFactory
    {
        IUser CreateUser(
            Guid id,
            bool isActive,
            string userName,
            string email,
            bool emailConfirmed = false);
    }
}

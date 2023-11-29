using ProduceDeliveryApp.Domain.Enums;
using System;

namespace ProduceDeliveryApp.Application.Abstract.Interfaces
{
    public interface ICurrentUser
    {
        Guid Id { get; }
        bool IsAuthenticated { get; }
        RoleType Role { get; }
        string RequestIP { get; }
    }
}

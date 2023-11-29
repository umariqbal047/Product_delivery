using Microsoft.AspNetCore.Identity;
using ProduceDeliveryApp.Application.Abstract.Interfaces;
using System;

namespace ProduceDeliveryApp.Persistence.IdentityModels
{
    public class ApplicationUser : IdentityUser<Guid>, IUser
    {
        public bool IsActive { get; set; }
    }
}

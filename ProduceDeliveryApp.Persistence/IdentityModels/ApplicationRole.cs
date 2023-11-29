using Microsoft.AspNetCore.Identity;
using System;

namespace ProduceDeliveryApp.Persistence.IdentityModels
{
    public class ApplicationRole : IdentityRole<Guid>
    {
        public ApplicationRole()
        {
        }

        public ApplicationRole(string name)
            : base(name)
        {
        }
    }
}

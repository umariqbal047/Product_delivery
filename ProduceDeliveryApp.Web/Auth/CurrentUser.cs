using Microsoft.AspNetCore.Http;
using ProduceDeliveryApp.Application.Abstract.Interfaces;
using ProduceDeliveryApp.Domain.Enums;
using System;
using System.Linq;

namespace ProduceDeliveryApp.Web.Auth
{
    public class CurrentUser : ICurrentUser
    {
        private readonly IHttpContextAccessor _accessor;

        public CurrentUser(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        public Guid Id => _accessor.HttpContext.User.UserId();
        public bool IsAuthenticated => Id != Guid.Empty;
        public RoleType Role => GetRole();
        public string RequestIP => GetClientIP();
        public bool IsInRole(RoleType role)
        {
            return _accessor?.HttpContext?.User?.IsInRole(role.ToString()) ?? false;
        }

        private RoleType GetRole()
        {
            RoleType[] Roles = Enum.GetValues(typeof(RoleType))
                .Cast<RoleType>()
                .ToArray();

            var actorRole = Roles.FirstOrDefault(IsInRole);
            return actorRole;
        }

        private string GetClientIP()
        {
            return _accessor?.HttpContext?.Connection.RemoteIpAddress.ToString();
        }
    }
}

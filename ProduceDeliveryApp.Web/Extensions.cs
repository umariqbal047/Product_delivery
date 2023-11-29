using Microsoft.AspNetCore.Identity;
using ProduceDeliveryApp.Application.Abstract.Interfaces;
using ProduceDeliveryApp.Web.Auth;
using System;
using System.Linq;
using System.Security.Claims;

namespace ProduceDeliveryApp.Web
{
    public static class Extensions
    {
        public static IIdentityResult ToResult(this IdentityResult result)
        {
            return new IdResult(result);
        }

        public static Guid UserId(this ClaimsPrincipal user)
        {
            var claim = user.Claims.FirstOrDefault(t => t.Type == ClaimTypes.NameIdentifier)?.Value;
            return Guid.TryParse(claim, out var result) ? result : default;
        }
    }
}

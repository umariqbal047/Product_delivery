﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using ProduceDeliveryApp.Persistence.IdentityModels;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProduceDeliveryApp.Web.Auth
{
    public class LoginInfo
    {
        public string Email { get; set; }

        public string Password { get; set; }
    }

    public class LoginMiddleware
    {
        public static IDictionary<Guid, LoginInfo> Logins { get; private set; }
            = new ConcurrentDictionary<Guid, LoginInfo>();

        private readonly RequestDelegate _next;

        public LoginMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, SignInManager<ApplicationUser> signInMgr)
        {
            if (context.Request.Path == "/login" && context.Request.Query.ContainsKey("key"))
            {
                var key = Guid.Parse(context.Request.Query["key"]);
                var info = Logins[key];

                var result = await signInMgr.PasswordSignInAsync(info.Email, info.Password, false, lockoutOnFailure: true);
                info.Password = null;
                if (result.Succeeded)
                {
                    Logins.Remove(key);
                    context.Response.Redirect("/home");
                    return;
                }
                else if (result.RequiresTwoFactor)
                {
                    //TODO: redirect to 2FA razor component
                    context.Response.Redirect("/loginwith2fa/" + key);
                    return;
                }
                else
                {
                    //TODO: Proper error handling
                    context.Response.Redirect("/loginfailed");
                    return;
                }
            }
            else
            {
                await _next.Invoke(context);
            }
        }
    }
}

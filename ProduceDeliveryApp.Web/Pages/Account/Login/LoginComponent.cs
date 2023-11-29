using Blazored.Toast.Services;
using MediatR;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using ProduceDeliveryApp.Application.Abstract.Interfaces;
using ProduceDeliveryApp.Application.Accounts.Commands;
using ProduceDeliveryApp.Persistence.IdentityModels;
using ProduceDeliveryApp.Web.Auth;
using System;
using System.Threading.Tasks;

namespace ProduceDeliveryApp.Web.Pages.Account.Login
{

    public class LoginComponent : ComponentBase
    {
        [Inject]
        public IMediator _mediator { get; set; }

        [Inject]
        private ICurrentUser _user { get; set; }

        [Inject]
        private NavigationManager _navManager { get; set; }

        [Inject]
        SignInManager<ApplicationUser> SignInMgr { get; set; }

        [Inject]
        UserManager<ApplicationUser> UserMgr { get; set; }

        [Inject]
        public IToastService toastService { get; set; }

        protected bool loading;
        protected string error;
        public LoginCmd loginCmd { get; set; }
        protected override Task OnInitializedAsync()
        {
            loginCmd = new LoginCmd();
            return base.OnInitializedAsync();
        }

        protected async Task LogInForm()
        {
            loading = true;
            try
            {
                if (!_user.IsAuthenticated)
                {
                    await SignInMgr.SignOutAsync();
                    //return;
                }

                var usr = await UserMgr.FindByEmailAsync(loginCmd.Email);

                if (await SignInMgr.CanSignInAsync(usr))
                {
                    var result = await SignInMgr.CheckPasswordSignInAsync(usr, loginCmd.Password, true);
                    if (result == SignInResult.Success)
                    {
                        Guid key = Guid.NewGuid();
                        LoginMiddleware.Logins[key] = new LoginInfo { Email = loginCmd.Email, Password = loginCmd.Password };
                        _navManager.NavigateTo($"/login?key={key}", true);
                    }
                    else
                    {
                        loading = false;
                        error = "Login failed. Check your password.";
                    }
                }
                else
                {
                    loading = false;
                    error = "Your account is blocked";
                }
            }
            catch (Exception ex)
            {
                loading = false;
                toastService.ShowError(ex.ToString(), "Failure!");
            }
        }
    }
}

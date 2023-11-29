using Microsoft.AspNetCore.Components;
using ProduceDeliveryApp.Application.Accounts.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProduceDeliveryApp.Web.Pages.Account.ResetPassword
{
    public class ResetPasswordComponent : ComponentBase
    {
       public ResetPasswordCmd clientCmd { get; set; }
        protected override Task OnInitializedAsync()
        {
            clientCmd = new ResetPasswordCmd();
            return base.OnInitializedAsync();
        }
        protected void ResetPassword()
        {
            var a = clientCmd.Password;
            var b = clientCmd.ConfirmPassword;

        }
    }
}

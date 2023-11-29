using Microsoft.AspNetCore.Components;
using ProduceDeliveryApp.Application.Accounts.Commands;
using System.Threading.Tasks;

namespace ProduceDeliveryApp.Web.Pages.Account.RecoverPassword
{
    public class RecoverPasswordComponent : ComponentBase
    {
      public  RecoverPasswordCmd resetCmd { get; set; }
        protected override Task OnInitializedAsync()
        {
             resetCmd = new RecoverPasswordCmd();
            return base.OnInitializedAsync();

        }
        protected void ResetPassword()
        {
            var a = resetCmd.Email;
        }
    }
}

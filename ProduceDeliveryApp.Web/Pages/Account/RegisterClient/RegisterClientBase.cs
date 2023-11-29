using Blazored.Toast.Services;
using MediatR;
using Microsoft.AspNetCore.Components;
using ProduceDeliveryApp.Application.Accounts.Commands;
using System;
using System.Threading.Tasks;

namespace ProduceDeliveryApp.Web.Pages.Account.RegisterClient
{
    public class RegisterClientBase : ComponentBase
    {
        [Inject]
        public IMediator _mediator { get; set; }

        [Inject]
        public IToastService toastService { get; set; }

        public RegisterClientCmd clientCmd { get; set; }

        protected bool loading;
        protected override Task OnInitializedAsync()
        {
            clientCmd = new RegisterClientCmd();
            return base.OnInitializedAsync();
        }
        protected async Task Signup()
        {
            try
            {
                loading = true;
                var guid = await _mediator.Send(clientCmd);
                if (guid != Guid.Empty)
                {
                    toastService.ShowSuccess("User registered successfuly", "Success!");
                }
                else
                {
                    toastService.ShowError("Registration failed", "Failure!");
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

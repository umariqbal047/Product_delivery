using MediatR;
using Microsoft.AspNetCore.Components;
using ProduceDeliveryApp.DataRead.UsersInfo.Queries;
using ProduceDeliveryApp.DataRead.UsersInfo.ReadModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProduceDeliveryApp.Web.Pages.Account.ClientsList
{
    public class ClientsListCompnentBase : ComponentBase
    {
        [Inject]
        public IMediator _mediator { get; set; }
        public IEnumerable<UserReadModel> ClientList { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await Task.Run(LoadClientsAsync);
            //base.OnInitializedAsync();
        }

        private async Task LoadClientsAsync()
        {
            ClientList = await _mediator.Send(new GetUserList());
        }
    }
}

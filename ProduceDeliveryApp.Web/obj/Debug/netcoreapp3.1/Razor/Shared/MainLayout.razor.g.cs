#pragma checksum "D:\PersonalProjects\produce-delivery\Produce-Delivery-App\ProduceDeliveryApp.Web\Shared\MainLayout.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "695b128c2e4de1a0a002d76499921d3cac2e95b3"
// <auto-generated/>
#pragma warning disable 1591
namespace ProduceDeliveryApp.Web.Shared
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "D:\PersonalProjects\produce-delivery\Produce-Delivery-App\ProduceDeliveryApp.Web\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\PersonalProjects\produce-delivery\Produce-Delivery-App\ProduceDeliveryApp.Web\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\PersonalProjects\produce-delivery\Produce-Delivery-App\ProduceDeliveryApp.Web\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\PersonalProjects\produce-delivery\Produce-Delivery-App\ProduceDeliveryApp.Web\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\PersonalProjects\produce-delivery\Produce-Delivery-App\ProduceDeliveryApp.Web\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\PersonalProjects\produce-delivery\Produce-Delivery-App\ProduceDeliveryApp.Web\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "D:\PersonalProjects\produce-delivery\Produce-Delivery-App\ProduceDeliveryApp.Web\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "D:\PersonalProjects\produce-delivery\Produce-Delivery-App\ProduceDeliveryApp.Web\_Imports.razor"
using ProduceDeliveryApp.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "D:\PersonalProjects\produce-delivery\Produce-Delivery-App\ProduceDeliveryApp.Web\_Imports.razor"
using ProduceDeliveryApp.Web.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "D:\PersonalProjects\produce-delivery\Produce-Delivery-App\ProduceDeliveryApp.Web\_Imports.razor"
using Blazored.Toast;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "D:\PersonalProjects\produce-delivery\Produce-Delivery-App\ProduceDeliveryApp.Web\_Imports.razor"
using Blazored.Toast.Services;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "D:\PersonalProjects\produce-delivery\Produce-Delivery-App\ProduceDeliveryApp.Web\_Imports.razor"
using MatBlazor;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "D:\PersonalProjects\produce-delivery\Produce-Delivery-App\ProduceDeliveryApp.Web\Shared\MainLayout.razor"
using Blazored.Toast.Configuration;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\PersonalProjects\produce-delivery\Produce-Delivery-App\ProduceDeliveryApp.Web\Shared\MainLayout.razor"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\PersonalProjects\produce-delivery\Produce-Delivery-App\ProduceDeliveryApp.Web\Shared\MainLayout.razor"
using ProduceDeliveryApp.Persistence.IdentityModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\PersonalProjects\produce-delivery\Produce-Delivery-App\ProduceDeliveryApp.Web\Shared\MainLayout.razor"
using ProduceDeliveryApp.Application.Abstract.Interfaces;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\PersonalProjects\produce-delivery\Produce-Delivery-App\ProduceDeliveryApp.Web\Shared\MainLayout.razor"
using ProduceDeliveryApp.DataRead.UsersInfo.Queries;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\PersonalProjects\produce-delivery\Produce-Delivery-App\ProduceDeliveryApp.Web\Shared\MainLayout.razor"
using MediatR;

#line default
#line hidden
#nullable disable
    public partial class MainLayout : LayoutComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "div");
            __builder.AddAttribute(1, "class", "sidebar");
            __builder.AddMarkupContent(2, "\r\n    ");
            __builder.OpenComponent<ProduceDeliveryApp.Web.Shared.NavMenu>(3);
            __builder.CloseComponent();
            __builder.AddMarkupContent(4, "\r\n");
            __builder.CloseElement();
            __builder.AddMarkupContent(5, "\r\n\r\n");
            __builder.OpenElement(6, "div");
            __builder.AddAttribute(7, "class", "main");
            __builder.AddMarkupContent(8, "\r\n    ");
            __builder.OpenElement(9, "div");
            __builder.AddAttribute(10, "class", "top-row px-4");
            __builder.AddMarkupContent(11, "\r\n");
#nullable restore
#line 18 "D:\PersonalProjects\produce-delivery\Produce-Delivery-App\ProduceDeliveryApp.Web\Shared\MainLayout.razor"
         if (_currentUser.IsAuthenticated)
        {

#line default
#line hidden
#nullable disable
            __builder.AddContent(12, "            ");
            __builder.OpenElement(13, "a");
            __builder.AddAttribute(14, "href", "/");
            __builder.AddContent(15, "Logout ");
            __builder.AddContent(16, 
#nullable restore
#line 20 "D:\PersonalProjects\produce-delivery\Produce-Delivery-App\ProduceDeliveryApp.Web\Shared\MainLayout.razor"
                                username

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(17, "\r\n");
#nullable restore
#line 21 "D:\PersonalProjects\produce-delivery\Produce-Delivery-App\ProduceDeliveryApp.Web\Shared\MainLayout.razor"
        }
        else
        {

#line default
#line hidden
#nullable disable
            __builder.AddContent(18, "            ");
            __builder.AddMarkupContent(19, "<a href=\"registration\">Register</a>\r\n");
#nullable restore
#line 25 "D:\PersonalProjects\produce-delivery\Produce-Delivery-App\ProduceDeliveryApp.Web\Shared\MainLayout.razor"
        }

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(20, "\r\n    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(21, "\r\n\r\n    ");
            __builder.OpenElement(22, "div");
            __builder.AddAttribute(23, "class", "content px-4");
            __builder.AddMarkupContent(24, "\r\n        ");
            __builder.AddContent(25, 
#nullable restore
#line 31 "D:\PersonalProjects\produce-delivery\Produce-Delivery-App\ProduceDeliveryApp.Web\Shared\MainLayout.razor"
         Body

#line default
#line hidden
#nullable disable
            );
            __builder.AddMarkupContent(26, "\r\n    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(27, "\r\n");
            __builder.CloseElement();
            __builder.AddMarkupContent(28, "\r\n\r\n\r\n");
            __builder.OpenComponent<Blazored.Toast.BlazoredToasts>(29);
            __builder.AddAttribute(30, "Position", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Blazored.Toast.Configuration.ToastPosition>(
#nullable restore
#line 45 "D:\PersonalProjects\produce-delivery\Produce-Delivery-App\ProduceDeliveryApp.Web\Shared\MainLayout.razor"
                          ToastPosition.BottomRight

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(31, "Timeout", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Int32>(
#nullable restore
#line 46 "D:\PersonalProjects\produce-delivery\Produce-Delivery-App\ProduceDeliveryApp.Web\Shared\MainLayout.razor"
                         5

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(32, "IconType", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Blazored.Toast.IconType?>(
#nullable restore
#line 47 "D:\PersonalProjects\produce-delivery\Produce-Delivery-App\ProduceDeliveryApp.Web\Shared\MainLayout.razor"
                          IconType.FontAwesome

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(33, "SuccessClass", "success-toast-override");
            __builder.AddAttribute(34, "ErrorIcon", "fa fa-bug");
            __builder.CloseComponent();
        }
        #pragma warning restore 1998
#nullable restore
#line 35 "D:\PersonalProjects\produce-delivery\Produce-Delivery-App\ProduceDeliveryApp.Web\Shared\MainLayout.razor"
      

    private string username;
    protected override async Task OnInitializedAsync()
    {
        var user = await _mediator.Send(new GetUserProfile(_currentUser.Id));
        username = user.Email;
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IMediator _mediator { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private SignInManager<ApplicationUser> _signInManager { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private ICurrentUser _currentUser { get; set; }
    }
}
#pragma warning restore 1591
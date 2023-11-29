using Autofac;
using ProduceDeliveryApp.Application.Abstract.Interfaces;
using ProduceDeliveryApp.Web.Auth;

namespace ProduceDeliveryApp.Web
{
    public class IocModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<UserManagerDecorator>().As<IUserManager>();
            builder.RegisterType<CurrentUser>().As<ICurrentUser>();
        }
    }
}

using Autofac;
using ESchool.Domain.IdentityModels;
using ProduceDeliveryApp.Application.Abstract.Interfaces;

namespace ProduceDeliveryApp.Persistence
{
    public class IocModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<TransactionManager>().As<ITransactionManager>();
            builder.RegisterType<BasicTransaction>().As<ITransaction>();
            builder.RegisterType<UserFactory>().As<IUserFactory>();
        }
    }
}

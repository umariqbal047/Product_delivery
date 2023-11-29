using Autofac;
using AutoMapper;
using ProduceDeliveryApp.Application.Abstract;

namespace ProduceDeliveryApp.Web.Configuration
{
    public class AutoMapperConfig : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddMaps(Assemblies.Get());
                cfg.IgnoreUnmapped();
            });

            config.AssertConfigurationIsValid();
                
            var mapper = new Mapper(config);

            builder.Register(c => mapper).As<IMapper>()
                .InstancePerLifetimeScope()
                .PropertiesAutowired()
                .PreserveExistingDefaults();
        }
    }

}

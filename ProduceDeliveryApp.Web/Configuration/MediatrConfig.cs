using Autofac;
using MediatR;
using System;
using System.Collections.Generic;

namespace ProduceDeliveryApp.Web.Configuration
{
    public class MediatrConfig : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterAssemblyTypes(typeof(IMediator).Assembly).AsImplementedInterfaces();

            var mediatrOpenTypes = new[]
            {
                typeof(IRequestHandler<,>),
                typeof(INotificationHandler<>),
            };

            foreach (var assembly in Assemblies.Get())
            {
                foreach (var mediatrOpenType in mediatrOpenTypes)
                {
                    builder
                        .RegisterAssemblyTypes(assembly)
                        .AsClosedTypesOf(mediatrOpenType)
                        .AsImplementedInterfaces();
                }
            }

            builder.Register<ServiceFactory>(ctx =>
            {
                var c = ctx.Resolve<IComponentContext>();
                return t => TryGetAllInstances(c, t);
            });
        }

        private static object TryGetAllInstances(IComponentContext ctx, Type t)
        {
            // resolve handlers that handle IEvent instead of concrete type of event
            if (t.IsGenericType && t.GetGenericTypeDefinition() == typeof(IEnumerable<>))
            {
                var handlerType = t.GenericTypeArguments[0];
                var requestType = handlerType.GenericTypeArguments[0];

                //if (requestType.GetInterfaces().Contains(typeof(IEvent)))
                //{
                //    return ctx.Resolve<IEnumerable<INotificationHandler<IEvent>>>(); //TODO: concatenate IEvent handlers with the concrete type handlers
                //}
            }

            return ctx.Resolve(t);
        }
    }
}

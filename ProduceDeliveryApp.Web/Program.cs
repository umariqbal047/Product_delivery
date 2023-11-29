using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore;
using ProductDeliveryApp.Infrastructure;
using ProduceDeliveryApp.Web.Configuration;
using Serilog;

namespace ProduceDeliveryApp.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var cfg = AppConfig.Get(args);
            SerilogConfig.InitGlobalLogger(cfg);

            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseSerilog()
                .UseStartup<Startup>()
                .ConfigureServices(services => services.AddAutofac())
                .Build();

    }
}

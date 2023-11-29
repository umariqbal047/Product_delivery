using Microsoft.Extensions.Configuration;
using Serilog;

namespace ProduceDeliveryApp.Web.Configuration
{
    public class SerilogConfig
    {
        public static void InitGlobalLogger(IConfiguration cfg)
        {
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(cfg) //load from configuration
                .Enrich.FromLogContext()
                .CreateLogger();
        }
    }
}

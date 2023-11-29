using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace ProductDeliveryApp.Infrastructure
{
    public class AppConfig
    {
        public static IConfiguration Get(string[] args)
        {
            // The configuration is required when IoC is not initialized yet
            // Otherwise it would be yet another IoC Module
            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production";

            return new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false, true)
                .AddJsonFile($"appsettings.{env}.json", true)
                .AddEnvironmentVariables()
                .AddCommandLine(args)
                .Build();
        }
    }
}

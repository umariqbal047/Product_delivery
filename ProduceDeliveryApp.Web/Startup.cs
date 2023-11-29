using Autofac;
using Blazored.Toast;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ProduceDeliveryApp.Application.Abstract.Interfaces;
using ProduceDeliveryApp.Data;
using ProduceDeliveryApp.Persistence;
using ProduceDeliveryApp.Persistence.IdentityModels;
using ProduceDeliveryApp.Web.Auth;
using Serilog;

namespace ProduceDeliveryApp.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            var conStr = Configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<ProduceDeliveryAppDataContext>(options =>
            options.UseSqlServer(conStr), ServiceLifetime.Scoped);

            services.AddHttpContextAccessor();

            services.AddScoped<IProduceDeliveryAppDataContext>(provider => provider.GetService<ProduceDeliveryAppDataContext>());

            services.AddIdentity<ApplicationUser, ApplicationRole>()
                .AddEntityFrameworkStores<ProduceDeliveryAppDataContext>()
                .AddDefaultTokenProviders();

            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddSingleton<WeatherForecastService>();
            services.AddBlazoredToast();
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterAssemblyModules(Assemblies.Get());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseSerilogRequestLogging();

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            //auth
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseMiddleware<LoginMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}

using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using WalutyBusinessLogic.DatabaseLoading;
using WalutyBusinessLogic.LoadingFromFile;


namespace WalutyMVCWebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
           var hostBuilder = CreateWebHostBuilder(args).Build();

            using (var scope = hostBuilder.Services.CreateScope())
            {
                try
                {
                    var services = scope.ServiceProvider;

                    var context = services.GetRequiredService<WalutyDBContext>();
                    var loader = services.GetRequiredService<ILoader>();

                    DBInitialization.InitialiseDB(context, loader);
                }
                catch (Exception)
                {
                    Console.WriteLine("Failed to initalise DB");
                }
            }

            hostBuilder.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            .ConfigureLogging((hostingContext, config) =>
            {
                config.ClearProviders();
            })
            .UseStartup<Startup>();
    }
}

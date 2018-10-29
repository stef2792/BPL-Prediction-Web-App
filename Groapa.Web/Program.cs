using Groapa.Domain.DataService;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Groapa.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = BuildWebHost(args);

            RunSeed(host);

            host.Run();
        }

        private static void RunSeed(IWebHost host)
        {
            var scopeFactory = host.Services.GetService<IServiceScopeFactory>();

            using (var scope = scopeFactory.CreateScope())
            {
                var seeder = scope.ServiceProvider.GetService<MatchesSeeder>();
                seeder.Seed().Wait();
            }
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration(SetupConfiguration)
                .UseStartup<Startup>()
                .Build();

        private static void SetupConfiguration(WebHostBuilderContext ctx, IConfigurationBuilder builder)
        {
            //Remove the default config options
            builder.Sources.Clear();

            builder.AddJsonFile("config.json",false,true)
                   .AddEnvironmentVariables();
        }
    }
}

using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using InterActMobilityCommon.Data.Contexts;

namespace InteractActMobilityDeploy
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args)
        {
            var host = WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();

            using (var scope = host.Services.CreateScope())
            {
                var initializer = scope.ServiceProvider.GetService<MasterDbInitializer>();
                initializer.Seed();
            }

            return host;
        }
    }
}

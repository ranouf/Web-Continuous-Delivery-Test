using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace WebJob1
{
    public class Program
    {
        static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile("appsettings.Development.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();

            var jobHostConfiguration = new JobHostConfiguration
            {
                DashboardConnectionString = configuration.GetConnectionString("AzureWebJobsDashboard"),
                StorageConnectionString = configuration.GetConnectionString("AzureWebJobsStorage")
            };

            var host = new JobHost(jobHostConfiguration);
            host.Call(typeof(Program).GetMethod("Execute"));
        }

        [NoAutomaticTrigger]
        public static void Execute(TextWriter logger)
        {
            logger.WriteLine("Hello World 3");
        }
    }
}

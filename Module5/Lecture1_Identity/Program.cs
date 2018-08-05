using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Lecture1_Identity
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()  
                .AddCommandLine(args)
                .Build();
            CreateWebHostBuilder(args, config)
            .Build()
            .Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args, IConfigurationRoot config) =>
            WebHost.CreateDefaultBuilder(args)
                .UseConfiguration(config)
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>();

        // EF Migrations
        public static IWebHost BuildWebHost(string[] args)
        {
            return WebHost.CreateDefaultBuilder()
                .ConfigureAppConfiguration((ctx, cfg) =>
                {
                cfg.SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", true)
                    .AddEnvironmentVariables();
                })
                .ConfigureLogging((ctx, logging) => { })
                .UseStartup<Startup>()
                .UseSetting("DesignTime", "true")
                .Build();
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Lecture1_EntityFramework_Basics
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
                    .AddJsonFile("appsettings.json", true) // require the json file!
                    .AddEnvironmentVariables();
                })
                .ConfigureLogging((ctx, logging) => { }) // No logging
                .UseStartup<Startup>()
                .UseSetting("DesignTime", "true")
                .Build();
        }

        
        //public IConfiguration config { get; }
        // public static void Main(string[] args)
        // {            
        //     var builder = new WebHostBuilder()
        //         .UseKestrel()
        //         .UseContentRoot(Directory.GetCurrentDirectory())
        //         .ConfigureAppConfiguration((hostingContext, config) =>
        //         {
        //             var env = hostingContext.HostingEnvironment;

        //             config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
        //                     .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true);

        //             if (env.IsDevelopment())
        //             {
        //                 var appAssembly = Assembly.Load(new AssemblyName(env.ApplicationName));
        //                 if (appAssembly != null)
        //                 {
        //                     config.AddUserSecrets(appAssembly, optional: true);
        //                 }
        //             }

        //             config.AddEnvironmentVariables();

        //             if (args != null)
        //             {
        //                 config.AddCommandLine(args);
        //             }
        //         })
        //         .ConfigureLogging((hostingContext, logging) =>
        //         {
        //             logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
        //             logging.AddConsole();
        //             logging.AddDebug();
        //         })
        //         .UseIISIntegration()
        //         .UseDefaultServiceProvider((context, options) =>
        //         {
        //             options.ValidateScopes = context.HostingEnvironment.IsDevelopment();
        //         });
        // }
    }
}

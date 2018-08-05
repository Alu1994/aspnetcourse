using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace Lecture2
{
    public class Startup
    {
        private IConfigurationRoot _configuration;

        public Startup(IHostingEnvironment env){
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json");

            builder.AddEnvironmentVariables();

            _configuration = builder.Build();
        }

        public void Configure(IApplicationBuilder app){
            
            var applicationName = _configuration.GetValue<string>("ApplicationName");

            app.Run(context => context.Response.WriteAsync($"Ola Mundo {applicationName}"));
        }
    }
}
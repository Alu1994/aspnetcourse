using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lecture1_EntityFramework_Basics.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Lecture1_EntityFramework_Basics
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();                
            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            // Initialize Mvc
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            // Initialize Configs
            services.AddSingleton<IConfiguration>(Configuration);

            // Initialize DbContext
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
                Configuration.GetConnectionString("BancoDeDados")
            ));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (Configuration["DesignTime"] != "true")
            {
                using (var scope = app.ApplicationServices.CreateScope())
                {
                    var initializer = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                    //initializer.RunAsync().Wait();
                }
            }
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}")
                    .MapRoute(
                        name: "about-rout", 
                        template: "about", 
                        defaults: new { controller = "Home", action = "About" }
                    )
                    .MapRoute(
                        name: "contact-rout", 
                        template: "contact", 
                        defaults: new { controller = "Home", action = "Contact" }
                    )
                    .MapRoute(
                        name: "product-save", 
                        template: "product", 
                        defaults: new { controller = "Product", action = "Save" }
                    )
                    .MapRoute(
                        name: "category-save", 
                        template: "category", 
                        defaults: new { controller = "Category", action = "Register" }
                    );
            });
        }
    }
}

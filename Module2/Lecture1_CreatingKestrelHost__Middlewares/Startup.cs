using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace Lecture1
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app){

            // app.Use(async (context, next) => {
            //     context.Response.Headers.Add("Middleware", "APRENDENDO");

            //     await next.Invoke();
            // });
            
            app.UseMiddleware<MyMiddleware>();

            app.Run(context => context.Response.WriteAsync("Ola Mundo 2 | "));
        }
    }
}
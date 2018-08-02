using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Lecture1
{
    public class MyMiddleware
    {
        private RequestDelegate _next;

        public MyMiddleware(RequestDelegate next){
            _next = next;
        }

        public async Task Invoke(HttpContext context){


            //Request
            var start = DateTime.Now;
            
            // Parallel.For(0, 9_000_000_000, i => {
                
            // });

            await _next(context);

            //Response
            var finish = DateTime.Now;
            var diff = finish.Subtract(start);

            await context.Response.WriteAsync($"The time was {diff.Seconds}");
        }
    }
}
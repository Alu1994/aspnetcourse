using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace Lecture2
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseStartup<Startup>()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .Build();

            host.Run();
        }
    }
}

using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace Lecture3
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

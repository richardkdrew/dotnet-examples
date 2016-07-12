using Microsoft.AspNetCore.Hosting;

namespace Kestrel
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseKestrel(options => {
                    options.UseHttps("testCert.pfx", "testPassword");
                })
                .UseUrls("https://localhost:5000")               
                .UseStartup<Startup>()               
                .Build();

            host.Run();
        }
    }
}

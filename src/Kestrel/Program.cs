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
                .UseStartup<Startup>()               
                .Build();

            host.Run();
        }
    }
}

using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Hosting;

namespace Kestrel
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .AddEnvironmentVariables(prefix: "ASPNETCORE_")
                .Build();     

            var certificate = config["SSL.CERT"];
            var password = config["SSL.CERT.PASSWORD"];

            var host = new WebHostBuilder()
                .UseKestrel(options => {
                    options.UseHttps(certificate, password);
                })           
                .UseStartup<Startup>()               
                .Build();

            host.Run();
        }
    }
}

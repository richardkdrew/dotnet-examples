using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Hosting;

namespace Kestrel
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var loggerFactory = new LoggerFactory()
                .AddConsole();
            var logger = loggerFactory.CreateLogger<Program>();            

            var config = new ConfigurationBuilder()
                .AddEnvironmentVariables(prefix: "ASPNETCORE_")
                .Build();     

            var certificate = config["SSL.CERT"];
            var password = config["SSL.CERT.PASSWORD"];

            if(string.IsNullOrEmpty(certificate) || string.IsNullOrEmpty(password))
            {
                logger.LogError("No certificate and/or password supplied");
            }

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

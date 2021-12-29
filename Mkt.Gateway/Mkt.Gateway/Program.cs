using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System.Reflection;

namespace Mkt.Gateway
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)

                // Adiciona através do delegation Action<> a leitura do arquivo de configuração glogal do ocelot
                .ConfigureAppConfiguration((host, config) =>
                {
                     

                    var env = host.HostingEnvironment;

                    config
                        .AddJsonFile("appsettings.json", false, true)
                        .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true, true)
                        .AddJsonFile("ocelot.json", optional: true, reloadOnChange: true)
                        .AddJsonFile($"ocelot.{env.EnvironmentName}.json", true, true);

                    config.AddEnvironmentVariables();

                    if (env.IsDevelopment() || env.IsEnvironment("Local"))
                    {
                        var appAssembly = Assembly.Load(new AssemblyName(typeof(Program).Assembly.FullName));
                        if (appAssembly != null)
                            config.AddUserSecrets(appAssembly, true);
                    }

                    if (args != null)
                        config.AddCommandLine(args);

                })

                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.ConfigureKestrel(serverOptions =>
                    {
                        serverOptions.AddServerHeader = false;
                        //serverOptions.ListenAnyIP(6000);
                    });
                    webBuilder.UseStartup<Startup>();
                });
    }
}

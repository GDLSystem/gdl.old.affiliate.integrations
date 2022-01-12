using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;

namespace Gdl.Affiliate.Integrations
{
    public class Program
    {
        public static int Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
#if DEBUG
                .MinimumLevel.Debug()
#else
                .MinimumLevel.Information()
#endif
                .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                .MinimumLevel.Override("Microsoft.EntityFrameworkCore", LogEventLevel.Warning)
                .Enrich.FromLogContext()
                .WriteTo.Async(c => c.File("Logs/logs.txt"))
#if DEBUG
                .WriteTo.Async(c => c.Console())
#endif
                .CreateLogger();

            try
            {
                Log.Information("Starting Gdl.Affiliate.Integrations.IdentityServer.");
                CreateHostBuilder(args).Build().Run();
                return 0;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Gdl.Affiliate.Integrations.IdentityServer terminated unexpectedly!");
                return 1;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        internal static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    var env = hostingContext.HostingEnvironment;

                    if (!env.IsProduction())
                    {
                        config
                            .AddJsonFile(Path.Combine(env.ContentRootPath, "..", "Configs/globalconfigs.json"), true, true)
                            .AddJsonFile(Path.Combine(env.ContentRootPath, "..", $"Configs/globalconfigs.{env.EnvironmentName}.json"), true, true);
                    }
                    else
                    {
                        config
                            .AddJsonFile("Configs/globalconfigs.json", true, true)
                            .AddJsonFile($"Configs/globalconfigs.{env.EnvironmentName}.json", true, true);
                    }
                })
                .AddAppSettingsSecretsJson()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
                .UseAutofac()
                .UseSerilog();
    }
}

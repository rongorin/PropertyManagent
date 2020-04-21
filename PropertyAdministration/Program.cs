using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace PropertyAdministration
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try

            {
                CreateHostBuilder(args).Build().Run();
                //var host = CreateHostBuilder(args).Build();

                //MigrateDatabase(host);

                //host.Run();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            // CreateHostBuilder(args).Build().Run();
         
        }
        private static void MigrateDatabase(IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<AppDBContext>();
                db.Database.Migrate();
            }
        }
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureLogging(logging =>
                {
                logging.ClearProviders();
                logging.AddConsole();
                logging.AddDebug();
                //logging.SetMinimumLevel(LogLevel.Warning);
                })

                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}

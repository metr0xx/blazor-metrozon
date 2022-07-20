using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using blazor_metrozon.Models;
namespace blazor_metrozon
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("1315111168");
            CreateHostBuilder(args).Build().Run();
            PostgresConnection.Connection();         
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
 
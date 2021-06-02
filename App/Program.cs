using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.EnvironmentVariables;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace NetCore.Docker
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
  Host.CreateDefaultBuilder(args)
      .ConfigureWebHost(
          webHost => webHost
              .UseKestrel(kestrelOptions => { kestrelOptions.ListenAnyIP(5005); })
              .Configure(app => app
                  .Run(
                      async context =>
                      {
                         var configuration = new ConfigurationBuilder()
                            .AddJsonFile("config.json")
                            .AddEnvironmentVariables()
                            .Build();

                         await context.Response.WriteAsync(configuration["Environment"]);
                         await context.Response.WriteAsync(configuration["Email"]);
                         await context.Response.WriteAsync(configuration["ConnectionString"]);
                      }
                  )));
    }
}

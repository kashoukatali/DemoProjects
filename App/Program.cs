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
              .UseKestrel(kestrelOptions => { kestrelOptions.ListenAnyIP(8080); })
              .Configure(app => app
                  .Run(
                      async context =>
                      {
                         var configuration = new ConfigurationBuilder()
                            .AddJsonFile("/config/config.json", true)
                            .AddEnvironmentVariables()
                            .Build();

                         await context.Response.WriteAsync("<p style=\"color: red;font-size:30px\">Environment      : " + configuration["Environment"] + "</p><br/>");
                         await context.Response.WriteAsync("<p style=\"color: blue;font-size:30px\">Email            : " + configuration["Email"] + "</p><br/>");
                         await context.Response.WriteAsync("<p style=\"color: green;font-size:30px\">ConnectionString : " + configuration["ConnectionString"] + "</p><br/>");
                      }
                  )));
    }
}

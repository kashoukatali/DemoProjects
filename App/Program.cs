using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;

namespace NetCore.Docker
{
    class Program
    {
        static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("config.json").Build();                
            
            // retrieve configuration values
            Console.WriteLine(configuration["Environment"]); // bar
            Console.WriteLine(configuration["Email"]); // qux
            Console.WriteLine(configuration["ConnectionString"]); // qux
        }
    }
}

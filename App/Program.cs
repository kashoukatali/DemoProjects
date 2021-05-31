using System;

namespace NetCore.Docker
{
    class Program
    {
        static void Main(string[] args)
        {
            if(args.Length >= 1)
            {
                Console.WriteLine("Hello " + args[0] + " World!");
            }
            else
            {
                Console.WriteLine("Hello World!");
            }
        }
    }
}

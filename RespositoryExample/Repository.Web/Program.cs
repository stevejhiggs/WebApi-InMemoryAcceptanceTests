using Microsoft.Owin.Hosting;
using System;

namespace Repository.Web
{
    class Program
    {
        static void Main(string[] args)
        {
            var options = new StartOptions
            {
                Port = 10001
            };

            using (WebApp.Start<Startup>(options))
            {
                Console.WriteLine("Running a http server on port " + options.Port);
                Console.ReadKey();
            }
        }
    }
}

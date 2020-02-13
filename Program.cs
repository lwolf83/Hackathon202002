using System;
using Nancy.Hosting.Self;
using Nancy.Configuration;

namespace EcoConception
{
    class Program
    {
        static void Main(string[] args)
        {
            HostConfiguration hostConfiguration = new HostConfiguration()
            {
                UrlReservations = new UrlReservations() { CreateAutomatically = true },
            };
            using (var host = new NancyHost(hostConfiguration, new Uri("http://localhost:8888")))
            {   
                host.Start();
                Console.WriteLine("Running on http://localhost:8888");
                Console.ReadLine();
                host.Stop();
            }
        }
    }
}

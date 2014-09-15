namespace StringManipulationService.Host
{
    using System;
    using System.ServiceModel;

    class Program
    {
        static void Main()
        {
            string uri = @"http://127.0.0.1:7777";

            using (ServiceHost host = new ServiceHost(typeof(Substring), new Uri(uri)))
            {
                host.Open();

                Console.WriteLine("Service is hosted at: " + uri);
                Console.WriteLine("Press any key to stop the service");
                Console.Read();
            }
        }
    }
}
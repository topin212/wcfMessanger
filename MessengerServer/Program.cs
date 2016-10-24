using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MessangerServiceLibrary;
using System.ServiceModel;

namespace MessengerServer
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(MessengerService)))
            {
                host.Open();
                
                Console.WriteLine("Press <Enter> to stop the service.");
                Console.ReadLine();
                host.Close();
            }
            Console.ReadKey();
        }
    }
}

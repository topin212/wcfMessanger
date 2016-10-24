using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ServiceModel;
using MessengerServiceConsoleClient.MessengerServiceReference;

namespace MessengerServiceConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var proxy = CallbackClass.proxy;

            Console.WriteLine("Connecting...");

            Random random = new Random();

            string nickname = "topin" + random.Next(100, 1000);

            proxy.Join(nickname);

            proxy.Broadcast(nickname, "hello there");

            proxy.BroadcastAsync(nickname, "async hello there");

            Console.ReadKey(true);
        }
    }
}

using System;
using System.Collections.Generic;

using System.ServiceModel;
using MessengerServiceConsoleClient.MessengerServiceReference;

namespace MessengerServiceConsoleClient
{
    class CallbackClass : IMessengerServiceCallback
    {
        static InstanceContext kekContext = new InstanceContext(new CallbackClass());
        public static MessengerServiceClient proxy = new MessengerServiceClient(kekContext);
        
        public void RecieveBroadcast(Message msg)
        {
            Console.WriteLine("{0}\t {1}: {2}\n", msg.date, msg.sender, msg.message);
        }

        public void RecieveWhisper(Message msg)
        {
            Console.WriteLine("{0}\t whisper from {1}: {2}\n", msg.date, msg.sender, msg.message);
        }

        public void OnJoin(List<string> clients)
        {
            Console.WriteLine("{0} users online\n", clients.Count);
        }
    }
}

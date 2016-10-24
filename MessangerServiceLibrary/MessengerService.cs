using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;

using MessangerServiceLibrary.DataContracts;

namespace MessangerServiceLibrary
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession, ConcurrencyMode = ConcurrencyMode.Reentrant)]
    public class MessengerService : IMessengerService
    {
        static Dictionary<Client, IClientCallback> clients = new Dictionary<Client, IClientCallback>();
        static List<string> clientList = new List<string>();

        public IClientCallback currentCallback{
            get
            {
                return OperationContext.Current.GetCallbackChannel<IClientCallback>();
            }
        }

        public void Join(string name)
        {
            if (!ClientExists(name))
            {
                var currentClient = new Client(name);

                clientList.Add(currentClient.nickname);
                clients.Add(currentClient, currentCallback);

                Console.WriteLine("{0} has joined.\n", currentClient.nickname);
                currentCallback.OnJoin(clientList);
            }
        }

        public void Leave(string who)
        {
            if (ClientExists(who))
            {
                clientList.RemoveAll(x => x == who);
                clients.Remove(new Client(who));

                Console.WriteLine("{0} has left", who);
            }
        }

        public void Broadcast(string from, string message)
        {
            foreach(var client in clients)
            {
                client.Value.RecieveBroadcast(new Message(from, message));
                Console.WriteLine("[{0}] {1} : {2}", DateTime.Now, from, message);
            }
        }

        public void Whisper(string from, string to, string message)
        {
            IClientCallback client = null; 
            if(clients.TryGetValue(new Client(to), out client))
            {
                client.RecieveBroadcast(new Message(from, message));
            }
        }

        #region utilities
        private bool ClientExists(string nickname)
        {
            return clientList.Any(x => x == nickname);
        }
        #endregion
    }
}

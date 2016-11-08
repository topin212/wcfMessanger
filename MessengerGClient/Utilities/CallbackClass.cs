using System;
using MessengerGClient.MessengerServiceReference;

using System.Collections.ObjectModel;

using Caliburn.Micro;
using System.ServiceModel;
using System.Windows;
using System.Collections.Generic;

namespace MessengerGClient
{
    public class CallbackClass : PropertyChangedBase, IMessengerServiceCallback
    {
        public BindableCollection<string> clients { get; set; }

        #region events
        public event EventHandler<ObservableCollection<string>> OnJoinEvent;
        public event EventHandler<MessengerServiceReference.Message> OnMessageRecievedEvent;
        #endregion

        static InstanceContext context = new InstanceContext(new CallbackClass());
        public static MessengerServiceClient proxy = new MessengerServiceClient(context);

        public void OnJoin(List<string> connectedClients)
        {
            //OnJoinEvent?.Invoke(null, connectedClients);
            clients = new BindableCollection<string>(connectedClients);
        }

        public void RecieveBroadcast(MessengerServiceReference.Message msg)
        {
            OnMessageRecievedEvent?.Invoke(null, msg);
        }

        public void RecieveWhisper(MessengerServiceReference.Message msg)
        {
            msg.isWhispered = true;
            OnMessageRecievedEvent?.Invoke(null, msg);
        }

        public CallbackClass()
        {
            clients = new BindableCollection<string>();
        }
    }

    #region eventArgsImplementation
    public class OnJoinEventArgs
    {
        ObservableCollection<string> connectedClients;
    }
    #endregion
}

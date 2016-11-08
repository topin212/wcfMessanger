using MessengerGClient.CaliburnUtil;
using System.Collections.ObjectModel;

using MessengerGClient.MessengerServiceReference;

using MessengerGClient.Utilities;

using Caliburn.Micro;
using System;
using System.Windows;

namespace MessengerGClient
{
    public class ShellViewModel : Caliburn.Micro.PropertyChangedBase, IShell
    {
        private ObservableCollection<string> _clients;
        public ObservableCollection<string> clients
        {
            get
            {
                return this._clients;
            }
            set
            {
                this._clients = value;
                NotifyOfPropertyChange(() => _clients);
            }
        }

        public ObservableCollection<MessengerServiceReference.Message> messages { get; set; }


        public string messageToSend { get; set; }

        public string nickname { get; set; }

        private bool _canConnect;
        public bool CanConnect
        {
            get
            {
                return _canConnect;
            }
            set
            {
                _canConnect = value;
                NotifyOfPropertyChange(() => _canConnect);
            }
        }

        public CallbackClass callbacker { get; set; }
        MessengerServiceClient client;

        public void Connect()
        {
            client = CallbackClass.proxy;
            client.JoinAsync(nickname);

            CanConnect = false;

            client.BroadcastAsync(nickname, "async hello there");
        }

        public void Send()
        {
            client.BroadcastAsync(nickname, messageToSend);
        }

        public ShellViewModel()
        {
            CanConnect = true;
            callbacker = new CallbackClass();

            callbacker.OnJoinEvent += OnJoin;
            callbacker.OnMessageRecievedEvent += OnRecieve;

            clients = new ObservableCollection<string>();
            messages = new ObservableCollection<MessengerServiceReference.Message>();

            callbacker.clients.Add("kek");
        }

        public void OnJoin(object sender, ObservableCollection<string> args)
        {
            clients = args;
            MessageBox.Show("hello there");
        }

        public void OnRecieve(object sender, MessengerServiceReference.Message e)
        {
            messages.Add(e);
            MessageBox.Show("hello there");
        }
    }
}
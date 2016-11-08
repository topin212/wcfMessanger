using MessangerServiceLibrary.DataContracts;
using System.ServiceModel;

using System.Collections.Generic;

namespace MessangerServiceLibrary
{
    [ServiceContract(SessionMode = SessionMode.Required, CallbackContract = typeof(IClientCallback))]
    public interface IMessengerService
    {
        //TODO try mode = one way
        [OperationContract(IsInitiating = true, IsOneWay = true)]
        void Join(string name);

        [OperationContract]
        void Broadcast(string from, string message);

        [OperationContract]
        void Whisper(string from, string to, string message);

        [OperationContract(IsTerminating = true)]
        void Leave(string who);
    }

    public interface IClientCallback
    {
        [OperationContract]
        void RecieveBroadcast(Message msg);

        [OperationContract]
        void RecieveWhisper(Message msg);

        [OperationContract]
        void OnJoin(List<string> connectedClients);
    }
}

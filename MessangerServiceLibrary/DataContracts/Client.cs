
using System.Runtime.Serialization;

namespace MessangerServiceLibrary.DataContracts
{
    [DataContract]
    public class Client
    {
        [DataMember]
        public string nickname { get; set; }

        public Client(string name)
        {
            nickname = name;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Serialization;

namespace MessangerServiceLibrary.DataContracts
{
    [DataContract]
    public class Message
    {
        [DataMember]
        public string sender { get; set; }
        [DataMember]
        public string message { get; set; }
        [DataMember]
        public DateTime date { get; set; }

        public Message(string from, string txt)
        {
            sender = from;
            message = txt;
            date = DateTime.Now;
        }
    }
}

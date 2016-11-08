using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessengerGClient.Utilities
{
    public class Dialog<TResp>
    {
        public string Header { get; set; }
        public string message { get; set; }

        public string response { get; set; }
        public bool responseGiven;
    }
}

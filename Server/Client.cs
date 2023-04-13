using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class Client 
    {
        private Socket clientSocket;
        private string ID;

        public Client(Socket clientSocket)
        {
            this.clientSocket = clientSocket;
        }

    }
}

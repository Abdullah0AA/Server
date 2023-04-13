using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class ClientHandler : Socket
    {
        public ClientHandler(SafeSocketHandle handle) : base(handle)
        {
        }

        public ClientHandler(SocketInformation socketInformation) : base(socketInformation)
        {
        }

        public ClientHandler(SocketType socketType, ProtocolType protocolType) : base(socketType, protocolType)
        {
        }

        public ClientHandler(AddressFamily addressFamily, SocketType socketType, ProtocolType protocolType) : base(addressFamily, socketType, protocolType)
        {
        }
    }
}

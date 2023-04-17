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
        
        private int available;
        private int ID;
        Random random;

        public Client(Socket clientSocket)
        {
            this.clientSocket = clientSocket;
            random = new Random();
            ID = random.Next();
        }

        public int Available
        {
            get { return clientSocket.Available; }
        }

        public string ReceiveString()
        {
            const int bufferSize = 1024;
            byte[] buffer = new byte[bufferSize];
            List<byte> receivedData = new List<byte>();

            int bytesReceived;
            do
            {
                bytesReceived = clientSocket.Receive(buffer);
                receivedData.AddRange(buffer.Take(bytesReceived));
            } while (bytesReceived == buffer.Length);
            

            return Encoding.ASCII.GetString(receivedData.ToArray(), 0, bytesReceived);
        }

        public void Send(byte[] data)
        {

            clientSocket.Send(data);
        }

        public bool IsConnected
        {
            get { return clientSocket.Connected; }

        }

        public void Disconnect()
        {
            if (clientSocket != null && clientSocket.Connected)
            {
                clientSocket.Shutdown(SocketShutdown.Both);
                clientSocket.Close();
                clientSocket.Dispose();
            }
        }

        public override string? ToString()
        {
            
            return ID.ToString() + "Sender";
        }
    }
   
}

using System.Net.Sockets;
using System.Text;

namespace Server
{
    /// <summary>
    /// Represents a client connected to the server.
    /// </summary>
    public class Client
    {
        private Socket clientSocket;
        private string id;
        

        /// <summary>
        /// Initializes a new instance of the Client class with the specified Socket.
        /// </summary>
        /// <param name="clientSocket">The Socket object representing the client connection.</param>
        public Client(Socket clientSocket)
        {
            this.clientSocket = clientSocket;
            id = GenerateClientID();
        }

        /// <summary>
        /// Generates a unique client ID using a GUID.
        /// </summary>
        /// <returns>A string representation of the generated client ID.</returns>
        private string GenerateClientID()
        {
            // Generate a random number
            string clientID = Guid.NewGuid().ToString()[..8];

            return clientID;
        }

        public string ID
        {
            get { return id; }
        }

        /// <summary>
        /// Gets the number of bytes that have been received and are available to be read.
        /// </summary>
        public int Available
        {
            get { return clientSocket.Available; }
        }

        /// <summary>
        /// Receives a string message from the client.
        /// </summary>
        /// <returns>The received message.</returns>
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

        /// <summary>
        /// Sends a string message to the client.
        /// </summary>
        /// <param name="data">The message to send.</param>
        public void SendString(string data)
        {

            byte[] bytes = Encoding.UTF8.GetBytes(data);
            clientSocket.Send(bytes);
        }


        /// <summary>
        /// Disconnects the client from the server.
        /// </summary>
        public void Disconnect()
        {
            if (clientSocket != null && clientSocket.Connected)
            {
                clientSocket.Shutdown(SocketShutdown.Both);
                clientSocket.Close();
                clientSocket.Dispose();
            }
        }

        /// <summary>
        /// Returns a string that represents the current Client object.
        /// </summary>
        /// <returns>A string that represents the current Client object.</returns>
        public override string ToString()
        {

            return $"Client({id})";
        }
    }

}

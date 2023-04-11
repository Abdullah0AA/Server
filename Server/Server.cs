using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    /// <summary>
    /// A class representing a TCP server that can accept connections from clients and send/receive data.
    /// </summary>
    public class Server
    {
        private IPAddress iPAddress;
        private int portNum;
        private EndPoint endPoint;
        private Socket listener;
        private Socket client;
        private byte[] data;
        private int bytesReceived;
        public event EventHandler<string> DataReceived;
        public event EventHandler<string> Error;

        /// <summary>
        /// Creates a new instance of the Server class with the specified IP address and port number.
        /// </summary>
        /// <param name="ipAddress">The IP address on which to listen for incoming connections.</param>
        /// <param name="port">The port number on which to listen for incoming connections.</param>
        public Server(IPAddress iPAddress, int portNum)
        {
            this.iPAddress = iPAddress;
            this.portNum = portNum;
            listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        public void start()
        {
            endPoint = new IPEndPoint(iPAddress, portNum);
            listener.Bind(endPoint);
            listener.Listen(10);
            client = listener.Accept();
            Thread receiveThread = new Thread(ReceiveData);
            receiveThread.Start();
        }

        /// <summary>
        /// Receives data from the connected client in a loop and raises the DataReceived event for each received message.
        /// If an error occurs during the data receive process, the Error event is raised with an exception message.
        /// </summary>
        /// <remarks>
        /// The method continuously waits for incoming data from the connected client using the Receive method of the Socket class.
        /// When data is received, it is converted from bytes to a string using the ASCII encoding and the DataReceived event is raised
        /// with the received message as a parameter.
        /// If an error occurs during the data receive process, such as the client disconnecting or a network error, the Error event
        /// is raised with the exception message as a parameter and the method exits the loop.
        /// </remarks>
        private void ReceiveData()
        {
            while (true)
            {
                try
                {
                    // Receive data from client
                    data = new byte[1024];
                    bytesReceived = client.Receive(data);
                    string message = Encoding.ASCII.GetString(data,0, bytesReceived);

                    // Raise DataReceived event with received message
                    OnDataReceived(message);

                }
                catch (Exception ex)
                {
                    // Raise Error event with exception message
                    OnError(ex.Message);
                    break;
                }
            }
        }

        /// <summary>
        /// An event that is raised when an error occurs in the server.
        /// </summary>
        private void OnError(string message)
        {
            Error?.Invoke(this, message);
        }

        /// <summary>
        /// An event that is raised when data is received from the connected client.
        /// </summary>
        private void OnDataReceived(string message)
        {
            DataReceived?.Invoke(this, message);

        }

        /// <summary>
        /// Sends a string message to the connected client using the Send method of the Socket class.
        /// If an error occurs during the data send process, the Error event is raised with an exception message.
        /// </summary>
        /// <param name="message">The string message to send to the connected client.</param>
        /// <remarks>
        /// The method converts the string message to a byte array using the ASCII encoding and sends it to the connected client
        /// using the Send method of the Socket class.
        /// If an error occurs during the data send process, such as the client disconnecting or a network error, the Error event
        /// is raised with the exception message as a parameter.
        /// </remarks>
        public void SendData(string message)
        {
            try
            {
                // Convert message to byte array and send to client
                byte[] data = Encoding.ASCII.GetBytes(message);
                client.Send(data);
            }
            catch (Exception ex)
            {
                // Raise Error event with exception message
                Error?.Invoke(this, ex.Message);
            }
        }

        /// <summary>
        /// Stops the server and disconnects all connected clients.
        /// </summary
        public void Stop()
        {
            client?.Close();
            listener?.Close();
        }
    }
    
}

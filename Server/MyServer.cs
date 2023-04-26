using Microsoft.VisualBasic;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;

namespace Server
{
    /// <summary>
    /// A class representing a TCP server that can accept connections from clients and send/receive data.
    /// </summary>
    public class MyServer
    {
        private IPAddress iPAddress;
        private int portNum;
        private List<Client> clientsList;

        public string clientID;

        //public event EventHandler<string> DataReceived;
        public event EventHandler<string> Error;
        public event EventHandler<string> MessageReceived;
        public TcpListener tcpListener;

        /// <summary>
        /// Creates a new instance of the Server class with the specified IP address and port number.
        /// </summary>
        /// <param name="ipAddress">The IP address on which to listen for incoming connections.</param>
        /// <param name="port">The port number on which to listen for incoming connections.</param>
        public MyServer(IPAddress iPAddress, int portNum)
        {

            this.iPAddress = iPAddress;
            this.portNum = portNum;

            clientsList = new List<Client>();
            tcpListener = new(iPAddress, portNum);

        }

        /// <summary>
        /// Starts the server, listens for incoming client connections and creates a new thread for each connected client to handle communication.
        /// </summary>
        public void start()
        {

            tcpListener.Start();

            Task listenTask = Task.Run(() => listenForClients());

        }

        /// <summary>
        /// Listens for incoming client connections and starts a new thread to receive data from each client.
        /// </summary>
        /// <remarks>
        /// This method runs indefinitely until an exception occurs. When a new client connection is accepted,
        /// the client's socket is added to the `clients` list and a new thread is created to receive data from
        /// the client using the `ReceiveData` method. If an exception occurs while waiting for clients or
        /// accepting a client connection, the `OnError` method is called with the exception message and the
        /// method exits the loop.
        /// </remarks>
        private void listenForClients()
        {
            while (true)
            {
                try
                {
                    Debug.WriteLine($"Thread is : {Thread.CurrentThread.Name} --> Waiting for new Clients");

                    //Socket clientSocket = listener.Accept();
                    TcpClient tcpClient = tcpListener.AcceptTcpClient();
                    Client client = new Client(tcpClient);
                    ClientHandler clientHandler = new ClientHandler(client);


                    clientHandler.DataReceived += OnDataReceived;

                    clientID = client.ToString();
                    AddClientToList(client);
                    Debug.WriteLine($"Thread is :  {Thread.CurrentThread.ManagedThreadId} --> Client Accepted");


                    //Thread clientThread = new Thread(clientHandler.HandleClientRequests);
                    //clientThread.Name = "Client Thread";
                    //clientThread.Start();
                    Task handleClient = Task.Run(() => clientHandler.HandleClientRequests());



                }

                catch (Exception ex)
                {
                    OnError(ex.Message);
                    break;
                }

            }
        }



        /// <summary>
        /// An event that is raised when an error occurs in the server.
        /// </summary>
        public void OnError(string message)
        {
            Error?.Invoke(this, message);
        }

        /// <summary>
        /// An event that is raised when data is received from the connected client.
        /// </summary>
        private void OnDataReceived(object sender, string message)
        {
            MessageReceived?.Invoke(this, message);

        }

        /// <summary>
        /// Sends data to all connected clients.
        /// </summary>
        /// <param name="data">The data to send.</param>
        public void SendDataToAllClients(string data)
        {
            foreach (Client client in clientsList)
            {
                try
                {

                    client.SendString(data);

                }
                catch (Exception ex)
                {
                    OnError(ex.Message);
                }
            }

        }

        /// <summary>
        /// Stops the server and disconnects all connected clients.
        /// </summary
        public void Stop()
        {
            tcpListener.Stop();
        }

        public void AddClientToList(Client client)
        {

            this.clientsList.Add(client);
        }
        public IReadOnlyList<Client> GetClientsList()
        {
            return clientsList;
        }
    }

}
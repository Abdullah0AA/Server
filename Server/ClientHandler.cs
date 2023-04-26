using System.Diagnostics;

namespace Server
{
    /// <summary>
    /// The ClientHandler class represents a handler for a client connection to the server. 
    /// It is responsible for processing requests and raising an event when new data is received from the client.
    /// </summary>
    internal class ClientHandler
    {
        // The client object that this handler is associated with.
        private Client _client;

        // The event that is raised when new data is received from the client.
        public event EventHandler<string> DataReceived;

        /// <summary>
        /// Initializes a new instance of the ClientHandler class with the specified client object.
        /// </summary>
        /// <param name="client">The client object that this handler is associated with.</param>
        public ClientHandler(Client client)
        {
            _client = client;
        }

        /// <summary>
        /// Handles requests from the client by continuously receiving data from the client and responding to requests until the client disconnects.
        /// </summary>
        public void HandleClientRequests()
        {
            while (true)
            {
                try
                {
                    if (_client.Available > 0)
                    {
                        // Receive data from client

                        Debug.WriteLine($"Thread is :  {Thread.CurrentThread.ManagedThreadId} is ReceiveData thread. Waiting for new Data");
                        string message = _client.ReceiveString();
                        Debug.WriteLine($"Thread is :  {Thread.CurrentThread.ManagedThreadId} is ReceiveData thread. Got new Data");

                        if (message == "disconnect")
                        {
                            _client.Disconnect();
                            break;
                        }

                        RespondToRequest(message);
                        OnDataReceived(message);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error handling request: {ex.Message}");
                }
            }
        }

        /// <summary>
        /// Processes the specified request and sends a response back to the client.
        /// </summary>
        /// <param name="request">The request to be processed.</param>
        private void RespondToRequest(string request)
        {
            // Process the request and send a response back to the client
            string response = $"Received request: {request}";
            _client.SendString(response);
        }

        /// <summary>
        /// Raises the DataReceived event with the specified message.
        /// </summary>
        /// <param name="message">The message that was received from the client.</param>
        private void OnDataReceived(string message)
        {
            DataReceived?.Invoke(this, message);
        }

    }
}
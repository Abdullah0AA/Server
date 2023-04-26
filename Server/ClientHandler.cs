using System.Diagnostics;

namespace Server
{
    /// <summary>
    /// The ClientHandler class represents a handler for a client connection to the server. 
    /// It is responsible for processing requests and raising an event when new data is received from the client.
    /// </summary>
    public class ClientHandler
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
        public void HandleClients()
        {
            while (true)
            {
                try
                {
                    if (_client.Available > 0)
                    {
                        // Receive data from client

                        Debug.WriteLine($"Thread is :  {Thread.CurrentThread.ManagedThreadId} is ReceiveData thread. Waiting for new Data");
                        string request = _client.ReceiveString();
                        Debug.WriteLine($"Thread is :  {Thread.CurrentThread.ManagedThreadId} is ReceiveData thread. Got new Data");

                        if (request == "disconnect")
                        {
                            _client.Disconnect();
                            break;
                        }

                        IRequestHandler requestHandler = GetRequestHandler(request);

                        requestHandler.HandleRequest(request); 
                        OnDataReceived(request);
                        RespondToClient(requestHandler.ResponseToClient());
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error handling request: {ex.Message}");
                }
            }
        }

        /// <summary>
        /// Sends a response back to the connected client.
        /// </summary>
        /// <param name="response">The response to be sent.</param>
        public void RespondToClient(string response)
        {
            
            _client.SendString(response);
        }

        /// <summary>
        /// Raises the DataReceived event with the specified message.
        /// </summary>
        /// <param name="message">The message that was received from the client.</param>
        public void OnDataReceived(string message)
        {
            DataReceived?.Invoke(this, message);
        }
        public IRequestHandler GetRequestHandler(string request)
        {
            switch (request)
            {
                case "A":
                    return new RequestHandlerA();
                case "B":
                    return new RequestHandlerB();
                default:
                    return new InvalidRequestHandler();
            }
        }

    }
}
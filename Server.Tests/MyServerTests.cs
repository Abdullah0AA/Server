using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Server.Tests
{
    public class MyServerTests
    {
        [Fact]
        public void Start_StartsServer()
        {
            // Arrange
            IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
            int portNum = 5000;
            MyServer server = new MyServer(ipAddress, portNum);

            // Act
            server.start();

            // Assert
            Assert.True(server.tcpListener.Server.IsBound);


        }
        [Fact]
        public void Stop_StopsServer()
        {
            // Arrange
            IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
            int port = 1234;
            MyServer server = new MyServer(ipAddress, port);
            server.start();

            // Act
            server.Stop();

            // Assert
            Assert.False(server.tcpListener.Server.IsBound);
        }
        [Fact]
        public void ServerRaisesMessageReceivedEventWhenDataIsReceived()
        {
            // Arrange
            MyServer server = new MyServer(IPAddress.Any, 1234);
            string receivedMessage = string.Empty;
            string testMessage = "Hello from client";
            server.MessageReceived += (sender, message) => receivedMessage = message;
            server.start();

            TcpClient client = new TcpClient();
            client.Connect(IPAddress.Loopback, 1234);

            // Act
            NetworkStream stream = client.GetStream();
            byte[] bytesToSend = Encoding.ASCII.GetBytes(testMessage);
            stream.Write(bytesToSend, 0, bytesToSend.Length);


            // Allow time for the message to be received and handled
            Thread.Sleep(100);

            // Assert
            Assert.Equal(testMessage, receivedMessage);
        }

        [Fact]
        public void Server_Raises_Error_Event_When_Error_Occurs()
        {
            // Arrange
            MyServer server = new MyServer(IPAddress.Any, 1234);
            string errorMessage = "Test error message";
            string receivedErrorMessage = "Nothing yet";

            // Act
            server.Error += (sender, message) => receivedErrorMessage = message;
            server.start();
            server.tcpListener.Stop();
            server.OnError(errorMessage);

            // Assert
            Assert.Equal(errorMessage, receivedErrorMessage); 
        }
    }
}
using System.Net.Sockets;

namespace Server.Tests
{
    public class ClientHandlerTests
    {
        [Theory]
        [InlineData("A", typeof(RequestHandlerA))]
        [InlineData("B", typeof(RequestHandlerB))]
        [InlineData("C", typeof(InvalidRequestHandler))]
        public void GetRequestHandler_ShouldReturnCorrectType(string request, Type expectedType)
        {
            // Arrange
            ClientHandler clientHandler = new ClientHandler(new Client(new TcpClient()));

            // Act
            IRequestHandler result = clientHandler.GetRequestHandler(request);

            // Assert
            Assert.IsType(expectedType, result);
        }
        [Fact]
        public void DataReceivedEventIsRaisedWhenNewDataIsReceived()
        {
            // Arrange
            Client client = new Client(new TcpClient());
            ClientHandler handler = new ClientHandler(client);
            string expectedMessage = "test data";
            string actualMessage = null;

            handler.DataReceived += (sender, message) =>
            {
                actualMessage = message;
            };

            // Act
            handler.OnDataReceived(expectedMessage);


            // Assert
            Assert.Equal(expectedMessage, actualMessage);
        
        }
    }


}
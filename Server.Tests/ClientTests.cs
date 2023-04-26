using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server.Tests
{
    public class ClientTests
    {
        [Fact]
        public void GenerateClientID_ReturnsUniqueID()
        {
            // Arrange
            Client client1 = new Client(new TcpClient());
            Client client2 = new Client(new TcpClient());

            // Act
            string id1 = client1.ID;
            string id2 = client2.ID;

            // Assert
            Assert.NotEqual(id1, id2);
        }

    }
}

using System.Net;
using System.Net.Sockets;

namespace Server
{
    public partial class ServerForm : Form
    {
        private IPAddress iPAddress;
        private EndPoint endPoint;
        private Socket socket;
        private Socket client;
        private int PORT_NUM = 50000;
        
        public ServerForm()
        {
            InitializeComponent();
        }

        private void ServerForm_Load(object sender, EventArgs e)
        {

            endPoint = new IPEndPoint(IPAddress.Any, PORT_NUM);
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Bind(endPoint);
            socket.Listen(10);
            client = socket.Accept();

            


        }
    }
}
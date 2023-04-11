using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Server
{
    public partial class ServerForm : Form
    {

        private Socket client;
        private int PORT_NUM = 50000;
        private byte[] data;
        private int bytesReceived;
        private Server server;

        public ServerForm()
        {
            InitializeComponent();
            server = new Server(IPAddress.Any, PORT_NUM);
            server.DataReceived += onDataReceived;
            server.Error += OnError;
        }

        private void OnError(object? sender, string message)
        {
            MessageBox.Show(message);
        }

        private void onDataReceived(object? sender, string message)
        {
            Invoke((MethodInvoker)delegate
            {
                txtDataFromClient.Text += "Client: " + message + Environment.NewLine;
            });
        }

        private void ServerForm_Load(object sender, EventArgs e)
        {
            server.start();
        }

        private void btnSendtoClient_Click(object sender, EventArgs e)
        {
            server.SendData(txtDataToClient.Text);
        }
    }
}
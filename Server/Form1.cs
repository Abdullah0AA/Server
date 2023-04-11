using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Server
{
    public partial class ServerForm : Form
    {
        private IPAddress iPAddress;
        private EndPoint endPoint;
        private Socket socket;
        private Socket client;
        private int PORT_NUM = 50000;
        private byte[] data;
        private int bytesReceived;

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

            Thread receiveThread = new Thread(new ThreadStart(ReceiveData));
            receiveThread.Start();

        }
        private void ReceiveData()
        {
            while (true)
            {
                try
                {
                    // Receive data from client
                    data = new byte[1024];
                    bytesReceived = client.Receive(data);
                    string message = Encoding.ASCII.GetString(data, 0, bytesReceived);

                    // Update UI with received message
                    Invoke((MethodInvoker)delegate
                    {
                        txtDataFromClient.AppendText("Client: " + message + Environment.NewLine);
                    });
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    break;
                }
            }
        }

        private void btnSendtoClient_Click(object sender, EventArgs e)
        {
            byte[] data = Encoding.ASCII.GetBytes(txtDataToClient.Text);
            client.Send(data);
        }
    }
}
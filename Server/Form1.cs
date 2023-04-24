using System.Net;

namespace Server
{
    public partial class ServerForm : Form
    {

        private int PORT_NUM = 50000;
        private Server server;

        public ServerForm()
        {
            InitializeComponent();
            server = new Server(IPAddress.Any, PORT_NUM);
            server.MessageReceived += onDataReceived;
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
                txtDataFromClient.Text += server.clientID + " >>" + message + Environment.NewLine;
            });
        }

        private void ServerForm_Load(object sender, EventArgs e)
        {
            server.start();
        }

        private void btnSendtoClient_Click(object sender, EventArgs e)
        {
            server.SendDataToAllClients(txtDataToClient.Text);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtDataFromClient.Clear();
        }
    }
}
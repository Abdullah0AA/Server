using System.Net;
using System.Windows.Forms;

namespace Server
{
    public partial class ServerForm : Form
    {

        private int PORT_NUM = 50000;
        private MyServer server;

        public ServerForm()
        {
            InitializeComponent();
            server = new MyServer(IPAddress.Any, PORT_NUM);
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
            notifyIcon1.BalloonTipTitle = "Produktion Server";
            notifyIcon1.BalloonTipText = "Nofifcation";
            notifyIcon1.Text = "Produktion Server";
            notifyIcon1.Visible = true;

        }

        private void btnSendtoClient_Click(object sender, EventArgs e)
        {
            server.SendDataToAllClients(txtDataToClient.Text);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtDataFromClient.Clear();
        }


        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            this.ShowInTaskbar = true;
            notifyIcon1.Visible = false;
            WindowState = FormWindowState.Normal;

        }

        private void ServerForm_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                notifyIcon1.Visible = true;

            }
            else if (FormWindowState.Normal == this.WindowState)
            {
                notifyIcon1.Visible = false;

            }
        }

        private void ServerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.Hide();
                notifyIcon1.Visible = true;
            }
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
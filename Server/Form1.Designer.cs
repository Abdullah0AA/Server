namespace Server
{
    partial class ServerForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ServerForm));
            txtDataToClient = new TextBox();
            btnSendtoClient = new Button();
            txtDataFromClient = new TextBox();
            label3 = new Label();
            label1 = new Label();
            label2 = new Label();
            btnReset = new Button();
            notifyIcon1 = new NotifyIcon(components);
            contextMenuStrip1 = new ContextMenuStrip(components);
            closeToolStripMenuItem = new ToolStripMenuItem();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // txtDataToClient
            // 
            txtDataToClient.Location = new Point(1069, 73);
            txtDataToClient.Multiline = true;
            txtDataToClient.Name = "txtDataToClient";
            txtDataToClient.Size = new Size(300, 136);
            txtDataToClient.TabIndex = 6;
            // 
            // btnSendtoClient
            // 
            btnSendtoClient.Location = new Point(1069, 214);
            btnSendtoClient.Name = "btnSendtoClient";
            btnSendtoClient.Size = new Size(82, 23);
            btnSendtoClient.TabIndex = 8;
            btnSendtoClient.Text = "Send";
            btnSendtoClient.UseVisualStyleBackColor = true;
            btnSendtoClient.Click += btnSendtoClient_Click;
            // 
            // txtDataFromClient
            // 
            txtDataFromClient.Location = new Point(12, 108);
            txtDataFromClient.Multiline = true;
            txtDataFromClient.Name = "txtDataFromClient";
            txtDataFromClient.Size = new Size(1051, 566);
            txtDataFromClient.TabIndex = 9;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(1069, 55);
            label3.Name = "label3";
            label3.Size = new Size(91, 15);
            label3.TabIndex = 10;
            label3.Text = "Data zum Client";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 90);
            label1.Name = "label1";
            label1.Size = new Size(92, 15);
            label1.TabIndex = 11;
            label1.Text = "Data vom Client";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 48F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = Color.OrangeRed;
            label2.Location = new Point(12, 677);
            label2.Name = "label2";
            label2.Size = new Size(212, 86);
            label2.TabIndex = 12;
            label2.Text = "Server";
            // 
            // btnReset
            // 
            btnReset.Location = new Point(988, 680);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(75, 23);
            btnReset.TabIndex = 13;
            btnReset.Text = "Reset";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += btnReset_Click;
            // 
            // notifyIcon1
            // 
            notifyIcon1.ContextMenuStrip = contextMenuStrip1;
            notifyIcon1.Icon = (Icon)resources.GetObject("notifyIcon1.Icon");
            notifyIcon1.Text = "notifyIcon1";
            notifyIcon1.MouseDoubleClick += notifyIcon1_MouseDoubleClick;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { closeToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(104, 26);
            // 
            // closeToolStripMenuItem
            // 
            closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            closeToolStripMenuItem.Size = new Size(103, 22);
            closeToolStripMenuItem.Text = "Close";
            closeToolStripMenuItem.Click += closeToolStripMenuItem_Click;
            // 
            // ServerForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1415, 784);
            Controls.Add(btnReset);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(label3);
            Controls.Add(txtDataFromClient);
            Controls.Add(btnSendtoClient);
            Controls.Add(txtDataToClient);
            Name = "ServerForm";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Server";
            WindowState = FormWindowState.Minimized;
            FormClosing += ServerForm_FormClosing;
            Load += ServerForm_Load;
            Resize += ServerForm_Resize;
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtDataToClient;
        private Button btnSendtoClient;
        private TextBox txtDataFromClient;
        private Label label3;
        private Label label1;
        private Label label2;
        private Button btnReset;
        private NotifyIcon notifyIcon1;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem closeToolStripMenuItem;
    }
}
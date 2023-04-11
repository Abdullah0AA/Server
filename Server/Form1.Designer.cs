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
            txtDataToClient = new TextBox();
            btnSendtoClient = new Button();
            txtDataFromClient = new TextBox();
            label3 = new Label();
            label1 = new Label();
            SuspendLayout();
            // 
            // txtDataToClient
            // 
            txtDataToClient.Location = new Point(370, 122);
            txtDataToClient.Multiline = true;
            txtDataToClient.Name = "txtDataToClient";
            txtDataToClient.Size = new Size(300, 154);
            txtDataToClient.TabIndex = 6;
            // 
            // btnSendtoClient
            // 
            btnSendtoClient.Location = new Point(370, 282);
            btnSendtoClient.Name = "btnSendtoClient";
            btnSendtoClient.Size = new Size(82, 26);
            btnSendtoClient.TabIndex = 8;
            btnSendtoClient.Text = "Send";
            btnSendtoClient.UseVisualStyleBackColor = true;
            btnSendtoClient.Click += btnSendtoClient_Click;
            // 
            // txtDataFromClient
            // 
            txtDataFromClient.Location = new Point(12, 122);
            txtDataFromClient.Multiline = true;
            txtDataFromClient.Name = "txtDataFromClient";
            txtDataFromClient.Size = new Size(300, 154);
            txtDataFromClient.TabIndex = 9;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(370, 102);
            label3.Name = "label3";
            label3.Size = new Size(99, 17);
            label3.TabIndex = 10;
            label3.Text = "Data zum Client";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 102);
            label1.Name = "label1";
            label1.Size = new Size(100, 17);
            label1.TabIndex = 11;
            label1.Text = "Data vom Client";
            // 
            // ServerForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 510);
            Controls.Add(label1);
            Controls.Add(label3);
            Controls.Add(txtDataFromClient);
            Controls.Add(btnSendtoClient);
            Controls.Add(txtDataToClient);
            Name = "ServerForm";
            Text = "Server";
            Load += ServerForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtDataToClient;
        private Button btnSendtoClient;
        private TextBox txtDataFromClient;
        private Label label3;
        private Label label1;
    }
}
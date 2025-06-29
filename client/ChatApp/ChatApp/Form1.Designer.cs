namespace ChatApp
{
    partial class Form1
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
            txtIp = new TextBox();
            lblIp = new Label();
            lblPort = new Label();
            txtPort = new TextBox();
            lblUsername = new Label();
            txtUsername = new TextBox();
            rtbChatLog = new RichTextBox();
            txtMessage = new TextBox();
            btnConnect = new Button();
            btnSend = new Button();
            lblHeader = new Label();
            lstUsers = new ListBox();
            SuspendLayout();
            // 
            // txtIp
            // 
            txtIp.BorderStyle = BorderStyle.FixedSingle;
            txtIp.Location = new Point(20, 90);
            txtIp.Name = "txtIp";
            txtIp.Size = new Size(150, 23);
            txtIp.TabIndex = 2;
            // 
            // lblIp
            // 
            lblIp.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblIp.Location = new Point(20, 70);
            lblIp.Name = "lblIp";
            lblIp.Size = new Size(100, 20);
            lblIp.TabIndex = 1;
            lblIp.Text = "IP Adress";
            // 
            // lblPort
            // 
            lblPort.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblPort.Location = new Point(20, 120);
            lblPort.Name = "lblPort";
            lblPort.Size = new Size(100, 20);
            lblPort.TabIndex = 3;
            lblPort.Text = "Port";
            // 
            // txtPort
            // 
            txtPort.BorderStyle = BorderStyle.FixedSingle;
            txtPort.Location = new Point(20, 140);
            txtPort.Name = "txtPort";
            txtPort.Size = new Size(150, 23);
            txtPort.TabIndex = 4;
            // 
            // lblUsername
            // 
            lblUsername.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblUsername.Location = new Point(20, 170);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(100, 20);
            lblUsername.TabIndex = 5;
            lblUsername.Text = "Username";
            // 
            // txtUsername
            // 
            txtUsername.BorderStyle = BorderStyle.FixedSingle;
            txtUsername.Location = new Point(20, 190);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(150, 23);
            txtUsername.TabIndex = 6;
            // 
            // rtbChatLog
            // 
            rtbChatLog.BackColor = Color.White;
            rtbChatLog.BorderStyle = BorderStyle.FixedSingle;
            rtbChatLog.Font = new Font("Segoe UI", 10F);
            rtbChatLog.Location = new Point(190, 70);
            rtbChatLog.Name = "rtbChatLog";
            rtbChatLog.ReadOnly = true;
            rtbChatLog.Size = new Size(680, 387);
            rtbChatLog.TabIndex = 8;
            rtbChatLog.Text = "";
            // 
            // txtMessage
            // 
            txtMessage.BackColor = Color.White;
            txtMessage.BorderStyle = BorderStyle.FixedSingle;
            txtMessage.Font = new Font("Segoe UI", 10F);
            txtMessage.Location = new Point(190, 465);
            txtMessage.Name = "txtMessage";
            txtMessage.Size = new Size(560, 25);
            txtMessage.TabIndex = 9;
            // 
            // btnConnect
            // 
            btnConnect.BackColor = Color.FromArgb(0, 122, 204);
            btnConnect.FlatAppearance.BorderSize = 0;
            btnConnect.FlatStyle = FlatStyle.Flat;
            btnConnect.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnConnect.ForeColor = Color.White;
            btnConnect.Location = new Point(40, 230);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(100, 35);
            btnConnect.TabIndex = 7;
            btnConnect.Text = "Connect";
            btnConnect.UseVisualStyleBackColor = false;
            btnConnect.Click += btnConnect_Click;
            btnConnect.MouseEnter += btnHoverEnter;
            btnConnect.MouseLeave += btnHoverLeave;
            // 
            // btnSend
            // 
            btnSend.BackColor = Color.FromArgb(0, 122, 204);
            btnSend.FlatAppearance.BorderSize = 0;
            btnSend.FlatStyle = FlatStyle.Flat;
            btnSend.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSend.ForeColor = Color.White;
            btnSend.Location = new Point(760, 463);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(110, 30);
            btnSend.TabIndex = 10;
            btnSend.Text = "Send";
            btnSend.UseVisualStyleBackColor = false;
            btnSend.Click += btnSend_Click;
            btnSend.MouseEnter += btnHoverEnter;
            btnSend.MouseLeave += btnHoverLeave;
            // 
            // lblHeader
            // 
            lblHeader.AutoSize = true;
            lblHeader.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblHeader.Location = new Point(387, 9);
            lblHeader.Name = "lblHeader";
            lblHeader.Size = new Size(165, 32);
            lblHeader.TabIndex = 0;
            lblHeader.Text = "Chatting App";
            // 
            // lstUsers
            // 
            lstUsers.BackColor = Color.White;
            lstUsers.BorderStyle = BorderStyle.FixedSingle;
            lstUsers.Font = new Font("Segoe UI", 10F);
            lstUsers.ItemHeight = 17;
            lstUsers.Location = new Point(20, 303);
            lstUsers.Name = "lstUsers";
            lstUsers.Size = new Size(150, 138);
            lstUsers.TabIndex = 0;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightCyan;
            ClientSize = new Size(900, 550);
            Controls.Add(lstUsers);
            Controls.Add(lblHeader);
            Controls.Add(lblIp);
            Controls.Add(txtIp);
            Controls.Add(lblPort);
            Controls.Add(txtPort);
            Controls.Add(lblUsername);
            Controls.Add(txtUsername);
            Controls.Add(btnConnect);
            Controls.Add(rtbChatLog);
            Controls.Add(txtMessage);
            Controls.Add(btnSend);
            Font = new Font("Segoe UI", 9F);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Form1";
            Text = "WALA Chat Client";
            ResumeLayout(false);
            PerformLayout();
        }


        #endregion

        private TextBox txtIp;
        private Label lblIp;
        private Label lblPort;
        private TextBox txtPort;
        private Label lblUsername;
        private TextBox txtUsername;
        private RichTextBox rtbChatLog;
        private TextBox txtMessage;
        private Button btnConnect;
        private Button btnSend;
        private Label lblHeader;
        private ListBox lstUsers;

    }
}

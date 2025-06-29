using System;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Linq;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace ChatApp
{
    public partial class Form1 : Form
    {
        private TcpClient client;
        private NetworkStream stream;
        private byte[] sessionKey;

        public Form1()
        {
            InitializeComponent();

            this.Paint += new PaintEventHandler(Form1_GradientPaint);
        }

        private async void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                client = new TcpClient(txtIp.Text, int.Parse(txtPort.Text));
                stream = client.GetStream();

                byte[] rsaBuffer = new byte[2048];
                int rsaLen = stream.Read(rsaBuffer, 0, rsaBuffer.Length);
                string rsaPem = Encoding.UTF8.GetString(rsaBuffer, 0, rsaLen);

                using (var rng = RandomNumberGenerator.Create())
                {
                    sessionKey = new byte[8];
                    rng.GetBytes(sessionKey);
                }

                byte[] encryptedKey = EncryptWithRSA(rsaPem, sessionKey);
                stream.Write(encryptedKey, 0, encryptedKey.Length);
                string username = txtUsername.Text;
                byte[] userData = EncryptWithDES(sessionKey, "USER||" + username);
                stream.Write(userData, 0, userData.Length);
                _ = Task.Run(() => ReceiveLoop());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection Error: " + ex.Message);
            }
        }


        private async void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                string msg = $"{txtUsername.Text}: {txtMessage.Text}";
                byte[] encrypted = EncryptWithDES(sessionKey, msg);
                await stream.WriteAsync(encrypted, 0, encrypted.Length);
                txtMessage.Clear();
            }
            catch (Exception ex)
            {
                AppendLog("Error: " + ex.Message);
            }
        }

        private async Task ReceiveLoop()
        {
            byte[] buffer = new byte[4096];
            while (true)
            {
                try
                {
                    int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
                    if (bytesRead > 0)
                    {
                        byte[] encrypted = buffer.Take(bytesRead).ToArray();
                        string message = DecryptWithDES(sessionKey, encrypted);

                        if (message.StartsWith("SYSTEM||"))
                        {
                            string info = message.Split("||")[1];
                            if (info.Contains(","))
                            {
                                string[] users = info.Split(',');
                                lstUsers.Invoke(() =>
                                {
                                    lstUsers.Items.Clear();
                                    lstUsers.Items.AddRange(users);
                                });
                            }
                            else
                            {
                                AppendLog(info);
                            }
                        }
                        else
                        {
                            AppendLog(message);
                        }
                    }
                }
                catch
                {
                    AppendLog("Connection dropped.");
                    break;
                }
            }
        }

        private byte[] EncryptWithRSA(string pemPublicKey, byte[] data)
        {
            using (var rsa = RSA.Create())
            {
                rsa.ImportFromPem(pemPublicKey.ToCharArray());
                return rsa.Encrypt(data, RSAEncryptionPadding.OaepSHA1); 
            }
        }


        private void AppendLog(string msg)
        {
            string time = DateTime.Now.ToString("HH:mm");

            rtbChatLog.Invoke(() =>
            {
                rtbChatLog.SelectionStart = rtbChatLog.TextLength;

                // Eğer sistem mesajıysa gri yap
                if (msg.Contains("joined chat") || msg.Contains("left chat"))
                    rtbChatLog.SelectionColor = Color.Gray;
                else if (msg.StartsWith(txtUsername.Text + ":"))
                    rtbChatLog.SelectionColor = Color.Blue;
                else
                    rtbChatLog.SelectionColor = Color.Black;

                rtbChatLog.AppendText($"[{time}] {msg}{Environment.NewLine}");
                rtbChatLog.SelectionColor = rtbChatLog.ForeColor;
            });
        }


        private byte[] EncryptWithDES(byte[] key, string plainText)
        {
            using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
            {
                des.Mode = CipherMode.ECB;
                des.Padding = PaddingMode.PKCS7;
                des.Key = key;

                byte[] data = Encoding.UTF8.GetBytes(plainText);
                using (ICryptoTransform encryptor = des.CreateEncryptor())
                {
                    return encryptor.TransformFinalBlock(data, 0, data.Length);
                }
            }
        }

        private string DecryptWithDES(byte[] key, byte[] encryptedData)
        {
            using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
            {
                des.Mode = CipherMode.ECB;
                des.Padding = PaddingMode.PKCS7;
                des.Key = key;

                using (ICryptoTransform decryptor = des.CreateDecryptor())
                {
                    byte[] decrypted = decryptor.TransformFinalBlock(encryptedData, 0, encryptedData.Length);
                    return Encoding.UTF8.GetString(decrypted);
                }
            }
        }


        private void btnHoverEnter(object sender, EventArgs e)
        {
            if (sender is Button btn)
            {
                btn.BackColor = Color.FromArgb(30, 144, 255);
            }
        }

        private void btnHoverLeave(object sender, EventArgs e)
        {
            if (sender is Button btn)
            {
                btn.BackColor = Color.FromArgb(0, 122, 204);
            }

        }


        private void Form1_GradientPaint(object sender, PaintEventArgs e)
        {
            using (LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle,
                   Color.LightCyan, Color.LightBlue, 45F))
            {
            e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
        }

}
}
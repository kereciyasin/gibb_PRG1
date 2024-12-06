using MailKit.Net.Smtp;
using MimeKit;
using System.Windows;

namespace AB01_03
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            string recipientEmail = emailTextBox.Text;
            if (!string.IsNullOrEmpty(recipientEmail))
            {
                SendEmail(recipientEmail, "Test Subject", "This is a test email. I am Yasin :)");
                MessageBox.Show("Email Sent Successfully!");
            }
            else
            {
                MessageBox.Show("Please enter a valid email address.");
            }
        }

        public void SendEmail(string toEmail, string subject, string body)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Your Name", "kereciyasin52@gmail.com"));
            message.To.Add(new MailboxAddress("", toEmail));
            message.Subject = subject;

            var bodyBuilder = new BodyBuilder { TextBody = body };
            message.Body = bodyBuilder.ToMessageBody();

            using (var client = new SmtpClient())
            {
                // SMTP sunucusu, port ve güvenli bağlantı (TLS)
                client.Connect("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls); // TLS bağlantısı kullanarak
                client.Authenticate("kereciyasin52@gmail.com", "kffl kuhs tftg pcvs"); // E-posta ve uygulama şifresi
                client.Send(message);
                client.Disconnect(true);
            }
        }
    }
}

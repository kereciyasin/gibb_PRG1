using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

namespace AB01_01
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string email = EmailTextBox.Text;
            string password = PasswordBox.Password;

            if (IsAuthorizedUser(email, password))
            {
                MessageBox.Show("Login Successful!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Invalid email or password. Please try again.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            EmailTextBox.Text = string.Empty;
            PasswordBox.Password = string.Empty;
        }

        private bool IsAuthorizedUser(string email, string password)
        {
            // Sadece belirli kullanıcı bilgileri kabul edilir
            const string validEmail = "vmadmin@stud.gibb.ch";
            const string validPassword = "sml12345";

            return email == validEmail && password == validPassword;
        }
    }
}

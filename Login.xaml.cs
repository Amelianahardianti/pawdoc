using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace pawdoc
{
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        // Event handler untuk tombol Login
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string email = EmailTextBox.Text;
            string password = PasswordTextBox.Text;

            // Validasi sederhana
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter your email and password.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Contoh logika login sederhana
            if (email == "user@example.com" && password == "password123")
            {
                MessageBox.Show("Login Successful!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                // Navigasi ke halaman berikutnya (misalnya, dashboard)
                Dashboard dashboard = new Dashboard(); // Dashboard adalah window lain
                dashboard.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid email or password. Please try again.", "Login Failed", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Event handler untuk link Sign Up
        private void SignUpLink_Click(object sender, RoutedEventArgs e)
        {
            // Navigasi ke halaman registrasi
            Register register = new Register(); // Register adalah window lain
            register.Show();
            this.Close();
        }

        // Event handler untuk link Forgot Password
        private void ForgotPasswordLink_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Forgot Password feature is not yet implemented.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}

using pawdoc;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace pawdoc
{
    public partial class Login : Page
    {
        public Login()
        {
            InitializeComponent();
        }

        // Event handler  buat tombol Login
        private async void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string email = EmailTextBox.Text;
            string password = PasswordTextBox.Text;

            // Validasi  untuk passrod
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter your email and password.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            //  Loading Screen
            var loadingScreen = new LoadingScreen();
            NavigationService.Navigate(loadingScreen);

           
            bool isLoginSuccessful = await Task.Run(() =>
            {
                Thread.Sleep(3000); 
                return email == "user@example.com" && password == "password123";
            });

            if (isLoginSuccessful)
            {
                // Navigasi ke halaman dashboard
                MessageBox.Show("Login Successful!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                NavigationService.Navigate(new Dashboard());
            }
            else
            {
                MessageBox.Show("Invalid email or password. Please try again.", "Login Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                // Kembali ke halaman login
                NavigationService.Navigate(new Login());
            }
        }

        // Event handler buat link Sign Up
        private void SignUpLink_Click(object sender, RoutedEventArgs e)
        {
            // Navigasi untuk ke halaman registrasi
            ((selo)Application.Current.MainWindow).ContentFrame.Navigate(new Register());
        }

        // untuk link Forgot Password amjay
        private void ForgotPasswordLink_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Forgot Password feature is not yet implemented.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void PasswordTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}

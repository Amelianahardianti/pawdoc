using System;
using System.Windows;
using System.Windows.Controls;

namespace pawdoc
{
    public partial class Register : Page
    {
        public Register()
        {
            InitializeComponent();
        }

        private async void SignInButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text.Trim();
            string email = EmailTextBox.Text.Trim();
            string password = PasswordBox.Password.Trim();
            string confirmPassword = ConfirmPasswordBox.Password.Trim();
            var authContext = ((selo)Application.Current.MainWindow).FirebaseAuth;
            var auth = await authContext.SignUpWithEmailPasswordAsync(email, password);

            if (auth != null)
            {
                ((selo)Application.Current.MainWindow).ContentFrame.Navigate(new DashboardPage());
                // Redirect to login page or home page
            }
            else
            {
                MessageBox.Show("Registration failed.");
            }

            //if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(email) ||
            //    string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmPassword))
            //{
            //    MessageBox.Show("Please fill in all the fields.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            //    return;
            //}

            //if (!IsValidEmail(email))
            //{
            //    MessageBox.Show("Please enter a valid email address.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            //    return;
            //}

            //if (password != confirmPassword)
            //{
            //    MessageBox.Show("Passwords do not match. Please try again.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            //    return;
            //}

            //MessageBox.Show("Registration successful!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}


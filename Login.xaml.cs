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
        public FirestoreService FirestoreService { get; set; }
        public Login()
        {
            InitializeComponent();
            this.FirestoreService = ((selo)Application.Current.MainWindow).FirestoreService;
        }

        // Event handler  buat tombol Login
        private async void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string email = EmailTextBox.Text;
            string password = PasswordTextBox.Text;
            var authContext = ((selo)Application.Current.MainWindow).FirebaseAuth;
            var auth = await authContext.SignInWithEmailPasswordAsync(email, password);
            // Validasi  untuk passrod
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter your email and password.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if(auth != null)
            {
                try
                {
                    ((selo)Application.Current.MainWindow).user = await FirestoreService.GetUserFromFirestoreAsync(email);
                    this.NavigationService.Navigate(new DashboardPage(((selo)Application.Current.MainWindow).user) );

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to get user");
                }
            }
            else
            {
                MessageBox.Show("Login Failed");
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

        private void HyperlinkButton_Click(object sender, RoutedEventArgs e)
        {
            ((selo)Application.Current.MainWindow).ContentFrame.Navigate(new ForgotPassword());

        }
    }
}

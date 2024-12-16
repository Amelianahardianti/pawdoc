using System;
using System.Windows;
using System.Windows.Navigation;

namespace pawdoc
{
    /// <summary>
    /// Interaction logic for selo.xaml
    /// </summary>
    public partial class selo : Window
    {
        // Properti FirebaseAuthHelper publik agar bisa diakses dari file lain
        public FirebaseAuthHelper FirebaseAuth { get; set; }

        // Constructor Default
        public selo() : this(new FirebaseAuthHelper()) // Inisialisasi default FirebaseAuthHelper
        {
        }

        // Constructor dengan Parameter
        public selo(FirebaseAuthHelper firebaseAuthHelper)
        {
            InitializeComponent();

            // Inisialisasi properti FirebaseAuth
            FirebaseAuth = firebaseAuthHelper;

            // Navigasi ke halaman Login.xaml
            try
            {
                ContentFrame.Navigate(new Login());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error navigating to Login page: {ex.Message}");
            }
        }

        // Event handler jika navigasi gagal
        private void ContentFrame_NavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            MessageBox.Show($"Navigation Failed: {e.Exception.Message}");
            e.Handled = true;
        }
    }
}

using System;
using System.Windows;
using System.Windows.Controls;

namespace pawdoc
{


    public partial class Register : Page
    {
        private readonly FirestoreService _firestoreService;

        public Register()
        {
            InitializeComponent();
            // Buat instance FirestoreService
             this._firestoreService = ((selo)Application.Current.MainWindow).FirestoreService;

        }

        private void HyperlinkBack_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Navigasi kembali ke halaman Login
                ((selo)Application.Current.MainWindow).ContentFrame.Navigate(new Login());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error navigating to Login: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async void SignInButton_Click(object sender, RoutedEventArgs e)
        {
            // Ambil input dari form
            string username = UsernameTextBox.Text.Trim();
            string email = EmailTextBox.Text.Trim();
            string password = PasswordBox.Password.Trim();
            string confirmPassword = ConfirmPasswordBox.Password.Trim();
            string selectedRole = ((ComboBoxItem)RoleComboBox.SelectedItem)?.Content?.ToString();
            

            // Validasi Input
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(email) ||
                string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmPassword) || string.IsNullOrEmpty(selectedRole))
            {
                MessageBox.Show("Please fill in all the fields.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!IsValidEmail(email))
            {
                MessageBox.Show("Please enter a valid email address.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("Passwords do not match.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                // Daftarkan user ke Firebase Authentication
                var authContext = ((selo)Application.Current.MainWindow).FirebaseAuth;
                var auth = await authContext.SignUpWithEmailPasswordAsync(email, password);

                if (auth != null)
                {
                    // Konversi role dari string ke enum UserRole
                    UserRole roleEnum = Enum.TryParse(selectedRole, true, out UserRole role) ? role : UserRole.Owner;

                    // Simpan data user ke Firestore
                    var newUser = new User
                    {
                        Id = Guid.NewGuid().ToString(), // Auto-generate ID
                        Username = username,
                        Email = email,
                        Role = roleEnum
                    };

                    _firestoreService.AddUserToFirestoreAsync(newUser);

                    MessageBox.Show("Registration successful!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                    // Navigasi ke DashboardPage
                    ((selo)Application.Current.MainWindow).ContentFrame.Navigate(new DashboardPage(newUser));
                }
                else
                {
                    MessageBox.Show("Registration failed. Please try again.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Fungsi untuk validasi email
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

    // Enum Role untuk user
   
}


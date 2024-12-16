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

        private void HyperlinkBack_Click(object sender, RoutedEventArgs e)
        {
            // Navigasi kembali ke halaman Login
            ((selo)Application.Current.MainWindow).ContentFrame.Navigate(new Login());
        }

        private async void SignInButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text.Trim();
            string email = EmailTextBox.Text.Trim();
            string password = PasswordBox.Password.Trim();
            string confirmPassword = ConfirmPasswordBox.Password.Trim();
            string selectedRole = ((ComboBoxItem)RoleComboBox.SelectedItem)?.Content.ToString();

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
                // Daftarkan ke Firebase Authentication
                var authContext = ((selo)Application.Current.MainWindow).FirebaseAuth;
                var auth = await authContext.SignUpWithEmailPasswordAsync(email, password);

                if (auth != null)
                {
                    // Konversi role dari string ke enum UserRole
                    UserRole roleEnum = (UserRole)Enum.Parse(typeof(UserRole), selectedRole, true);

                    // Simpan data user ke Firestore
                    var newUser = new User
                    {
                        Id = Guid.NewGuid().ToString(), // Auto-generate ID
                        Username = username,
                        Email = email,
                        Password = "******", // Hindari menyimpan password plaintext
                        Role = roleEnum
                    };

                    var firestoreService = new FirestoreService();
                    await firestoreService.AddUserToFirestoreAsync(newUser);

                    MessageBox.Show("Registration successful!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                    // Arahkan ke halaman Dashboard
                    // Pastikan class Dashboard tersedia dan diimport dengan namespace yang benar
                    ((selo)Application.Current.MainWindow).ContentFrame.Navigate(new DashboardPage());
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
}

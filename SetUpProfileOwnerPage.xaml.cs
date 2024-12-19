using System;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Win32;
using System.Windows.Media.Imaging;
using Firebase.Database;
using Firebase.Database.Query;
using System.Threading.Tasks;

namespace pawdoc
{
    public partial class SetUpProfileOwnerPage : Page
    {
        public string ProfileImagePath { get; set; } // Holds the image file path
        private readonly FirestoreService firebaseClient;
        public User user;

        public SetUpProfileOwnerPage()
        {
            InitializeComponent();
            this.firebaseClient = ((selo)Application.Current.MainWindow).FirestoreService;
            this.user = ((selo)Application.Current.MainWindow).user;
            NameInput.Text = user.Username;
            EmailInput.Text = user.Email;
            // Initialize Firebase client
            // Replace with your Firebase URL
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            // Navigasi kembali ke halaman sebelumnya
            NavigationService.GoBack();
        }

        // Event handler for adding a profile image
 

        // Event handler for saving data to Firebase
        private async void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            // Retrieve user input values
            string name = NameInput.Text;
            string email = EmailInput.Text;

            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Please fill in the Name field.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            try
            {
                ((selo)Application.Current.MainWindow).user = await firebaseClient.UpdateUserFromFirestoreAsync(email, name);
                MessageBox.Show("User berhasil di update");

            }
            catch (Exception ex) {
                MessageBox.Show("Gagal mengedit profile");
            }


        }

        // Helper method to clear input fields
        private void ClearForm()
        {
            NameInput.Text = "";
            EmailInput.Text = "";
        }
    }
}
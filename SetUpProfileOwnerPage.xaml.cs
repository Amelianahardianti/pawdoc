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
        private readonly FirebaseClient firebaseClient;

        public SetUpProfileOwnerPage()
        {
            InitializeComponent();

            // Initialize Firebase client
            firebaseClient = new FirebaseClient("https://pawdoc-12345-default-rtdb.asia-southeast1.firebasedatabase.app/"); // Replace with your Firebase URL
        }

        // Event handler for adding a profile image
        private void AddProfileImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Title = "Select Profile Image",
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                ProfileImagePath = openFileDialog.FileName;

                // Display the selected image in the Image control
                ProfileImage.Source = new BitmapImage(new Uri(ProfileImagePath));
            }
        }

        // Event handler for saving data to Firebase
        private async void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            // Retrieve user input values
            string name = NameInput.Text;
            string address = AddressInput.Text;
            string city = CityInput.Text;
            string postcode = PostCodeInput.Text;
            string country = CountryInput.Text;

            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Please fill in the Name field.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Create a profile object to save
            var profileData = new
            {
                Name = name,
                Address = address,
                City = city,
                PostCode = postcode,
                Country = country,
                ProfileImagePath = ProfileImagePath ?? "No Image"
            };

            try
            {
                // Save data to Firebase Realtime Database
                await firebaseClient
                    .Child("Profiles") // Parent node in the database
                    .PostAsync(profileData);

                MessageBox.Show("Profile saved successfully to Firebase!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                // Clear the form
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving data to Firebase: {ex.Message}", "Firebase Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Helper method to clear input fields
        private void ClearForm()
        {
            NameInput.Text = "";
            AddressInput.Text = "";
            CityInput.Text = "";
            PostCodeInput.Text = "";
            CountryInput.Text = "";
            ProfileImage.Source = null;
            ProfileImagePath = null;
        }
    }
}
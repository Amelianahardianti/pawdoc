using System;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Win32; // For OpenFileDialog
using Firebase.Database; // Ensure you're using Firebase.Database for Realtime Database
using pawdoc.Models;

namespace pawdoc
{
    public partial class SetUpProfileVet : Page
    {
        public string ProfileImagePath { get; set; } // Holds the image file path

        public SetUpProfileVet()
        {
            InitializeComponent();
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
                ProfileImage.Source = new System.Windows.Media.Imaging.BitmapImage(new Uri(ProfileImagePath));
            }
        }

        // Event handler for saving data to the database
        private async void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            // Retrieve user input values
            string name = NameInput.Text;
            string specialization = SpecializationInput.Text;
            string idhNumber = IDHNumberInput.Text;
            string clinicInfo = ClinicInfoInput.Text;
            string city = CityInput.Text;

            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Please fill in the Name field.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Save data to Firebase Realtime Database
            try
            {
                var firebase = new FirebaseClient("https://yourfirebaseapp.firebaseio.com/"); // Your Firebase URL
                var vetProfiles = firebase.Child("VetProfiles");
                var vetProfile = new VetProfile
                {
                    Name = name,
                    Specialization = specialization,
                    IDHNumber = idhNumber,
                    ClinicInformation = clinicInfo,
                    City = city,
                    ProfileImagePath = ProfileImagePath
                };

                await vetProfiles.PostAsync(vetProfile);

                MessageBox.Show("Profile saved successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving data: {ex.Message}", "Database Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}

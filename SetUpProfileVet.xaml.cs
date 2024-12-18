using System;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Win32;
using Firebase.Database;
using Firebase.Database.Query;
using pawdoc.Models;

namespace pawdoc
{
    public partial class SetUpProfileVet : Page
    {
        public string ProfileImagePath { get; set; } // Holds the image file path
        private readonly FirebaseClient firebaseClient;

        public SetUpProfileVet()
        {
            InitializeComponent();

            // Initialize Firebase client
            firebaseClient = new FirebaseClient("https://pawdoc-12345-default-rtdb.asia-southeast1.firebasedatabase.app/"); 
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

        // Event handler for saving data to Firebase
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

            // Create a vet profile object
            var vetProfile = new VetProfile
            {
                Name = name,
                Specialization = specialization,
                IDHNumber = idhNumber,
                ClinicInformation = clinicInfo,
                City = city,
                ProfileImagePath = ProfileImagePath ?? "No Image"
            };

            try
            {
                // Save data to Firebase Realtime Database
                await firebaseClient
                    .Child("VetProfiles") // Parent node in the database
                    .PostAsync(vetProfile);

                MessageBox.Show("Vet profile saved successfully to Firebase!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                // Clear the form
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving vet profile to Firebase: {ex.Message}", "Firebase Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Helper method to clear input fields
        private void ClearForm()
        {
            NameInput.Text = "";
            SpecializationInput.Text = "";
            IDHNumberInput.Text = "";
            ClinicInfoInput.Text = "";
            CityInput.Text = "";
            ProfileImage.Source = null;
            ProfileImagePath = null;
        }
    }
}

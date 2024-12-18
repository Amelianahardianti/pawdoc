using System;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Win32; // For OpenFileDialog
using System.Windows.Media.Imaging;

namespace pawdoc
{
    public partial class SetUpProfileOwnerPage : Page
    {
        public string ProfileImagePath { get; set; } // Holds the image file path

        public SetUpProfileOwnerPage()
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
                ProfileImage.Source = new BitmapImage(new Uri(ProfileImagePath));
            }
        }

        // Event handler for saving data to the database
        private void SaveButton_Click(object sender, RoutedEventArgs e)
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

            //[BIAR GA ERROR DI GW]

            // Save data to the database
            //try
            //{
            //    using (SqlConnection connection = new SqlConnection("Data Source=YOUR_SERVER_NAME;Initial Catalog=YOUR_DATABASE_NAME;Integrated Security=True"))
            //    {
            //        connection.Open();
            //
            //        // SQL command to insert data
            //        string query = "INSERT INTO Profile (Name, Address, City, PostCode, Country, ProfileImagePath) VALUES (@Name, @Address, @City, @PostCode, @Country, @ProfileImagePath)";
            //        using (SqlCommand command = new SqlCommand(query, connection))
            //        {
            //            // Add parameters to avoid SQL injection
            //            command.Parameters.AddWithValue("@Name", name);
            //            command.Parameters.AddWithValue("@Address", address);
            //            command.Parameters.AddWithValue("@City", city);
            //            command.Parameters.AddWithValue("@PostCode", postcode);
            //            command.Parameters.AddWithValue("@Country", country);
            //            command.Parameters.AddWithValue("@ProfileImagePath", ProfileImagePath ?? (object)DBNull.Value);
            //
            //            command.ExecuteNonQuery();
            //        }
            //    }
            //
            //    MessageBox.Show("Profile saved successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            //
            //    // Clear the form
            //    ClearForm();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show($"Error saving data: {ex.Message}", "Database Error", MessageBoxButton.OK, MessageBoxImage.Error);
            //}
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

using Google.Cloud.Firestore;
using pawdoc.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace pawdoc
{
    /// <summary>
    /// Interaction logic for SetUpDiaryPage.xaml
    /// </summary>
    public partial class SetUpDiaryPage : Page
    {
        FirestoreService _firestoreService;
        public SetUpDiaryPage()
        {
            InitializeComponent();
            this._firestoreService = ((selo)Application.Current.MainWindow).FirestoreService;
        }

        // Navigation Button Click Handler
        private void PawDocButton_Click(object sender, RoutedEventArgs e)
        {
            // Navigasi kembali ke halaman Dashboard
            ((selo)Application.Current.MainWindow).ContentFrame.Navigate(new DashboardPage());
        }

        private void VetListButton_Click(object sender, RoutedEventArgs e)
        {
            // Navigasi kembali ke halaman Vet List
            ((selo)Application.Current.MainWindow).ContentFrame.Navigate(new VetListPage());
        }
        private void PetDiaryButton_Click(object sender, RoutedEventArgs e)
        {
            // Navigasi kembali ke halaman Pet Diary
            ((selo)Application.Current.MainWindow).ContentFrame.Navigate(new SetUpDiaryPage());
        }

        //error dikit bro di xamlnya jadi gw bikinin ini dulu 
        private void ProfileButton_Click(object sender, RoutedEventArgs e)
        {
            // Navigasi ke halaman Display Pet Diary 
            ((selo)Application.Current.MainWindow).ContentFrame.Navigate(new DisplayProfileOwner());
        }
        // [DIBIKIN BISA OTOMATIS BIKIN PROFILE (SetUpProfileOwnerPage)OR LIHAT PROFILE (DisplayProfileOwnerPage)]

        //private async void ProfileButton_Click(object sender, RoutedEventArgs e)
        //{
        //    try
        //    {
        //        // Ensure Firestore is initialized
        //        string path = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "pawdoc-12345-firebase-adminsdk-u5zgj-2ae4b4ce7c.json");
        //        Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", path);
        //        FirestoreDb firestore = FirestoreDb.Create("your-project-id");
        //
        //        // Check if user email is available
        //        string userEmail = GlobalUser.CurrentUserEmail?.Trim();
        //        if (string.IsNullOrEmpty(userEmail))
        //        {
        //            MessageBox.Show("User email is missing.");
        //            return;
        //        }
        //
        //        // Query Firestore for user profile
        //        CollectionReference usersRef = firestore.Collection("users");
        //        Query query = usersRef.WhereEqualTo("Email", userEmail);
        //        QuerySnapshot snapshot = await query.GetSnapshotAsync();
        //
        //        // Navigate based on query result
        //        if (snapshot.Documents.Count > 0)
        //        {
        //            // Profile exists, navigate to DisplayProfileOwnerPage
        //           ((selo)Application.Current.MainWindow).ContentFrame.Navigate(new DisplayProfileOwnerPage());
        //         }
        //        else
        //        {
        //            // Profile does not exist, navigate to SetUpProfileOwnerPage
        //            ((selo)Application.Current.MainWindow).ContentFrame.Navigate(new SetUpProfileOwnerPage());
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"An error occurred while checking the user profile: {ex.Message}");
        //    }
        //}
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            // Navigasi kembali ke halaman sebelumnya
            NavigationService.GoBack();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            string sysmptoms = SymptompsTextBox.Text;
            string diagnosis = DiagnosisTextBox.Text;
            string medicine = MedicineBox.Text;
            string extraNote = ExtraNoteBox.Text;
            try
            {
                var diaryEntry = new DiaryEntry
                {
                    Username = ((selo)Application.Current.MainWindow).user.Username,
                    Symptoms = sysmptoms,
                    Diagnosis = diagnosis,
                    Medicine = medicine,
                    ExtraNote = extraNote,
                    DateCreated = Timestamp.GetCurrentTimestamp(),
                    Id = "1",
                };
                _firestoreService.AddDiaryEntryAsync(diaryEntry);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Masuk ke database gagal");
            }
        }

        // [TOMBOL SAVE]

        // Submit Button Click Handler
        //private async void SubmitButton_Click(object sender, RoutedEventArgs e)
        //{
        //    string symptoms = SymptompsTextBox.Text.Trim();
        //    string diagnosis = DiagnosisTextBox.Text.Trim();
        //    string medicine = MedicineBox.Text.Trim();
        //    string extraNote = ExtraNoteBox.Text.Trim();
        //    
        //    // Validasi Input
        //    if (string.IsNullOrEmpty(symptoms) || string.IsNullOrEmpty(diagnosis) ||
        //        string.IsNullOrEmpty(medicine) || string.IsNullOrEmpty(extraNote))
        //    {
        //        MessageBox.Show("Please fill in all the fields.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
        //        return;
        //    }

        //    try
        //    {
        //        // Save diary entry to Firestore 
        //        var firestoreService = new FirestoreService;
        //        var diaryEntry = new DiaryEntry
        //        {
        //            Id = Guid.NewGuid().ToString, // Generate unique ID
        //            Symptoms = symptoms,
        //            Diagnosis = diagnosis,
        //            Medicine = medicine,
        //            ExtraNote = extraNote,
        //            DateCreated = DateTime.Now
        //        };

        //        await firestoreService.AddDiaryEntryAsync(diaryEntry);

        //        MessageBox.Show("Diary entry saved successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        //    }
        //     
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"Error saving diary entry: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        //    }
    }
}
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
using pawdoc.Class;

namespace pawdoc
{
    /// <summary>
    /// Interaction logic for DiaryPage.xaml
    /// </summary>
    public partial class DiaryPage : Page
    {
        public DiaryPage()
        {
            InitializeComponent();
        }

        // Navigation Button Click Handler
        private void PawDocButton_Click(object sender, RoutedEventArgs e)
        {
            // Navigasi kembali ke halaman Dashboard
            ((selo)Application.Current.MainWindow).ContentFrame.Navigate(new DashboardPage());
        }
        private void MyPetsButton_Click(object sender, RoutedEventArgs e)
        {
            // Navigasi kembali ke halaman My Pets 
            ((selo)Application.Current.MainWindow).ContentFrame.Navigate(new MyPetsPage());
        }
        private void VetListButton_Click(object sender, RoutedEventArgs e)
        {
            // Navigasi kembali ke halaman Vet List
            ((selo)Application.Current.MainWindow).ContentFrame.Navigate(new VetListPage());
        }
        private void ProfileButton_Click(object sender, RoutedEventArgs e)
        {
            // Navigasi kembali ke halaman Profile User
            ((selo)Application.Current.MainWindow).ContentFrame.Navigate(new ProfilePage());
        }
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            // Navigasi kembali ke halaman sebelumnya
            NavigationService.GoBack();
        }

        // Submit Button Click Handler
        private async void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            string symptoms = SymptompsTextBox.Text.Trim();
            string diagnosis = DiagnosisTextBox.Text.Trim();
            string medicine = MedicinieBox.Password.Trim();
            string extraNote = ExtraNoteBox.Password.Trim();
            
            // Validasi Input
            if (string.IsNullOrEmpty(symptoms) || string.IsNullOrEmpty(diagnosis) ||
                string.IsNullOrEmpty(medicine) || string.IsNullOrEmpty(extraNote))
            {
                MessageBox.Show("Please fill in all the fields.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                // Save diary entry to Firestore 
                var firestoreService = new FirestoreService();
                var diaryEntry = new DiaryEntry
                {
                    Id = Guid.NewGuid().ToString(), // Generate unique ID
                    Symptoms = symptoms,
                    Diagnosis = diagnosis,
                    Medicine = medicine,
                    ExtraNote = extraNote,
                    DateCreated = DateTime.Now,
                };

                firestoreService.AddDiaryEntryAsync(diaryEntry);

                MessageBox.Show("Diary entry saved successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
             
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving diary entry: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void MessageButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

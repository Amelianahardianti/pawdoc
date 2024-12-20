using pawdoc.Class;
using pawdoc.component;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Firebase.Database;
using Firebase.Database.Query;

namespace pawdoc
{
    public partial class PetDiary : Page
    {
        private FirestoreService firestoreService;
        private User user;

        public PetDiary()
        {
            InitializeComponent();
            firestoreService = ((selo)Application.Current.MainWindow).FirestoreService;
            this.user = ((selo)Application.Current.MainWindow).user;
            AddDynamicContent();
        }

        // Method to add dynamic content to the ScrollViewer
        private async void AddDynamicContent()
        {
            List<DiaryEntry> entries = await firestoreService.GetDiaryEntriesAsync(user);

            foreach (DiaryEntry entry in entries)
            {
                var diaryComponent = new DiaryComponent(entry);

                // Subscribe to the delete event from the DiaryComponent
                diaryComponent.OnDelete += async (DiaryEntry deletedEntry) =>
                {
                    // Delete the entry from Firestore
                    bool isDeleted = await firestoreService.DeleteDiaryEntryAsync(deletedEntry.Id);
                    if (isDeleted)
                    {
                        // Remove the DiaryComponent from the StackPanel
                        StackPanelDiary.Children.Remove(diaryComponent);

                        // Show success notification
                        MessageBox.Show("Diary entry deleted successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        // Show error notification
                        MessageBox.Show("Failed to delete diary entry.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                };

                // Add the DiaryComponent to the StackPanel
                StackPanelDiary.Children.Add(diaryComponent);
            }
        }

        // Navigate to ClinicPage
        private void ClinicButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new ClinicPage());
        }

        // Navigate to VetListPage
        private void VetListButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new VetListPage());
        }

        // Navigate to InputDiary
        private void InputDiaryButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new SetUpDiaryPage());
        }

        // Navigate to PetDiaryPage (this page itself)
        private void PetDiary_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new PetDiary());
        }

        // Navigate to SetUpProfileOwnerPage
        private void ProfileButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new SetUpProfileOwnerPage());
        }

        // Navigate to Dashboard
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new DashboardPage(((selo)Application.Current.MainWindow).user));
        }
    }
}

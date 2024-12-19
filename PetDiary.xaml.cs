using pawdoc.Class;
using pawdoc.component;
using System.Windows;
using System.Windows.Controls;

namespace pawdoc
{
    public partial class PetDiary : Page
    {
        FirestoreService firestoreService;
        User user;
        public PetDiary()
        {
            InitializeComponent();
            firestoreService = ((selo)Application.Current.MainWindow).FirestoreService;
            this.user = ((selo)Application.Current.MainWindow).user;
            // Example: Dynamically adding content to the ScrollViewer
            AddDynamicContent();
        }

        // Method to add dynamic content to the ScrollViewer
        private async void AddDynamicContent()
        {
            List<DiaryEntry> entries = new List<DiaryEntry>();
            entries = await firestoreService.GetDiaryEntriesAsync(user);
            // Create a StackPanel for the dynamic content
            foreach (DiaryEntry entry in entries)
            {
                DiaryComponent diaryComponent = new DiaryComponent(entry);
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
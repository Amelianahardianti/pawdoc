using System.Windows;

using System.Windows;
using System.Windows.Controls;

namespace pawdoc
{
    public partial class VetListPage : Page
    {
        public VetListPage()
        {
            InitializeComponent();
        }

        // Navigate to ClinicPage
        private void ClinicButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new ClinicPage());
        }

        // Navigate to VetListPage (this page itself)
        private void VetListButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new VetListPage());
        }

        // Navigate to SetUpDiaryPage
        private void InputDiaryButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new SetUpDiaryPage());
        }

        // Navigate to PetDiary page
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
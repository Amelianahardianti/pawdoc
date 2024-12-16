using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace pawdoc
{
    public partial class DashboardPage : Page
    {
        public DashboardPage()
        {
            InitializeComponent();
        }

        // Event handler untuk tombol "My Pets"
        private void MyPetsButton_Click(object sender, RoutedEventArgs e)
        {
            // Navigasi ke halaman MyPetsPage
        //    NavigationService.Navigate(new PetInformationPage());
        }

        // Event handler untuk tombol "Vet List"
        private void VetListButton_Click(object sender, RoutedEventArgs e)
        {
            // Navigasi ke halaman VetListPage
        //    NavigationService.Navigate(new VetListPage());
        }

        // Event handler untuk tombol "Message Inbox"
        private void MessageInboxButton_Click(object sender, RoutedEventArgs e)
        {
            // Navigasi ke halaman MessageInboxPage
        //    NavigationService.Navigate(new MessagePage());
        }

        // Event handler untuk tombol "Profile"
        private void ProfileButton_Click(object sender, RoutedEventArgs e)
        {
            // Navigasi ke halaman ProfilePage
        //    NavigationService.Navigate(new UserProfilePage());
        }

        // Event handler untuk "Chat with Veterinarian"
        private void ChatWithVeterinarian_Click(object sender, RoutedEventArgs e)
        {
            // Navigasi ke halaman ChatPage
        //    NavigationService.Navigate(new MessagePage());
        }

        // Event handler untuk "Check Pet Profile"
        private void CheckPetProfile_Click(object sender, RoutedEventArgs e)
        {
            // Navigasi ke halaman PetProfilePage
        //    NavigationService.Navigate(new PetInformationPage());
        }
    }
}

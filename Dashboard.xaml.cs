using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Google.Cloud.Firestore;
using static pawdoc.App;

namespace pawdoc
{
    public partial class DashboardPage : Page
    {
        private FirestoreDb _firestore;
        public User user;


        public DashboardPage()
        {
            this.user = ((selo)Application.Current.MainWindow).user;
        }
        public DashboardPage(User user)
        {
            InitializeComponent();
            this.user = user;
            if (user != null)
            {
                WelcomeTextBlock.Text = $"Welcome {user.Username}";
            }
        }

       
        // Event handler tombol
        private void MyPetsButton_Click(object sender, RoutedEventArgs e) {
            ((selo)Application.Current.MainWindow).ContentFrame.Navigate(new MyPetsPage());
        }
        private void VetListButton_Click(object sender, RoutedEventArgs e) {
            ((selo)Application.Current.MainWindow).ContentFrame.Navigate(new VetListPage());

        }
        private void MessageInboxButton_Click(object sender, RoutedEventArgs e) {

        }
        private void ProfileButton_Click(object sender, RoutedEventArgs e) {
            ((selo)Application.Current.MainWindow).ContentFrame.Navigate(new ProfilePage());

        }
        private void ChatWithVeterinarian_Click(object sender, RoutedEventArgs e) { }
        private void CheckPetProfile_Click(object sender, RoutedEventArgs e) { }
    }
}

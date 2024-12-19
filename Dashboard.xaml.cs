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
        private void ClinicButton_Click(object sender, RoutedEventArgs e)
        {
            ((selo)Application.Current.MainWindow).ContentFrame.Navigate(new ClinicPage());
        }
        private void VetListButton_Click(object sender, RoutedEventArgs e)
        {
            ((selo)Application.Current.MainWindow).ContentFrame.Navigate(new VetListPage());

        }
        private void InputPetDiaryButton_Click(object sender, RoutedEventArgs e)
        {
            ((selo)Application.Current.MainWindow).ContentFrame.Navigate(new SetUpDiaryPage());

        }
        private void ViewPetDiaryButton_Click(object sender, RoutedEventArgs e)
        {
            ((selo)Application.Current.MainWindow).ContentFrame.Navigate(new PetDiary());

        }

        private void ProfileButton_Click(object sender, RoutedEventArgs e)
        {
            ((selo)Application.Current.MainWindow).ContentFrame.Navigate(new SetUpProfileOwnerPage());
        }

        private void PetDiaryButton_Click(object sender, RoutedEventArgs e)
        {
            ((selo)Application.Current.MainWindow).ContentFrame.Navigate(new PetDiary());
        }
    }
}
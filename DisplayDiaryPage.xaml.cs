using Google.Cloud.Firestore;
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
    /// Interaction logic for DisplayDiaryPage.xaml
    /// </summary>
    public partial class DisplayDiaryPage : Page
    {
        public DisplayDiaryPage()
        {
            InitializeComponent();
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
            ((selo)Application.Current.MainWindow).ContentFrame.Navigate(new DisplayDiaryPage());
        }
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            // Navigasi kembali ke halaman sebelumnya
            NavigationService.GoBack();
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
    }
}

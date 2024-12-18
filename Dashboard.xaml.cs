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

        public DashboardPage()
        {
            InitializeComponent();
            //LoadUsernameAsync();
        }
        
        //[BIAR GA ERROR DI GW BRO]

        //private async Task LoadUsernameAsync()
        //{
        //    string path = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "pawdoc-12345-firebase-adminsdk-u5zgj-2ae4b4ce7c.json");
        //    Console.WriteLine($"Path ke Service Account: {path}");
        //
        //    // Verifikasi apakah file ada di lokasi tersebut
        //    if (!System.IO.File.Exists(path))
        //    {
        //        throw new Exception($"File JSON tidak ditemukan di: {path}");
        //    }
        //
        //    Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", path);
        //    Console.WriteLine($"GOOGLE_APPLICATION_CREDENTIALS: {Environment.GetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS")}");
        //
        //
        //
        //    if (_firestore == null)
        //    {
        //        MessageBox.Show("Firestore belum diinisialisasi.");
        //        return;
        //    }
        //
        //    try
        //    {
        //        // Ambil email pengguna dari GlobalUser (pastikan sudah di-set)
        //        string userEmail = GlobalUser.CurrentUserEmail?.Trim();
        //        Console.WriteLine($"Email yang digunakan untuk query: '{userEmail}'");
        //        MessageBox.Show($"Email digunakan: '{userEmail}'");
        //
        //        if (string.IsNullOrEmpty(userEmail))
        //        {
        //            MessageBox.Show("Email pengguna tidak tersedia.");
        //            return;
        //        }
        //
        //        // Query Firestore berdasarkan email
        //        CollectionReference usersRef = _firestore.Collection("pawdoc");
        //        Query query = usersRef.WhereEqualTo("Email", userEmail);
        //        QuerySnapshot snapshot = await query.GetSnapshotAsync();
        //
        //        Console.WriteLine($"Jumlah dokumen ditemukan: {snapshot.Documents.Count}");
        //        MessageBox.Show($"Jumlah dokumen ditemukan: {snapshot.Documents.Count}");
        //
        //        if (snapshot.Documents.Count > 0)
        //        {
        //            foreach (DocumentSnapshot doc in snapshot.Documents)
        //            {
        //                Console.WriteLine($"Dokumen ID: {doc.Id}");
        //
        //                if (doc.Exists)
        //                {
        //                    string username = doc.GetValue<string>("Username");
        //                    Console.WriteLine($"Username ditemukan: {username}");

        //                    // Update UI
        //                    Dispatcher.Invoke(() =>
        //                    {
        //                        WelcomeTextBlock.Text = $"Welcome {username},";
        //                    });
        //                    return;
        //                }
        //                else
        //                {
        //                    Console.WriteLine("Dokumen ditemukan tetapi tidak ada isinya.");
        //                }
        //            }
        //        }

        //        // Jika tidak ditemukan
        //        Console.WriteLine("Dokumen tidak ditemukan.");
        //        Dispatcher.Invoke(() =>
        //        {
        //            WelcomeTextBlock.Text = "Welcome Guest,";
        //        });
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"Error saat mengambil data: {ex.Message}");
        //        Console.WriteLine($"Error detail: {ex.StackTrace}");
        //    }
        //}

        // Event Button Click Handler
        private void MakePetDiaryButton_Click(object sender, RoutedEventArgs e) 
        {
            // Navigasi ke halaman Set Up Pet Diary
            ((selo)Application.Current.MainWindow).ContentFrame.Navigate(new SetUpDiaryPage());
        }
        
        private void AddVetListButton_Click(object sender, RoutedEventArgs e) 
        {
            // Navigasi ke halaman Set Up Vet List
            ((selo)Application.Current.MainWindow).ContentFrame.Navigate(new SetUpVetList());
        }
        
        private void VetListButton_Click(object sender, RoutedEventArgs e) 
        {
            // Navigasi ke halaman Vet List
            ((selo)Application.Current.MainWindow).ContentFrame.Navigate(new VetListPage());
        }
        private void PetDiaryButton_Click(object sender, RoutedEventArgs e) 
        {
            // Navigasi ke halaman Display Pet Diary 
            ((selo)Application.Current.MainWindow).ContentFrame.Navigate(new DisplayDiaryPage());
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

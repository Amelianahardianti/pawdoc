using Google.Cloud.Firestore;
using System;
using System.Threading.Tasks;
using System.Windows;

namespace pawdoc
{
    public class FirestoreService
    {
        private readonly FirestoreDb _firestoreDb;

        public FirestoreService()
        {
            // Inisialisasi Firestore
            string path = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "pawdoc-12345-firebase-adminsdk-u5zgj-2ae4b4ce7c.json");
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", path);

            // Debug: Verifikasi path file
            Console.WriteLine($"Path JSON: {path}");
            if (!System.IO.File.Exists(path))
            {
                throw new Exception($"File JSON tidak ditemukan di: {path}");
            }

            _firestoreDb = FirestoreDb.Create("pawdoc-12345");
            Console.WriteLine("Koneksi ke Firestore berhasil.");
        }

        public async Task AddUserToFirestoreAsync(User user)
        {
            try
            {
                Console.WriteLine("Menghubungkan ke Firestore...");
                CollectionReference usersCollection = _firestoreDb.Collection("pawdoc");

                await usersCollection.AddAsync(user);

                // Debug: Konfirmasi jika data berhasil dikirim
                Console.WriteLine($"Data berhasil dikirim: Username: {user.Username}, Email: {user.Email}, Role: {user.Role}");
                MessageBox.Show("Data berhasil dikirim ke Firestore!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                // Debug: Log jika ada error
                Console.WriteLine($"Error saat menyimpan data: {ex.Message}");
                MessageBox.Show($"Error menyimpan data ke Firestore: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}

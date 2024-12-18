using Firebase.Auth;
using Google.Cloud.Firestore;
using pawdoc.Class;
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
            try
            {
                // Path file JSON kredensial Firebase
                string path = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "pawdoc-12345-firebase-adminsdk-u5zgj-2ae4b4ce7c.json");
                Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", path);

                // Debug: Cek apakah file JSON ada
                if (!System.IO.File.Exists(path))
                {
                    throw new Exception($"File JSON tidak ditemukan di: {path}");
                }

                // Inisialisasi koneksi Firestore
                _firestoreDb = FirestoreDb.Create("pawdoc-12345"); // Ganti sesuai Project ID Firebase
                Console.WriteLine("Koneksi ke Firestore berhasil.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Gagal menginisialisasi Firestore: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                throw;
            }
        }

        // Menambahkan user baru ke Firestore
        public async void AddUserToFirestoreAsync(User user)
        {
            try
            {
                if (user == null)
                    throw new ArgumentNullException(nameof(user), "Objek User tidak boleh null.");

                // Akses koleksi Firestore
                CollectionReference usersCollection = _firestoreDb.Collection("users");

                // Buat dokumen dengan ID unik
                DocumentReference docRef = usersCollection.Document(user.Email); // Username dijadikan ID dokumen

                // Tambahkan data user
                await docRef.SetAsync(user);
                MessageBox.Show($"User {user.Username} berhasil ditambahkan ke Firestore.");
                MessageBox.Show($"User {user.Username} berhasil disimpan!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saat menambahkan user ke Firestore: {ex.Message}");
                MessageBox.Show($"Gagal menambahkan user: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public async void AddDiaryEntryAsync(DiaryEntry diaryEntry)
        {
            try
            {
                // Akses koleksi Firestore
                CollectionReference usersCollection = _firestoreDb.Collection("diary");

                // Buat dokumen dengan ID unik
                DocumentReference docRef = usersCollection.Document($"${diaryEntry.Username}_{diaryEntry.DateCreated}"); // Username dijadikan ID dokumen

                await docRef.SetAsync(diaryEntry);
                MessageBox.Show($"User {diaryEntry.Username} berhasil ditambahkan ke Firestore.");

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Gagal saat memasukkan diary ke user: {ex.Message}");
            }
        }

        // Mendapatkan user dari Firestore berdasarkan username
        public async Task<User> GetUserFromFirestoreAsync(string email)
        {
            try
            {
                if (string.IsNullOrEmpty(email))
                    throw new ArgumentException("Username tidak boleh kosong.", nameof(email));

                // Akses koleksi Firestore dan dokumen
                DocumentReference docRef = _firestoreDb.Collection("users").Document(email);
                DocumentSnapshot snapshot = await docRef.GetSnapshotAsync();

                if (snapshot.Exists)
                {
                    User user = snapshot.ConvertTo<User>();
                    MessageBox.Show($"Data ditemukan: {user.Username}, Email: {user.Email}, Role: {user.Role}");
                    return user;
                }
                else
                {
                    Console.WriteLine($"User dengan email '{email}' tidak ditemukan.");
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saat mengambil data user: {ex.Message}");
                MessageBox.Show($"Gagal mengambil data user: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }
        }

       
    }
}

using Firebase.Auth;
using Google.Cloud.Firestore;
using Pawdoc;
using Pawdoc.UIComponents;
using System;
using System.Collections.Generic;
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
                CollectionReference diaryCollection = _firestoreDb.Collection("diary");

                // Buat dokumen dengan ID unik
                DocumentReference docRef = diaryCollection.Document($"{diaryEntry.Username}_{diaryEntry.DateCreated}");

                await docRef.SetAsync(diaryEntry);
                MessageBox.Show($"Diary entry untuk {diaryEntry.Username} berhasil disimpan!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Gagal saat memasukkan diary entry: {ex.Message}");
            }
        }

        // Mendapatkan user dari Firestore berdasarkan username
        public async Task<User> GetUserFromFirestoreAsync(string email)
        {
            try
            {
                if (string.IsNullOrEmpty(email))
                    throw new ArgumentException("Email tidak boleh kosong.", nameof(email));

                // Akses koleksi Firestore dan dokumen
                DocumentReference docRef = _firestoreDb.Collection("users").Document(email);
                DocumentSnapshot snapshot = await docRef.GetSnapshotAsync();

                if (snapshot.Exists)
                {
                    User user = snapshot.ConvertTo<User>();
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

        public async Task<User?> UpdateUserFromFirestoreAsync(string email, string username)
        {
            User currentUser = ((selo)Application.Current.MainWindow).user;
            try
            {
                DocumentReference docRef = _firestoreDb.Collection("users").Document(email);
                currentUser.Username = username;

                await docRef.UpdateAsync(new Dictionary<string, object>
                {
                    { "Username", username }
                });

                MessageBox.Show("Profile berhasil diupdate", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                return currentUser;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Gagal mengupdate profile: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }
        }

        public async Task<List<DiaryEntry>> GetDiaryEntriesAsync(User user)
        {
            try
            {
                // Define the query
                Query query = _firestoreDb.Collection("diary").WhereEqualTo("Username", user.Username);

                // Execute the query
                QuerySnapshot snapshot = await query.GetSnapshotAsync();

                // Convert the results to a list of DiaryEntry objects
                List<DiaryEntry> diaryEntries = new List<DiaryEntry>();

                foreach (DocumentSnapshot document in snapshot.Documents)
                {
                    if (document.Exists)
                    {
                        DiaryEntry entry = document.ConvertTo<DiaryEntry>();
                        diaryEntries.Add(entry);
                    }
                }

                return diaryEntries;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching diary entries: {ex.Message}");
                return new List<DiaryEntry>(); // Return an empty list if there's an error
            }
        }

        public async Task<bool> DeleteDiaryEntryAsync(string diaryId)
        {
            try
            {
                // Referensi ke dokumen yang ingin dihapus berdasarkan ID
                DocumentReference docRef = _firestoreDb.Collection("diary").Document(diaryId);

                // Eksekusi penghapusan dokumen
                await docRef.DeleteAsync();

                Console.WriteLine($"Diary entry with ID {diaryId} deleted successfully.");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting diary entry: {ex.Message}");
                return false;
            }
        }

    }
}

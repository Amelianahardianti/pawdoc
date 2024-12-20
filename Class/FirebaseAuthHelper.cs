using Firebase.Auth;
using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;

namespace pawdoc.Class
{
    public class FirebaseAuthHelper
    {
        // Konfigurasi Firebase Authentication dan Firestore
        private const string ApiKey = "AIzaSyBHkxCQxP2TdkVlJfoIiAjnWjWx_OHYVUQ"; // API Key Firebase
        private const string ProjectId = "pawdoc-12345"; // Ganti dengan Project ID Firestore Anda
        private FirebaseAuthProvider authProvider;
        private FirestoreDb firestoreDb;

        public FirebaseAuthHelper()
        {
            // Inisialisasi Firebase Authentication
            authProvider = new FirebaseAuthProvider(new FirebaseConfig(ApiKey));

            // Inisialisasi Firestore
            string path = "pawdoc-12345-firebase-adminsdk-u5zgj-2ae4b4ce7c.json"; // File Service Account JSON
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", path);
            // firestoreDb = FirestoreDb.Create(ProjectId);
        }

        // ------------------- AUTENTIKASI -------------------

        // Login dengan Email dan Password
        public async Task<FirebaseAuthLink> SignInWithEmailPasswordAsync(string email, string password)
        {
            try
            {
                var auth = await authProvider.SignInWithEmailAndPasswordAsync(email, password);
                MessageBox.Show("Login successful!");
                return auth;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                MessageBox.Show("Login failed.");
                return null;
            }
        }

        // Sign-Up (Daftar) dengan Email dan Password
        public async Task<FirebaseAuthLink> SignUpWithEmailPasswordAsync(string email, string password)
        {
            try
            {
                var auth = await authProvider.CreateUserWithEmailAndPasswordAsync(email, password);
                MessageBox.Show("User registration successful!");
                return auth;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                MessageBox.Show("Registration failed.");
                return null;
            }
        }

        // Reset Password
        public async Task ForgotPassword(string email)
        {
            try
            {
                await authProvider.SendPasswordResetEmailAsync(email);
                MessageBox.Show("Password reset email has been sent.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: No email found.");
            }
        }

        // ------------------- FIRESTORE DATABASE -------------------

        // Menambahkan User Baru ke Firestore
        public async Task AddUserToFirestoreAsync(User user)
        {
            try
            {
                CollectionReference usersCollection = firestoreDb.Collection("users");
                await usersCollection.AddAsync(user);
                MessageBox.Show("User added to Firestore successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding user: {ex.Message}");
            }
        }

        // Mengambil Semua Data User dari Firestore
        public async Task<List<User>> GetUsersFromFirestoreAsync()
        {
            try
            {
                CollectionReference usersCollection = firestoreDb.Collection("users");
                QuerySnapshot snapshot = await usersCollection.GetSnapshotAsync();

                var users = new List<User>();
                foreach (DocumentSnapshot document in snapshot.Documents)
                {
                    if (document.Exists)
                    {
                        var user = document.ConvertTo<User>();
                        users.Add(user);
                    }
                }
                return users;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching users: {ex.Message}");
                return null;
            }
        }
    }
}
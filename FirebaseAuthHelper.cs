using Firebase.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace pawdoc
{

    public class FirebaseAuthHelper
    {
        private const string ApiKey = "AIzaSyBHkxCQxP2TdkVlJfoIiAjnWjWx_OHYVUQ\r\n"; // Ganti dengan API Key Firebase
        private const string AuthDomain = "pawdoc-12345.firebaseapp.com"; // Ganti dengan Auth Domain Firebase
        private const string DatabaseUrl = "projects/pawdoc-12345/databases/(default)/documents";
        private FirebaseAuthProvider authProvider;

        public FirebaseAuthHelper()
        {
            authProvider = new FirebaseAuthProvider(new FirebaseConfig(ApiKey));
        }

        public async Task<FirebaseAuthLink> SignInWithEmailPasswordAsync(string email, string password)
        {
            try
            {
                var auth = await authProvider.SignInWithEmailAndPasswordAsync(email, password);
                return auth; // Mengembalikan FirebaseAuthLink yang berisi token dan user info
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return null;
            }
        }

        public async Task<FirebaseAuthLink> SignUpWithEmailPasswordAsync(string email, string password)
        {
            try
            {
                var auth = await authProvider.CreateUserWithEmailAndPasswordAsync(email, password);
                return auth;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return null;
            }
        }

        public async Task ForgotPassword(string email)
        {
            try
            {
                await authProvider.SendPasswordResetEmailAsync(email);
                MessageBox.Show("Email has been sent");
            }
            catch (Exception ex)
            {
                MessageBox.Show("No Email Found");
            }
        }

    }
}

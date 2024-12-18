using System;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Google.Cloud.Firestore; // Library Firestore
using System.IO;
using pawdoc;


namespace pawdoc
{
    public partial class App : Application
    {
        private readonly IHost _host;

        public App()
        {
            // Set environment variable untuk file Service Account Key Firebase
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "pawdoc-12345-firebase-adminsdk-u5zgj-2ae4b4ce7c.json");
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", path);
            Console.WriteLine($"Service Account Key Path: {path}"); // Debug path


            // Inisialisasi Host untuk Dependency Injection (opsional, jika digunakan)
            _host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    // Contoh: Daftarkan layanan yang akan digunakan
                    services.AddSingleton<FirestoreService>(); // Tambahkan layanan Firestore
                    services.AddSingleton<selo>(); // Tambahkan halaman utama
                })
                .Build();
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Pastikan layanan Dependency Injection siap
            await _host.StartAsync();

            // Ambil instance MainWindow atau layanan utama
            var mainWindow = _host.Services.GetRequiredService<selo>();
            mainWindow.Show();
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            // Pastikan host di-shutdown dengan baik
            await _host.StopAsync();
            base.OnExit(e);
        }

        public static class GlobalUser
        {
            public static string CurrentUserEmail { get; set; } // Menyimpan email pengguna yang login
        }

    }
}

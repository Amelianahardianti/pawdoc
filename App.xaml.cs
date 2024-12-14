using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using System.Windows;
using Firebase.Database;
using Firebase.Database.Query;
using Firebase.Auth;


namespace pawdoc
{
    public partial class App : Application
    {
        private readonly IHost _host;
        public App()
        {
            // Inisialisasi Host untuk dependency injection
            //_host = Host.CreateDefaultBuilder()
                //.ConfigureServices((context, services) =>
                //{

                //    String firebaseApiKey = context.Configuration.GetValue<String>("FIREBASE_API_KEY");
                //    // Daftarkan layanan atau halaman yang digunakan
                //    services.AddSingleton<selo>();
                //})
                //.Build();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Ambil instance MainWindow dan tampilkan
            // var mainWindow = _host.Services.GetRequiredService<selo>();
            var mainWindow = new selo();
            mainWindow.Show();
        }
    }
}


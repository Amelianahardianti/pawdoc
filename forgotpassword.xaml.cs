using pawdoc;
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
using System.Windows.Shapes;

namespace pawdoc
{
    /// <summary>
    /// Interaction logic for forgotpassword.xaml
    /// </summary>
    public partial class ForgotPassword : Page
    {
        public ForgotPassword()
        {
            InitializeComponent();
        }

        private async void SendButton_Click(object sender, RoutedEventArgs e)
        {
            string email = EmailTextBox.Text;
            var authContext = ((selo)Application.Current.MainWindow).FirebaseAuth;
            await authContext.ForgotPassword(email);
        }

        private void HyperlinkBack_Click(object sender, RoutedEventArgs e)
        {
            ((selo)Application.Current.MainWindow).ContentFrame.Navigate(new Login());
        }

       
        

    }
}

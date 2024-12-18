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
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class VetListPage : Page
    {
        public VetListPage()
        {
            InitializeComponent();
        }

        private void MyPetsButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void VetListButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MessageButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ProfileButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void PawDocButton_Click(object sender, RoutedEventArgs e)
        {
            ((selo)Application.Current.MainWindow).ContentFrame.Navigate(new DashboardPage(((selo)Application.Current.MainWindow).user));
        }
    }
}

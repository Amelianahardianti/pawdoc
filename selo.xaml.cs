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
    /// Interaction logic for selo.xaml
    /// </summary>
    public partial class selo : Window
    {
        public selo()
        {

       
            InitializeComponent();
            ContentFrame.Navigate(new Login());
        }
    }
}

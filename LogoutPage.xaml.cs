using ms.Utils;
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

namespace ms
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class LogoutPage : UserControl
    {
        private Requests _r;
        public LogoutPage(Requests r)
        {
            InitializeComponent();
            _r = r;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Content = new LoginUser(_r);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Content = new RegisterPage(_r);
        }
    }
}

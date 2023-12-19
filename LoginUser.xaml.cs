using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
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
using System.Net.Http;
using System.ComponentModel;
using ms.Utils;

namespace ms
{
    /// <summary>
    /// Interaction logic for LoginUser.xaml
    /// </summary>
    public partial class LoginUser : UserControl
    {

        Requests r = new Requests();


        public LoginUser()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {

            var r1 = await r.sendPostAsync("testing", "pass111");
          
            if (r1==true)
            {
                this.Content = new OwnedEventsPage(r);
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Content = new LogoutPage();
        }

        
    }
}

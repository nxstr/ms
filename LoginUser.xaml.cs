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
using ms.ViewModels;

namespace ms
{
    /// <summary>
    /// Interaction logic for LoginUser.xaml
    /// </summary>
    public partial class LoginUser : UserControl, INotifyPropertyChanged
    {

        private Requests _r;
        private string _name;
        private string _pass;
        public event PropertyChangedEventHandler PropertyChanged;


        public void OnPropertyChanged(string txt)
        {

            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                var e = new PropertyChangedEventArgs(txt);
                handler(this, e);
            }
        }


        public LoginUser(Requests r)
        {
            InitializeComponent();
            _r = r;
            DataContext = this;
        }

        public string Username
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        public string Pass
        {
            get { return _pass; }
            set
            {
                _pass = value;
                OnPropertyChanged(nameof(Pass));
            }
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                HttpResponseMessage response = _r.sendPostAsync(Name, Pass);
                if (response == null)
                {
                    errorText.Text = "Please try again, server is not responding!";
                }
                else
                {
                    if (response.IsSuccessStatusCode)
                    {
                        this.Content = new OwnedEventsPage(_r, false);
                    }
                    else
                    {
                        errorText.Text = "Username or password is not correct!";
                    }
                }
            }
            catch (TaskCanceledException ex)
            {
                errorText.Text = "Please try again, server is not responding!";
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Content = new LogoutPage(_r);
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            Pass = passwordBox.Password;
        }
    }
}

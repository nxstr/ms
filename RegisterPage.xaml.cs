using ms.Utils;
using ms.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for RegisterPage.xaml
    /// </summary>
    public partial class RegisterPage : UserControl, INotifyPropertyChanged
    {
        private Requests _r;
        private UserModel _user;
        private RelayCommand _saveCommand;
        private RelayCommand _cancelCommand;
        public RegisterPage(Requests r)
        {
            InitializeComponent();
            _r = r;
            User = new UserModel();
            DataContext = this;
        }

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

        public UserModel User
        {
            get { return _user; }
            set
            {
                _user = value;
                OnPropertyChanged(nameof(User));
            }
        }

        public RelayCommand SaveCommand
        {
            get
            {
                return _saveCommand ?? (_saveCommand = new RelayCommand(SaveItem, SaveItemCanExecute));
            }
        }

        public RelayCommand CancelCommand
        {
            get
            {
                return _cancelCommand ?? (_cancelCommand = new RelayCommand(CancelItem, CancelItemCanExecute));
            }
        }

        private void SaveItem(object parameter)
        {
            var res = _r.RegisterUser(User);
            if (res.IsSuccessStatusCode)
            {
                var r1 = _r.sendPostAsync(User.username, User.password);

                    this.Content = new OwnedEventsPage(_r, false);

            }else if (res.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                errorRegister.Text = "Username is already exist!";
            }
            else if (res.StatusCode == System.Net.HttpStatusCode.Conflict)
            {
                errorRegister.Text = "Email is already exist!";
            }
        }

        private bool SaveItemCanExecute(object parameter)
        {
            if (User.firstName != "" && User.lastName!="" && User.email!="" && User.username!="" && User.password!="")
            {
                return true;
            }
            
            else
            {
                return false;
            }

        }

        private void CancelItem(object parameter)
        {
            this.Content = new LogoutPage(_r);
        }

        private bool CancelItemCanExecute(object parameter)
        {
            return true;
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            User.password = UserPass.Password;
        }
    }
}

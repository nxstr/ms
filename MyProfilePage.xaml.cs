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
    /// Interaction logic for MyProfilePage.xaml
    /// </summary>
    public partial class MyProfilePage : UserControl, INotifyPropertyChanged
    {

        private Requests _r;
        private AccountModel _account;
        private UserModel _accountDetails;
        private UserModel _savedDetails;
        private string _newPass;
        private string _repeatPass;
        private RelayCommand _saveCommand;
        private RelayCommand _cancelCommand;
        private RelayCommand _changepassCommand;
        private bool isPass;
        public MyProfilePage(Requests r)
        {
            InitializeComponent();
            DataContext = this;
            _r = r;
            Account = new AccountModel();
            AccountDetails = new UserModel();
            SavedDetails = new UserModel();
            GetMyAccount();
            ProfilePanel.Content = FindResource("Details");
            isPass = false;

        }
        public event PropertyChangedEventHandler PropertyChanged;

        public AccountModel Account
        {
            get { return _account; }
            set
            {
                _account = value;
                OnPropertyChanged(nameof(Account));
            }
        }

        public string NewPass
        {
            get { return _newPass; }
            set
            {
                _newPass = value;
                OnPropertyChanged(nameof(NewPass));
            }
        }

        public string RepeatPass
        {
            get { return _repeatPass; }
            set
            {
                _repeatPass = value;
                if(value!=NewPass)
                {
                    
                }
                OnPropertyChanged(nameof(RepeatPass));
            }
        }

        public UserModel AccountDetails
        {
            get { return _accountDetails; }
            set
            {
                _accountDetails = value;
                OnPropertyChanged(nameof(AccountDetails));
            }
        }

        public UserModel SavedDetails
        {
            get { return _savedDetails; }
            set
            {
                _savedDetails = value;
                OnPropertyChanged(nameof(SavedDetails));
            }
        }

        public void OnPropertyChanged(string txt)
        {

            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                var e = new PropertyChangedEventArgs(txt);
                handler(this, e);
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

        public RelayCommand ChangePassCommand
        {
            get
            {
                return _changepassCommand ?? (_changepassCommand = new RelayCommand(ChangePassItem, ChangePassItemCanExecute));
            }
        }

        public void GetMyAccount()
        {
            Account = _r.GetMyAccount();
            SavedDetails = _r.GetUser(Account.Id);
            AccountDetails = _r.GetUser(Account.Id);
        }

        private void SaveItem(object parameter)
        {
            if (!isPass)
            {
                AccountDetails.password = "";
                var res = _r.UpdateUser(AccountDetails);
                if (res)
                {
                    this.Content = new OwnedEventsPage(_r, false);
                }
            }
            else
            {
                SavedDetails.password = NewPass;
                var res = _r.UpdateUser(SavedDetails);
                NewPass = "";
                RepeatPass = "";
                SavedDetails.password = "";
                if (res)
                {
                    this.Content = new OwnedEventsPage(_r, false);
                }
            }
            isPass = false;
            ProfilePanel.Content = FindResource("Details");
        }

        private bool SaveItemCanExecute(object parameter)
        {
            if(!isPass && (SavedDetails.firstName !=AccountDetails.firstName || 
                SavedDetails.lastName != AccountDetails.lastName || 
                SavedDetails.username != AccountDetails.username ||
                SavedDetails.email != AccountDetails.email))
            {
                return true;
            }else if(isPass && NewPass==RepeatPass && NewPass!="" && NewPass!=null)
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
            this.Content = new OwnedEventsPage(_r, false);
        }

        private bool CancelItemCanExecute(object parameter)
        {
            return true;
        }

        private void ChangePassItem(object parameter)
        {
            isPass = true;
            ProfilePanel.Content = FindResource("Password");
            Change.Visibility = Visibility.Hidden;
        }

        private bool ChangePassItemCanExecute(object parameter)
        {
            return true;
        }

       
    }
}

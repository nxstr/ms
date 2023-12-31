using ms.Utils;
using ms.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for EventInfoPage.xaml
    /// </summary>
    public partial class EventInfoPage : UserControl, INotifyPropertyChanged
    {
        private Requests _r;
        private EventModel _selectedDetail;
        private PollOptionModel _finalOption;
        private RelayCommand _closeCommand;
        private RelayCommand _deleteCommand;
        private RelayCommand _editCommand;
        private RelayCommand _backCommand;
        private RelayCommand _checkVotesCommand;
        private bool _isGuest;
        private ObservableCollection<UserModel> guestsDetails { get; set; }
        = new ObservableCollection<UserModel>();

        public event PropertyChangedEventHandler PropertyChanged;

        
        public EventInfoPage(Requests r, EventModel details, bool isGuest)
        {
            InitializeComponent();
            
            _r = r;
            SelectedDetail = details;
            checkIfFinalExist();
            _isGuest = isGuest;
            if(isGuest)
            {
                Panel.Content = FindResource("GuestPanel");
            }
            else
            {
                Panel.Content = FindResource("OwnerPanel");
            }
            foreach(var guest in SelectedDetail.Guests)
            {
                guestsDetails.Add(_r.GetUser(guest.Id));
            }
            Details.ItemsSource = guestsDetails;
            DataContext = this;
        }



        public EventModel SelectedDetail
        {
            get { return _selectedDetail; }
            set
            {
                _selectedDetail = value;
                OnPropertyChanged(nameof(SelectedDetail));
            }
        }

        public PollOptionModel FinalOption
        {
            get { return _finalOption; }
            set
            {
                _finalOption = value;
                OnPropertyChanged(nameof(FinalOption));
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

        public void checkIfFinalExist()
        {
            foreach(var item in SelectedDetail.eOptions)
            {
                if(item.isFinal == true)
                {
                    FinalOption = item;
                    return;
                }
            }
            FinalOption = null;
        }

        public RelayCommand CloseCommand
        {
            get
            {
                return _closeCommand ?? (_closeCommand = new RelayCommand(CloseItem, CloseItemCanExecute));
            }
        }

        public RelayCommand DeleteCommand
        {
            get
            {
                return _deleteCommand ?? (_deleteCommand = new RelayCommand(DeleteItem, DeleteItemCanExecute));
            }
        }

        public RelayCommand EditCommand
        {
            get
            {
                return _editCommand ?? (_editCommand = new RelayCommand(EditItem, EditItemCanExecute));
            }
        }
        public RelayCommand BackCommand
        {
            get
            {
                return _backCommand ?? (_backCommand = new RelayCommand(BackItem, BackItemCanExecute));
            }
        }

        public RelayCommand CheckVotesCommand
        {
            get
            {
                return _checkVotesCommand ?? (_checkVotesCommand = new RelayCommand(CheckVotes, CheckVotesCanExecute));
            }
        }

        private void CloseItem(object parameter)
        {
            
            var res = false;
            var id = SelectedDetail.id;
            res = _r.CloseEvent(id);
            if (res)
            {
                SelectedDetail = _r.GetEvent(id); 
                SelectedDetail.IsOpened = false;
                checkIfFinalExist();
            }
        }

        private bool CloseItemCanExecute(object parameter)
        {
            return SelectedDetail != null && SelectedDetail.TillDate > DateTime.Now;
        }

        private void DeleteItem(object parameter)
        {
            var res = false;
            if (SelectedDetail != null)
            {
                res = _r.DeleteEvent(SelectedDetail.id);
            }
            if (res)
            {
                this.Content = new OwnedEventsPage(_r, _isGuest);
            }
        }

        private bool DeleteItemCanExecute(object parameter)
        {
            return true;
        }

        private void EditItem(object parameter)
        {
            this.Content = new EventDetailPage(_r, SelectedDetail, FinalOption);
        }

        private bool EditItemCanExecute(object parameter)
        {
            return SelectedDetail.IsOpened;
        }

        private void BackItem(object parameter)
        {
            this.Content = new OwnedEventsPage(_r, _isGuest);
        }

        private bool BackItemCanExecute(object parameter)
        {
            return true;
        }

        private void CheckVotes(object parameter)
        {
            this.Content = new VotePage(_r, SelectedDetail, FinalOption, _isGuest);
        }

        private bool CheckVotesCanExecute(object parameter)
        {
            return true;
        }
    }
}

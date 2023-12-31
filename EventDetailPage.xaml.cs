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
    /// Interaction logic for EventDetailPage.xaml
    /// </summary>
    public partial class EventDetailPage : UserControl, INotifyPropertyChanged
    {
        private Requests _r;
        private EventModel _selectedDetail;
        private PollOptionModel _finalOption;
        private DateTime _newOption;
        private RelayCommand _setFinalOptionCommand;
        private RelayCommand _deleteOptionCommand;
        private RelayCommand _addOptionCommand;
        private PollOptionModel _selectedOption;
        private string _newUsername;
        private string _newEmail;
        private AccountModel _selectedGuest;
        private RelayCommand _deleteGuestCommand;
        private RelayCommand _addUsernameCommand;
        private RelayCommand _addEmailCommand;
        private RelayCommand _saveCommand;
        private RelayCommand _cancelCommand;

        public event PropertyChangedEventHandler PropertyChanged;
        public EventDetailPage(Requests r, EventModel details, PollOptionModel final)
        {
            InitializeComponent();
            DataContext = this;
            _r = r;
            SelectedDetail = details;
            FinalOption = final;
            NewPollOption = DateTime.Now;
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

        public EventModel SelectedDetail
        {
            get { return _selectedDetail; }
            set
            {
                _selectedDetail = value;
                OnPropertyChanged(nameof(SelectedDetail));
            }
        }

        public AccountModel SelectedGuest
        {
            get { return _selectedGuest; }
            set
            {
                _selectedGuest = value;
                OnPropertyChanged(nameof(SelectedGuest));
            }
        }

        public DateTime NewPollOption
        {
            get { return _newOption; }
            set
            {
                _newOption = value;
                OnPropertyChanged(nameof(NewPollOption));
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

        public PollOptionModel SelectedOption
        {
            get { return _selectedOption; }
            set
            {
                _selectedOption = value;
                OnPropertyChanged(nameof(SelectedOption));
            }
        }

        public string NewUsername
        {
            get { return _newUsername; }
            set
            {
                _newUsername = value;
                OnPropertyChanged(nameof(NewUsername));
            }
        }

        public string NewEmail
        {
            get { return _newEmail; }
            set
            {
                _newEmail = value;
                OnPropertyChanged(nameof(NewEmail));
            }
        }

        public RelayCommand SetFinalOptionCommand
        {
            get
            {
                return _setFinalOptionCommand ?? (_setFinalOptionCommand = new RelayCommand(SetFinalOption, SetFinalOptionCanExecute));
            }
        }

        public RelayCommand DeleteOptionCommand
        {
            get
            {
                return _deleteOptionCommand ?? (_deleteOptionCommand = new RelayCommand(DeleteOption, DeleteOptionCanExecute));
            }
        }

        public RelayCommand AddOptionCommand
        {
            get
            {
                return _addOptionCommand ?? (_addOptionCommand = new RelayCommand(AddOption, AddOptionCanExecute));
            }
        }

        public RelayCommand DeleteGuestCommand
        {
            get
            {
                return _deleteGuestCommand ?? (_deleteGuestCommand = new RelayCommand(DeleteGuest, DeleteGuestCanExecute));
            }
        }

        public RelayCommand AddUsernameCommand
        {
            get
            {
                return _addUsernameCommand ?? (_addUsernameCommand = new RelayCommand(AddUsername, AddUsernameCanExecute));
            }
        }

        public RelayCommand AddEmailCommand
        {
            get
            {
                return _addEmailCommand ?? (_addEmailCommand = new RelayCommand(AddEmail, AddEmailCanExecute));
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

        private void DeleteOption(object parameter)
        {
            var res = false;
            if (SelectedOption != null)
            {
                res = _r.DeleteOption(SelectedDetail.id, SelectedOption.id);
            }
            if (res)
            {
                SelectedDetail = _r.GetEvent(SelectedDetail.id);
                checkIfFinalExist();
            }
        }

        private bool DeleteOptionCanExecute(object parameter)
        {
            return SelectedOption != null && SelectedDetail.eOptions.Count>1;
        }

        private void SetFinalOption(object parameter)
        {
            var res = false;
            var tmp = SelectedOption;
            if (SelectedOption != null)
            {
                res = _r.SetFinalOption(SelectedOption.id);
            }
            if (res)
            {
                SelectedDetail = _r.GetEvent(SelectedDetail.id);
                FinalOption = tmp;
            }
        }

        private bool SetFinalOptionCanExecute(object parameter)
        {
            return SelectedOption!=null && SelectedOption!=FinalOption;
        }

        public void checkIfFinalExist()
        {
            foreach (var item in SelectedDetail.eOptions)
            {
                if (item.isFinal == true)
                {
                    FinalOption = item;
                    return;
                }
            }
            FinalOption = null;
        }

        private void AddOption(object parameter)
        {
            var res = false;
            if (NewPollOption != null)
            {
                var newOption = new PollOptionModel();
                newOption.dateSlot = DateOnly.FromDateTime(NewPollOption);
                newOption.timeSlot = TimeOnly.FromDateTime(NewPollOption);
                newOption.eventId = SelectedDetail.id;
                res = _r.AddOption(newOption);
            }
            if (res)
            {
                SelectedDetail = _r.GetEvent(SelectedDetail.id);
                checkIfFinalExist();
            }
        }

        private bool AddOptionCanExecute(object parameter)
        {
            if (SelectedDetail.eOptions != null)
            {
                foreach (var item in SelectedDetail.eOptions)
                {
                    DateOnly newDate = DateOnly.FromDateTime(NewPollOption);

                    if (item.dateSlot == newDate && item.timeSlot.Hour == NewPollOption.Hour && item.timeSlot.Minute == NewPollOption.Minute)
                    {
                        return false;
                    }
                }
            }
            return NewPollOption != null && NewPollOption>=DateTime.Now;
        }

        private void AddUsername(object parameter)
        {
            var res = false;
            errorGuest.Text = null;
            res = _r.AddUsername(NewUsername, SelectedDetail.id);
            if (res)
            {
                SelectedDetail = _r.GetEvent(SelectedDetail.id);
                checkIfFinalExist();
                NewUsername = null;
            }
            else
            {
                errorGuest.Text = "You can not add this username to event";
            }
        }

        private bool AddUsernameCanExecute(object parameter)
        {
            if(SelectedDetail.Guests != null)
            {
                foreach (var item in SelectedDetail.Guests)
                {
                    if (item.Username == NewUsername) { return false; }
                }
            }
            return NewUsername != null;
        }

        private void AddEmail(object parameter)
        {
            var res = false;
            errorGuest.Text = null;
            res = _r.AddEmail(NewEmail, SelectedDetail.id);
            var tmp = NewEmail;
            if (res)
            {
                SelectedDetail = _r.GetEvent(SelectedDetail.id);
                checkIfFinalExist();
                errorGuest.Text = "You sent request to email " + tmp;
                NewEmail = null;
            }
            else
            {
                errorGuest.Text = "You can not add this email to event";
            }
        }

        private bool AddEmailCanExecute(object parameter)
        {
            return NewEmail != null;
        }

        private void DeleteGuest(object parameter)
        {
            var res = false;
            res = _r.DeleteGuest(SelectedDetail.id, SelectedGuest.Id);
            if (res)
            {
                SelectedDetail = _r.GetEvent(SelectedDetail.id);
                checkIfFinalExist();
            }
        }

        private bool DeleteGuestCanExecute(object parameter)
        {
            return SelectedGuest != null;
        }

        private void SaveItem(object parameter)
        {
            var res = false;
            res = _r.UpdateEvent(SelectedDetail);
            if (res)
            {
                this.Content = new EventInfoPage(_r, SelectedDetail, false);
            }
        }

        private bool SaveItemCanExecute(object parameter)
        {
            return true;
        }

        private void CancelItem(object parameter)
        {
            this.Content = new EventInfoPage(_r, SelectedDetail, false);
        }

        private bool CancelItemCanExecute(object parameter)
        {
            return true;
        }

    }
}

using ms.Utils;
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

        public event PropertyChangedEventHandler PropertyChanged;

        
        public EventInfoPage(Requests r, EventModel details)
        {
            InitializeComponent();
            DataContext = this;
            _r = r;
            SelectedDetail = details;
            checkIfFinalExist();
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
                this.Content = new OwnedEventsPage(_r);
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
            this.Content = new OwnedEventsPage(_r);
        }

        private bool BackItemCanExecute(object parameter)
        {
            return true;
        }
    }
}

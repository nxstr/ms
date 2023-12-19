using ms.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
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
    /// Interaction logic for NewEventPage.xaml
    /// </summary>
    public partial class NewEventPage : UserControl, INotifyPropertyChanged
    {
        private Requests _r;
        private EventModel _newEvent;
        private RelayCommand _saveCommand;
        private RelayCommand _cancelCommand;

        public event PropertyChangedEventHandler PropertyChanged;
        public NewEventPage(Requests r)
        {
            InitializeComponent();
            DataContext = this;
            _r = r;
            NewEvent = new EventModel();
            NewEvent.TillDate = DateTime.Now;
        }

        public EventModel NewEvent
        {
            get { return _newEvent; }
            set { _newEvent = value; 
                OnPropertyChanged(nameof(NewEvent));
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                var e = new PropertyChangedEventArgs(propertyName);
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

        private void SaveItem(object parameter)
        {
            var res = _r.CreateEvent(NewEvent);
            if (res!=null)
            {
                this.Content = new EventDetailPage(_r, res, null);
            }
        }

        private bool SaveItemCanExecute(object parameter)
        {
            if(NewEvent != null)
            {
                if(NewEvent.EventName != null && NewEvent.Detail != null && NewEvent.Location != null && NewEvent.TillDate > DateTime.Now)
                {
                    return true;
                }
            }
            return NewEvent!=null;
        }

        private void CancelItem(object parameter)
        {
            this.Content = new OwnedEventsPage(_r);
        }

        private bool CancelItemCanExecute(object parameter)
        {
            return true;
        }
    }
}

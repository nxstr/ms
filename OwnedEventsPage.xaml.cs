using ms.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection.Metadata;
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
using ms.Utils;
using System.ComponentModel;

namespace ms
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class OwnedEventsPage : UserControl, INotifyPropertyChanged
    {
        private Requests _r;
        private RelayCommand _closeCommand;
        private RelayCommand _deleteCommand;
        private RelayCommand _detailsCommand;
        private EventModel _selectedDetail;

        public ObservableCollection<EventModel> EventsList { get; set; }
            = new ObservableCollection<EventModel>();

        public event PropertyChangedEventHandler PropertyChanged;

        public EventModel SelectedDetail
        {
            get { return _selectedDetail; }
            set
            {
                _selectedDetail = value;
                OnPropertyChanged(nameof(SelectedDetail));
            }
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

        public RelayCommand DetailsCommand
        {
            get
            {
                return _detailsCommand ?? (_detailsCommand = new RelayCommand(DetailsItem, DetailsItemCanExecute));
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

        public OwnedEventsPage(Requests r)
        {
            InitializeComponent();
            _r = r;
            DataContext = this;
            getAllOwnedEvents();
            sortingBox.SelectedIndex = 0;
            dropdownMenu.SelectedIndex = 0;
        }

        public void ChangeSection(object sender, SelectionChangedEventArgs e)
        {

            if (sortingBox.SelectedIndex == 0)
            {
                getAllOwnedEvents();
            }
            else if (sortingBox.SelectedIndex == 1)
            {
                getAllOpenEvents();
            }
            else if (sortingBox.SelectedIndex == 2)
            {
                getAllClosedEvents();
            }
        }

        public void ChangeMainSection(object sender, SelectionChangedEventArgs e)
        {

            if (dropdownMenu.SelectedIndex == 0)
            {
                getAllOwnedEvents();
            }
            else if (dropdownMenu.SelectedIndex == 2)
            {
                this.Content = new NewEventPage(_r);
            }
            
        }

        public void getAllOwnedEvents()
        {

            var res = _r.GetWebsiteDataAsync();
            EventsList.Clear();
            foreach (var item in res)
            {
                if (item.openDueTo <= DateTime.Now)
                {

                    item.IsOpened = false;
                }
                else
                {
                    item.IsOpened = true;
                }
                EventsList.Add(item);
            }
            eList.ItemsSource = EventsList;

        }

        public void getAllOpenEvents()
        {
            ObservableCollection<EventModel> OpenedEventsList
                        = new ObservableCollection<EventModel>();
            foreach (var item in EventsList)
            {
                if (item.openDueTo > DateTime.Now)
                {

                    OpenedEventsList.Add(item);
                }

            }
            eList.ItemsSource = OpenedEventsList;

        }

        public void getAllClosedEvents()
        {
            ObservableCollection<EventModel> ClosedEventsList
            = new ObservableCollection<EventModel>();
            foreach (var item in EventsList)
            {
                if (item.openDueTo <= DateTime.Now)
                {

                    ClosedEventsList.Add(item);
                }

            }
            eList.ItemsSource = ClosedEventsList;
            

        }
        private void CloseItem(object parameter)
        {
            var selectedEvent = parameter as EventModel;
            var res = false;
            if (selectedEvent != null && selectedEvent.TillDate > DateTime.Now)
            {
                res = _r.CloseEvent(selectedEvent.id);
            }
            if(res)
            {
                getAllOwnedEvents();
                sortingBox.SelectedIndex = 0;
            }
        }

        private bool CloseItemCanExecute(object parameter)
        {
            return parameter is EventModel;
        }

        private void DeleteItem(object parameter)
        {
            var selectedEvent = parameter as EventModel;
            var res = false;
            if (selectedEvent != null)
            {
                res = _r.DeleteEvent(selectedEvent.id);
            }
            if (res)
            {
                getAllOwnedEvents();
                sortingBox.SelectedIndex = 0;
            }
        }

        private bool DeleteItemCanExecute(object parameter)
        {
            return parameter is EventModel;
        }

        private void DetailsItem(object parameter)
        {
            var selectedEvent = parameter as EventModel;
            if (selectedEvent != null)
            {
                this.Content = new EventInfoPage(_r, selectedEvent);
            }
        }

        private bool DetailsItemCanExecute(object parameter)
        {
            return parameter is EventModel;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ms.Utils
{
    public class EventModel: ViewModelBase
    {
        public int id { get; set; }
        public string name;
        public string detail;
        public DateTime openDueTo;
        public string location;

        public int ownerId { get; set; }

        public List<AccountModel> guests { get; set; }
        public List<PollOptionModel> pollOptions { get; set; }

        private bool _isOpened;
        public bool IsOpened
        {
            get { return _isOpened; }
            set
            {
                if (_isOpened != value)
                {
                    _isOpened = value;
                    OnPropertyChanged(nameof(IsOpened));
                }
            }
        }

        public string EventName
        {
            get { return name; }
            set { name = value; 
                OnPropertyChanged(nameof(EventName)); 
            }
        }

        public string Detail
        {
            get { return detail; }
            set
            {
                detail = value;
                OnPropertyChanged(nameof(Detail));
            }
        }

        public string Location
        {
            get { return location; }
            set
            {
                location = value;
                OnPropertyChanged(nameof(Location));
            }
        }

        public DateTime TillDate
        {
            get { return openDueTo; }
            set
            {
                openDueTo = value;
                OnPropertyChanged(nameof(TillDate));
            }
        }

        public List<PollOptionModel> eOptions
        {
            get { return pollOptions; }
            set
            {
                pollOptions = value;
                OnPropertyChanged(nameof(eOptions));
            }
        }

        public List<AccountModel> Guests
        {
            get { return guests; }
            set
            {
                guests = value;
                OnPropertyChanged(nameof(Guests));
            }
        }
    }
}

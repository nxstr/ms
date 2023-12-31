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
    /// Interaction logic for VotePage.xaml
    /// </summary>
    public partial class VotePage : UserControl, INotifyPropertyChanged
    {
        private Requests _r;
        private EventModel _selectedDetail;
        private PollOptionModel _finalOption;
        private PollOptionModel _selectedOption;
        private RelayCommand _backCommand;
        private RelayCommand _leaveCommand;
        private RelayCommand _addVoteCommand;
        public event PropertyChangedEventHandler PropertyChanged;
        private string _selectedRadio;
        private string _comment;
        IDictionary<string, string> voteDictionary = new Dictionary<string, string>(){
    {"yes", "POSITIVE"},
    {"maybe", "NEUTRAL"},
    {"no", "NEGATIVE"}
};

        private ObservableCollection<PollOptionWrapper> _pollOptionsWithVotes;
        private PollOptionWrapper _selectedPollOptionWrapper;
        private ObservableCollection<VoteWrapper> _votesWithUsers;
        private bool _isGuest;

        public ObservableCollection<PollOptionWrapper> PollOptionsWithVotes
        {
            get { return _pollOptionsWithVotes; }
            set
            {
                _pollOptionsWithVotes = value;
                OnPropertyChanged(nameof(PollOptionsWithVotes));
            }
        }

        public ObservableCollection<VoteWrapper> VotesWithUsers
        {
            get { return _votesWithUsers; }
            set
            {
                _votesWithUsers = value;
                OnPropertyChanged(nameof(VotesWithUsers));
            }
        }

        public VotePage(Requests r, EventModel details, PollOptionModel final, bool isGuest)
        {
            InitializeComponent();
            DataContext = this;
            _r = r;
            SelectedDetail = details;
            FinalOption = final;
            GetVotesValues();
            _isGuest = isGuest;
            if (isGuest)
            {
                Guest.Content = FindResource("GuestPanel");
                Scroll.Height = 280;
                OptionsForVote.IsHitTestVisible = true;
            }
            else
            {
                Leave.Visibility = Visibility.Hidden;
                OptionsForVote.IsHitTestVisible = false;
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

        public void GetVotesValues()
        {
            var optionsWithVotes = new ObservableCollection<PollOptionWrapper>();
            
            var users = new ObservableCollection<UserModel>();
            foreach(var guest in SelectedDetail.Guests)
            {
                users.Add(_r.GetUser(guest.Id));
            }
            foreach (var option in SelectedDetail.pollOptions)
            {
                int positiveVoteCount = option.Votes.Count(vote => vote.VoteType == "POSITIVE_VOTE");
                int neutralVoteCount = option.Votes.Count(vote => vote.VoteType == "NEUTRAL_VOTE");
                int negativeVoteCount = option.Votes.Count(vote => vote.VoteType == "NEGATIVE_VOTE");

                var usersWVotes = new ObservableCollection<VoteWrapper>();
                foreach (var vote in option.Votes)
                {
                    foreach(var user in users)
                    {
                        if(user.id == vote.guestId)
                        {
                            usersWVotes.Add(new VoteWrapper
                            {
                                Vote = vote,
                                User = user
                            });
                        }
                    }
                }
                optionsWithVotes.Add(new PollOptionWrapper
                {
                    Option = option,
                    PositiveVoteCount = positiveVoteCount,
                    NeutralVoteCount = neutralVoteCount,
                    NegativeVoteCount = negativeVoteCount,
                    Votes = usersWVotes
                });
            }

            PollOptionsWithVotes = optionsWithVotes;

            
            
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

        public PollOptionModel SelectedOption
        {
            get { return _selectedOption; }
            set
            {
                _selectedOption = value;
                OnPropertyChanged(nameof(SelectedOption));
            }
        }

        public PollOptionWrapper SelectedPollOptionWrapper
        {
            get { return _selectedPollOptionWrapper; }
            set
            {
                _selectedPollOptionWrapper = value;
                OnPropertyChanged(nameof(SelectedPollOptionWrapper));
            }
        }

        public string Comment
        {
            get { return _comment; }
            set
            {
                if (_comment != value)
                {
                    _comment = value;
                    OnPropertyChanged(nameof(Comment));
                }
            }
        }

        public string SelectedRadio
        {
            get { return _selectedRadio; }
            set
            {
                if (_selectedRadio != value)
                {
                    _selectedRadio = value;
                    OnPropertyChanged(nameof(SelectedRadio));
                }
            }
        }

        public RelayCommand AddVoteCommand
        {
            get
            {
                return _addVoteCommand ?? (_addVoteCommand = new RelayCommand(AddVote, AddVoteCanExecute));
            }
        }

        public RelayCommand BackCommand
        {
            get
            {
                return _backCommand ?? (_backCommand = new RelayCommand(BackItem, BackItemCanExecute));
            }
        }

        public RelayCommand LeaveCommand
        {
            get
            {
                return _leaveCommand ?? (_leaveCommand = new RelayCommand(LeaveItem, LeaveItemCanExecute));
            }
        }

        private void AddVote(object parameter)
        {
            var res = false;
            var newVote = new VoteModel();
            if(Comment != null)
            {
                newVote.comment = Comment;
            }
            else
            {
                newVote.comment = "";
            }
            newVote.voteType = voteDictionary[SelectedRadio];
            newVote.pollOptionId = SelectedPollOptionWrapper.Option.id;
            //var r = _r.GetMyAccount();
            //if(r != null)
            //{
            //    newVote.guestId = r.id;
            //}
            res = _r.AddVote(newVote);
            if(res)
            {
                SelectedDetail = _r.GetEvent(SelectedDetail.id);
                GetVotesValues();
                SelectedPollOptionWrapper = null;
                SelectedRadio = null;
                Comment = "";
            }
        }

        private bool AddVoteCanExecute(object parameter)
        {
            if(SelectedPollOptionWrapper == null)
            {
                return false;
            }
            return SelectedRadio != null && SelectedPollOptionWrapper.Option != null;
        }

        private void BackItem(object parameter)
        {
            this.Content = new OwnedEventsPage(_r, _isGuest);
        }

        private bool BackItemCanExecute(object parameter)
        {
            return true;
        }

        private void LeaveItem(object parameter)
        {
            var res = false;
            res = _r.LeaveEvent(SelectedDetail.id);
            if (res)
            {
                this.Content = new OwnedEventsPage(_r, _isGuest);
            }
            
        }

        private bool LeaveItemCanExecute(object parameter)
        {
            if (SelectedDetail.TillDate >= DateTime.Now)
            {
                return true;
            }
            return false;
        }
    }
}

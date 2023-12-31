using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ms.Utils;

namespace ms.ViewModels
{
    public class VoteModel : ViewModelBase
    {
        public int id { get; set; }
        public string comment;
        public string voteType;
        public int guestId { get; set; }
        public int pollOptionId;

        public int GuestId
        {
            get { return guestId; }
            set
            {
                guestId = value;
                OnPropertyChanged(nameof(GuestId));
            }
        }

        public string VoteType
        {
            get { return voteType; }
            set
            {
                voteType = value;
                OnPropertyChanged(nameof(VoteType));
            }
        }

        public string Comment
        {
            get { return comment; }
            set
            {
                comment = value;
                OnPropertyChanged(nameof(Comment));
            }
        }

        public int PollOptionId
        {
            get { return pollOptionId; }
            set
            {
                pollOptionId = value;
                OnPropertyChanged(nameof(PollOptionId));
            }
        }
    }
}

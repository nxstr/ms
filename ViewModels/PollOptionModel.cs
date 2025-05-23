﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ms.Utils;

namespace ms.ViewModels
{
    public class PollOptionModel : ViewModelBase
    {
        public int id { get; set; }
        public DateOnly dateSlot;
        public TimeOnly timeSlot;
        public bool isFinal { get; set; }
        public int eventId { get; set; }
        public List<VoteModel> votes { get; set; }

        public DateOnly DateSlot
        {
            get { return dateSlot; }
            set
            {
                dateSlot = value;
                OnPropertyChanged(nameof(DateSlot));
            }
        }
        public TimeOnly TimeSlot
        {
            get { return timeSlot; }
            set
            {
                timeSlot = value;
                OnPropertyChanged(nameof(TimeSlot));
            }
        }

        public List<VoteModel> Votes
        {
            get { return votes; }
            set
            {
                votes = value;
                OnPropertyChanged(nameof(Votes));
            }
        }
    }
}

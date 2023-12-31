using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ms.ViewModels;

namespace ms.Utils
{
    public class PollOptionWrapper: DependencyObject
    {
        public static readonly DependencyProperty option =
            DependencyProperty.Register("option", typeof(PollOptionModel), typeof(PollOptionWrapper));

        public PollOptionModel Option
        {
            get { return (PollOptionModel)GetValue(option); }
            set { SetValue(option, value); }
        }

        public static readonly DependencyProperty positiveVoteCount =
            DependencyProperty.Register("positiveVoteCount", typeof(int), typeof(PollOptionWrapper));

        public int PositiveVoteCount
        {
            get { return (int)GetValue(positiveVoteCount); }
            set { SetValue(positiveVoteCount, value); }
        }

        public static readonly DependencyProperty neutralVoteCount =
            DependencyProperty.Register("neutralVoteCount", typeof(int), typeof(PollOptionWrapper));

        public int NeutralVoteCount
        {
            get { return (int)GetValue(neutralVoteCount); }
            set { SetValue(neutralVoteCount, value); }
        }

        public static readonly DependencyProperty negativeVoteCount =
            DependencyProperty.Register("negativeVoteCount", typeof(int), typeof(PollOptionWrapper));

        public int NegativeVoteCount
        {
            get { return (int)GetValue(negativeVoteCount); }
            set { SetValue(negativeVoteCount, value); }
        }

        public static readonly DependencyProperty votes =
            DependencyProperty.Register(
                nameof(Votes),
                typeof(ObservableCollection<VoteWrapper>),
                typeof(PollOptionWrapper),
                new PropertyMetadata(null));

        public ObservableCollection<VoteWrapper> Votes
        {
            get { return (ObservableCollection<VoteWrapper>)GetValue(votes); }
            set { SetValue(votes, value); }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ms.ViewModels;

namespace ms.Utils
{
    public class VoteWrapper: DependencyObject
    {
        public static readonly DependencyProperty vote =
            DependencyProperty.Register("vote", typeof(VoteModel), typeof(VoteWrapper));

        public VoteModel Vote
        {
            get { return (VoteModel)GetValue(vote); }
            set { SetValue(vote, value); }
        }

        public static readonly DependencyProperty user =
            DependencyProperty.Register("user", typeof(UserModel), typeof(VoteWrapper));

        public UserModel User
        {
            get { return (UserModel)GetValue(user); }
            set { SetValue(user, value); }
        }
    }
}

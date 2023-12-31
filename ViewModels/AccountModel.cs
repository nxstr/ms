using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;

namespace ms.ViewModels
{
    public class AccountModel : DependencyObject
    {

        public static readonly DependencyProperty id =
            DependencyProperty.Register("id", typeof(int), typeof(AccountModel));

        public int Id
        {
            get { return (int)GetValue(id); }
            set { SetValue(id, value); }
        }

        public static readonly DependencyProperty username =
            DependencyProperty.Register("username", typeof(string), typeof(AccountModel));

        public string Username
        {
            get { return (string)GetValue(username); }
            set { SetValue(username, value); }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ms.Utils
{
    public class AccountModel : ViewModelBase
    {
        public int id { get; set; }
        public string username;

        public string AccountName
        {
            get { return username; }
            set
            {
                username = value;
                OnPropertyChanged(nameof(AccountName));
            }
        }
    }
}

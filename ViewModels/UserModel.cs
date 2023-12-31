using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ms.Utils;

namespace ms.ViewModels
{
    public class UserModel: ViewModelBase
    {
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        
        public List<EventModel> ownedEvents { get; set; }

        public List<EventModel> guestEvents { get; set; }

        public List<VoteModel> votes { get; set; }
    }
}

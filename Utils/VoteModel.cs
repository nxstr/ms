using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ms.Utils
{
    public class VoteModel
    {
        public int id { get; set; }
        public string comment { get; set; }
        public string voteType { get; set; }
        public int guestId { get; set; }
        public int optionId { get; set; }
    }
}

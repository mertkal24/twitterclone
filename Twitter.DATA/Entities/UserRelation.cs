using System;
using System.Collections.Generic;
using System.Text;

namespace Twitter.DATA.Entities
{
   public  class UserRelation
    {
        public int SenderID { get; set; }
        public int RecipientID { get; set; }
        public bool isAccepted { get; set; } = false;
        public bool isActive { get; set; } = true;
        public User User { get; set; }
        public User User1 { get; set; }

    }
}

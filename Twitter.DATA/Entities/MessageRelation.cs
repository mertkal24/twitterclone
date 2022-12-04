using System;
using System.Collections.Generic;
using System.Text;

namespace Twitter.DATA.Entities
{
    public class MessageRelation
    {
        public int ID { get; set; }
        public int SenderUserID { get; set; }
        public int UserID { get; set; }
        public bool IsContinue { get; set; }
    }
}

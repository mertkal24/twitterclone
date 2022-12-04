using System;
using System.Collections.Generic;
using System.Text;

namespace Twitter.DATA.Entities
{
    public  class Message
    {
        public int ID { get; set; }
        public int SenderID { get; set; }
        public int RecipientID { get; set; }
        public DateTime CreatedDate { get; set; }
        public string MessageContent { get; set; }
        public User Sender { get; set; }
        public User Recipient { get; set; }

    }
}

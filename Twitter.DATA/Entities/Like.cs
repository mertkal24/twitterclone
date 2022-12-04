using System;
using System.Collections.Generic;
using System.Text;

namespace Twitter.DATA.Entities
{
   public  class Like
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public int? PostID { get; set; }
        public int? CommentID { get; set; }
        public bool isActive { get; set; }
        public User User { get; set; }
        public Post Post { get; set; }
        public Comment Comment { get; set; }
        

    }
}

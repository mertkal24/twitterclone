using System;
using System.Collections.Generic;
using System.Text;

namespace Twitter.CORE.Common
{
   public class CommentDTO
    {
        public int ID { get; set; }
        public int PostID { get; set; }
        public int UserID { get; set; }
        public string CommentContent { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public int? ParentCommentID { get; set; }
        public string UserProfilePicture { get; set; }
        public string UserNameSurname { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Twitter.CORE.Common
{
   public class PostDTO
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string PostContent { get; set; }
        public string Image { get; set; }
        public string UserName { get; set; }
        public string UserSurname { get; set; }
        public string UserProfilePicture { get; set; }
        public List<CommentDTO> postComments { get; set; }
    }
}

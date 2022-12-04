using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Twitter.DATA.Entities
{
   public class Comment
    {
        public Comment()
        {
            this.Likes = new List<Like>();
        }
        public int ID { get; set; }
        public int PostID { get; set; }
        public int UserID { get; set; }
        [MaxLength(280)]
        public string CommentContent { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? ParentCommentID { get; set; }
        public virtual ICollection<Like> Likes { get; set; }
        public virtual Comment ParentComment { get; set; }
        public Post Post { get; set; }
        public User User { get; set; }


    }
}

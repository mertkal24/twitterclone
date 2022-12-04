using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Twitter.DATA.Entities
{
    public class Post
    {
        public Post()
        {
            this.Likes = new List<Like>();
            this.Comments = new List<Comment>();
        }
        public int ID { get; set; }
        public int UserID { get; set; }
        public DateTime CreatedDate { get; set; }
        [MaxLength(280)]
        public string PostContent { get; set; }
        [MaxLength(250)]
        public string Image { get; set; }
        public User User { get; set; }
        public virtual ICollection<Like> Likes { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }

    }
}

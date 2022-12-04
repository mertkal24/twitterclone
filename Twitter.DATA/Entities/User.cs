using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Twitter.DATA.Entities
{
    public class User
    {
        public User()
        {
            this.UserRelations1 = new List<UserRelation>();
            this.UserRelations2 = new List<UserRelation>();
            this.Posts = new List<Post>();
            this.Likes = new List<Like>();
            this.Comments = new List<Comment>();
            this.Messages1 = new List<Message>();
            this.Messages2 = new List<Message>();
        }
        public int ID { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(50)]
        public string Surname { get; set; }
        [MaxLength(250)]
        public string Password { get; set; }
        [StringLength(11)]
        public string Telno { get; set; }
        [MaxLength(50)]
        public string Email { get; set; }
        [MaxLength(50)]
        public string Nick { get; set; }
        [MaxLength(250)]
        public string ProfilePicture { get; set; }
        [MaxLength(250)]
        public string BannerPicture { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool isActive { get; set; }
        public bool  isVerified { get; set; }
        public bool isOnline { get; set; }
        public virtual ICollection<UserRelation> UserRelations1 { get; set; } 
        public virtual ICollection<UserRelation> UserRelations2  { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<Like> Likes { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Message> Messages1 { get; set; }
        public virtual ICollection<Message> Messages2 { get; set; }


    }
}

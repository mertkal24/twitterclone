using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Twitter.DATA.Entities.Context
{
   public  class TwitterContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=DESKTOP-5E1JL7B; initial catalog=TwitDb; integrated security = true;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserRelation>().HasKey(x => new { x.SenderID, x.RecipientID });
            modelBuilder.Entity<UserRelation>().HasOne(x => x.User).WithMany(x => x.UserRelations1).HasForeignKey(x => x.SenderID).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<UserRelation>().HasOne(x => x.User1).WithMany(x => x.UserRelations2).HasForeignKey(x => x.RecipientID).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Message>().HasOne(x => x.Sender).WithMany(x => x.Messages1).HasForeignKey(x => x.SenderID).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Message>().HasOne(x => x.Recipient).WithMany(x => x.Messages2).HasForeignKey(x => x.RecipientID).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Comment>().HasOne(x => x.User).WithMany(x => x.Comments).HasForeignKey(x => x.UserID).OnDelete(DeleteBehavior.NoAction);
        }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRelation> UserRelations { get; set; }
        public DbSet<Like> Likes{ get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<MessageRelation> MessageRelations { get; set; }


    }
}

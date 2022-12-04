using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Twitter.DATA.Entities;
using Twitter.DATA.Entities.Context;
using Twitter.DATA.Repos.Abstract;
using Twitter.DATA.Repos.Concrete.Base;

namespace Twitter.DATA.Repos.Concrete
{
    public class CommentRepository:Repository<Comment>,ICommentRepository
    {
        private TwitterContext twitContext;
        public CommentRepository(TwitterContext context):base(context)
        {
            twitContext = context;
        }

        public void AddCommentForPost(int userId, string commentContent, int PostId)
        {
            Comment comment = new Comment()
            {
                PostID =PostId,
                CreatedDate=DateTime.Now,
                CommentContent=commentContent,
                UserID=userId
             };
            twitContext.Comments.Add(comment);
        }

        public List<Comment> getCommentsByPostID(int postId)
        {
            return twitContext.Comments.Where(x => x.PostID == postId).ToList();
        }
    }
}

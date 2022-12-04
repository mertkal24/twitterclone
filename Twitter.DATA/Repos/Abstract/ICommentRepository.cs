using System;
using System.Collections.Generic;
using System.Text;
using Twitter.DATA.Entities;
using Twitter.DATA.Repos.Base;

namespace Twitter.DATA.Repos.Abstract
{
    public interface ICommentRepository:IRepository<Comment>
    {
        List<Comment> getCommentsByPostID(int postId);
        void AddCommentForPost(int userId , string commentContent,int PostId);
    }
}

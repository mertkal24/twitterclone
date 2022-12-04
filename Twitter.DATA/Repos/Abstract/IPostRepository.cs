using System;
using System.Collections.Generic;
using System.Text;
using Twitter.DATA.Entities;
using Twitter.DATA.Repos.Base;

namespace Twitter.DATA.Repos.Abstract.Base
{
    public interface IPostRepository: IRepository<Post>
    {
        List<Post> GetAllUserPostByUserID(int userId);
        void Tweetle(Post post);
    }
}

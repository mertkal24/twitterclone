using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Twitter.DATA.Entities;
using Twitter.DATA.Entities.Context;
using Twitter.DATA.Repos.Abstract.Base;
using Twitter.DATA.Repos.Concrete.Base;

namespace Twitter.DATA.Repos.Concrete
{
    public class PostRepository:Repository<Post>, IPostRepository
    {
        private TwitterContext twitContext;
        public PostRepository(TwitterContext context) : base(context)
        {
            twitContext = context;
        }

        public List<Post> GetAllUserPostByUserID(int userId)
        {
            return twitContext.Posts.Where(x => x.UserID == userId).ToList();
        }

        public void Tweetle(Post post)
        {
            twitContext.Posts.Add(post);
        }
    }
}

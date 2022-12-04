using System;
using System.Collections.Generic;
using System.Text;
using Twitter.DATA.Entities.Context;
using Twitter.DATA.Repos.Abstract;
using Twitter.DATA.Repos.Abstract.Base;
using Twitter.DATA.Repos.Concrete;

namespace Twitter.DATA.UnitOfWork
{
   
    public class UnitOfWorkTwitter : IUnitOfWork
    {
        private TwitterContext twitterContext;
        public UnitOfWorkTwitter(TwitterContext context)
        {
            twitterContext = context;
            this.userRepo = new UserRepository(context);
            this.postRepo = new PostRepository(context);
            this.likeRepo = new LikeRepository(context);
            this.messageRepo = new MessageRepository(context);
            this.userRelationRepo = new RelationOfUserRepository(context);
            this.commentRepo = new CommentRepository(context);
            this.messageRelationRepo = new MessageRelationRepository(context);
        }

        public IUserRepository userRepo { get; }
        public IPostRepository postRepo { get; }
        public ILikeRepository likeRepo { get; }
        public ICommentRepository commentRepo { get; }
        public IMessageRepository messageRepo { get; }
        public IRelationOfUserRepository userRelationRepo { get; }
        public IMessageRelationRepository messageRelationRepo { get; }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void SaveAllChanges()
        {
            twitterContext.SaveChanges();
        }
    }
}

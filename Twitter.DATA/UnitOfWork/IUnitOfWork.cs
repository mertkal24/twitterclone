using System;
using System.Collections.Generic;
using System.Text;
using Twitter.DATA.Repos.Abstract;
using Twitter.DATA.Repos.Abstract.Base;

namespace Twitter.DATA.UnitOfWork
{
    public interface IUnitOfWork:IDisposable
    {
        IUserRepository userRepo { get; }
        
        IPostRepository postRepo { get; }
        
        ILikeRepository likeRepo { get; }
        ICommentRepository commentRepo { get; }
        IMessageRepository messageRepo { get; }
        IRelationOfUserRepository userRelationRepo { get; }

        void SaveAllChanges();
    }
}

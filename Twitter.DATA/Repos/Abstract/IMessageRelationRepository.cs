using System;
using System.Collections.Generic;
using System.Text;
using Twitter.DATA.Entities;
using Twitter.DATA.Repos.Base;

namespace Twitter.DATA.Repos.Abstract
{
    public interface IMessageRelationRepository:IRepository<MessageRelation>
    {
        void InsertRelation(int senderId, int userId);
        void Update(int senderId, int userId);
        bool isActive(int senderId, int userId);
    }
}

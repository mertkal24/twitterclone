using System;
using System.Collections.Generic;
using System.Text;
using Twitter.DATA.Entities.Context;
using Twitter.DATA.UnitOfWork;

namespace Twitter.CORE.Services
{
    public class MessageService
    {
        UnitOfWorkTwitter unitOfWork = new UnitOfWorkTwitter(new TwitterContext());
        public void InsertRelation(int senderId, int userId)
        {
            unitOfWork.messageRelationRepo.InsertRelation(senderId, userId);
        }
        public void Update(int sender, int userId)
        {

        }
        public bool isActive(int sender , int userId)
        {
            return false;
        }
    }
}

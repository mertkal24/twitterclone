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
    public class MessageRelationRepository:Repository<MessageRelation>,IMessageRelationRepository
    {
        private TwitterContext twitContext;
        public MessageRelationRepository(TwitterContext context) : base(context)
        {
            twitContext = context;
        }

        public void InsertRelation(int senderId, int userId)
        {
            MessageRelation relation = new MessageRelation()
            {
                SenderUserID = senderId,
                UserID=userId,
                IsContinue=true     
            };
            twitContext.MessageRelations.Add(relation);
        }

        public bool isActive(int senderId, int userId)
        {
            throw new NotImplementedException();
        }

        public void Update(int senderId, int userId)
        {
            twitContext.MessageRelations.Where(x => x.SenderUserID == senderId && x.UserID == userId).FirstOrDefault().IsContinue = false;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Twitter.DATA.Entities;
using Twitter.DATA.Entities.Context;
using Twitter.DATA.Repos.Abstract;
using Twitter.DATA.Repos.Concrete.Base;

namespace Twitter.DATA.Repos.Concrete
{
    public class MessageRepository:Repository<Message>,IMessageRepository
    {
        private TwitterContext twitContext;
        public MessageRepository(TwitterContext context) : base(context)
        {
            twitContext = context;
        }
    }
}

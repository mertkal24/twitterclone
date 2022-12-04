using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Twitter.DATA.Entities;
using Twitter.DATA.Entities.Context;
using Twitter.DATA.Repos.Abstract;
using Twitter.DATA.Repos.Base;
using Twitter.DATA.Repos.Concrete.Base;

namespace Twitter.DATA.Repos.Concrete
{
     public class UserRepository:Repository<User>, IUserRepository
    {
        private TwitterContext twitContext;
        public UserRepository(TwitterContext context) : base(context)
        {
            twitContext = context;
        }

        public bool FindByEmail(string email)
        {
            return twitContext.Users.Any(x => x.Email == email);
        }

        public List<User> Get5User()
        {
            return twitContext.Users.OrderByDescending(x => x.CreatedDate).Take(10).ToList();
        }

        public User GetUserByEmail(string email)
        {
            User user = twitContext.Users.Where(x=>x.Email==email).FirstOrDefault();
            return user;
        }

        public User GetUserByID(int id)
        {
            User user = twitContext.Users.Where(x => x.ID == id).FirstOrDefault();
            return user;
        }

        public List<int> GetUserBySearchedText(string text)
        {
           
           
            return twitContext.Users.Where(x => x.Name.Contains(text) || x.Surname.Contains(text)).Select(x => x.ID).ToList();
        }

        public int GetUserIdByEmail(string email)
        {
            int userId = twitContext.Users.Where(x => x.Email == email).FirstOrDefault().ID;
            return userId;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Twitter.DATA.Entities;
using Twitter.DATA.Repos.Base;

namespace Twitter.DATA.Repos.Abstract
{
    public interface IUserRepository:IRepository<User>
    {
        User GetUserByEmail(string email);
        int GetUserIdByEmail(string email);
        bool FindByEmail(string email);
        List<User> Get5User();
        User GetUserByID(int id);
        List<int> GetUserBySearchedText(string text);
    }
}

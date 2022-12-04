using System;
using System.Collections.Generic;
using System.Text;
using Twitter.DATA.Entities;
using Twitter.DATA.Repos.Base;

namespace Twitter.DATA.Repos.Abstract
{
    public interface IRelationOfUserRepository:IRepository<UserRelation>
    {
        void AddFriend(int senderId, int receiverId);
        bool CheckRelation(int senderId, int receiverId);
        List<UserRelation> GetUserRelationByID(int id);
        List<int> getUserRequestId(int id);
        void AcceptRequest(int senderId, int receiverId);
        void RemoveFriend(int senderId, int receiverId);
        bool isFriend(int authorizeUserId, int userId);
        
    }
}

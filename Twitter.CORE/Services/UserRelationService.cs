using System;
using System.Collections.Generic;
using System.Text;
using Twitter.CORE.Common;
using Twitter.DATA.Entities;
using Twitter.DATA.Entities.Context;
using Twitter.DATA.UnitOfWork;

namespace Twitter.CORE.Services
{
    public class UserRelationService
    {
        UnitOfWorkTwitter unitOfWork = new UnitOfWorkTwitter(new TwitterContext());
        public void SendFriendRequest(int senderId , int receiverId)
        {
            unitOfWork.userRelationRepo.AddFriend(senderId, receiverId);
            unitOfWork.SaveAllChanges();
        }
        public List<UserDTO> getFriends(int id)
        {
            List<User> friends = new List<User>();
            List<UserDTO> friendsDto = new List<UserDTO>();
            List<UserRelation> userAllRelation = unitOfWork.userRelationRepo.GetUserRelationByID(id);
            foreach (UserRelation item in userAllRelation)
            {
                if (item.isAccepted)
                {
                    if (item.SenderID != id)
                    {
                        friends.Add(unitOfWork.userRepo.GetUserByID(item.SenderID));
                    }
                    if (item.RecipientID != id)
                    {
                        friends.Add(unitOfWork.userRepo.GetUserByID(item.RecipientID));
                    }
                }
            }
            foreach (User usr in friends)
            {
                UserDTO friend = new UserDTO()
                {
                  ID=usr.ID,
                  Name=usr.Name,
                  Surname=usr.Surname,
                  BannerPicture=usr.BannerPicture,
                  BirthDate=usr.BirthDate,
                  CreatedDate=usr.CreatedDate,
                  Email=usr.Email,
                  Password=usr.Password,
                  isActive=usr.isActive,
                  isOnline=usr.isOnline,
                  Nick=usr.Nick,
                  ProfilePicture=usr.ProfilePicture,
                  Telno=usr.Telno
                };
                
                friendsDto.Add(friend);
            }
            return friendsDto;
        }
        public List<UserDTO> getRequestList(int id)
        {
            List<UserDTO> requestList = new List<UserDTO>();
            foreach(var item in unitOfWork.userRelationRepo.getUserRequestId(id))
            {
                UserDTO requestUser = new UserDTO()
                {
                    ID = unitOfWork.userRepo.GetUserByID(item).ID,
                    Name = unitOfWork.userRepo.GetUserByID(item).Name,
                    Surname = unitOfWork.userRepo.GetUserByID(item).Surname,
                    BannerPicture = unitOfWork.userRepo.GetUserByID(item).BannerPicture,
                    ProfilePicture = unitOfWork.userRepo.GetUserByID(item).ProfilePicture,
                    BirthDate = unitOfWork.userRepo.GetUserByID(item).BirthDate,
                    CreatedDate = unitOfWork.userRepo.GetUserByID(item).CreatedDate,
                    Email = unitOfWork.userRepo.GetUserByID(item).Email,
                    isActive = unitOfWork.userRepo.GetUserByID(item).isActive,
                    isOnline = unitOfWork.userRepo.GetUserByID(item).isOnline,
                    isVerified = unitOfWork.userRepo.GetUserByID(item).isVerified,
                    Nick = unitOfWork.userRepo.GetUserByID(item).Nick,
                    Password = unitOfWork.userRepo.GetUserByID(item).Password,
                    Telno = unitOfWork.userRepo.GetUserByID(item).Telno
                };
                requestList.Add(requestUser);
            }
            return requestList;
        }
        public void AcceptFriend(int senderId , int receiverId)
        {
            unitOfWork.userRelationRepo.AcceptRequest(senderId, receiverId);
            unitOfWork.SaveAllChanges();
        }
        public void RemoveFriend(int senderId , int receiverId)
        {
            unitOfWork.userRelationRepo.RemoveFriend(senderId, receiverId);
            unitOfWork.SaveAllChanges();
        }
        public bool isFriend(int userId , int id)
        {
            return unitOfWork.userRelationRepo.isFriend(userId, id);
        }
    }
}

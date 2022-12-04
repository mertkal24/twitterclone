using System;
using System.Collections.Generic;
using System.Text;
using Twitter.CORE.Common;
using Twitter.DATA.Entities;
using Twitter.DATA.Entities.Context;
using Twitter.DATA.UnitOfWork;

namespace Twitter.CORE.Services
{
   public class UserService
    {
        UnitOfWorkTwitter uow = new UnitOfWorkTwitter(new TwitterContext());
        public int getUserIdByEmail(string email)
        {
          return uow.userRepo.GetUserByEmail(email).ID;
        }
        public bool AuthenticationControl(UserLoginDTO user)
        {
            User istekAtanUser = new User();
            istekAtanUser = uow.userRepo.GetUserByEmail(user.Email);
            if (uow.userRepo.FindByEmail(user.Email))
            {
                if (user.Email == istekAtanUser.Email && user.Password == istekAtanUser.Password) return true;
                else return false;
            }
            else return false; 
        }
        public List<UserDTO> Get5User(int userId)
        {
            List<UserDTO> lastFiveUser = new List<UserDTO>();
            foreach(var item in uow.userRepo.Get5User())
            {
                //son eklenen kullanıcılarda ben çıkarsam ekleme
                if (userId != item.ID)
                {
                    //hem benım ıstek attıklarım gozukmesın hemde bana istek atanlar..
                    if (uow.userRelationRepo.CheckRelation(userId, item.ID))
                    {
                        UserDTO user = new UserDTO()
                        {
                            ID = item.ID,
                            Name = item.Name,
                            Surname = item.Surname,
                            ProfilePicture = item.ProfilePicture,
                        };
                        lastFiveUser.Add(user);
                    }
                } 
            }
            return lastFiveUser;
        }
        public UserDTO GetUserByID(int id)
        {
            User user = uow.userRepo.GetUserByID(id);
            if (user == null)
            {
                UserDTO noUser = new UserDTO();
                return noUser;
            }
            UserDTO userInfo = new UserDTO()
            {
                ID = user.ID,
                BannerPicture=user.BannerPicture,
                Name=user.Name,
                Surname=user.Surname,
                BirthDate=user.BirthDate,
                CreatedDate=user.CreatedDate,
                Email=user.Email,
                isActive=user.isActive,
                isOnline=user.isOnline,
                isVerified=user.isVerified,
                Nick=user.Nick,
                Password=user.Password,
                ProfilePicture=user.ProfilePicture,
                Telno=user.Telno
            };
            return userInfo;
        }
        public List<UserDTO> GetUserBySearchedText(string text)
        {

            List<UserDTO> searchedUserList = new List<UserDTO>();
          foreach(int userID in uow.userRepo.GetUserBySearchedText(text))
            {

                UserDTO user = GetUserByID(userID);
                searchedUserList.Add(user);



            }
            return searchedUserList;
        }
       
    }
}

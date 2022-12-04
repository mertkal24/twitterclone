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
     public class RelationOfUserRepository:Repository<UserRelation>,IRelationOfUserRepository
    {
        private TwitterContext twitContenx;
        public RelationOfUserRepository(TwitterContext context):base(context)
        {
            twitContenx = context;
        }

        public void AcceptRequest(int senderId, int receiverId)
        {
            twitContenx.UserRelations.Where(x => x.isAccepted == false).Where(x => x.isActive == true).Where(x => x.SenderID == senderId).Where(x => x.RecipientID == receiverId).FirstOrDefault().isAccepted=true;
        }

        public void AddFriend(int senderId, int receiverId)
        {
            UserRelation newUserRealetion = new UserRelation()
            {
                SenderID = senderId,
                RecipientID=receiverId
            };
            //daha once sender olup actiflik durumu false olan durum varmı dıye kontrol edıyorum
            if(twitContenx.UserRelations.Where(x=>x.isActive==false).Any(x=>x.SenderID==senderId && x.RecipientID == receiverId))
            {
                twitContenx.UserRelations.Where(x => x.isActive == false).Where(x => x.SenderID == senderId && x.RecipientID == receiverId).FirstOrDefault().isAccepted = false;
                twitContenx.UserRelations.Where(x => x.isActive == false).Where(x => x.SenderID == senderId && x.RecipientID == receiverId).FirstOrDefault().isActive = true;
            }
            else
            {
                twitContenx.UserRelations.Add(newUserRealetion);
            }
            
            
        }

        public bool CheckRelation(int senderId, int receiverId)
        {
            bool solControl = twitContenx.UserRelations.Any(x => x.SenderID == senderId && x.RecipientID == receiverId);
            bool sagControl = twitContenx.UserRelations.Where(x => x.isActive == true).Any(x => x.SenderID == receiverId && x.RecipientID == senderId);

            if (sagControl && !solControl)
            {
                UserRelation relationSag = twitContenx.UserRelations.Where(x => x.SenderID == receiverId && x.RecipientID == senderId).FirstOrDefault();
                if (!relationSag.isAccepted && !relationSag.isActive)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (!sagControl && solControl)
            {
                UserRelation relationSol = twitContenx.UserRelations.Where(x => x.SenderID == senderId && x.RecipientID == receiverId).FirstOrDefault();
                if(!relationSol.isAccepted && !relationSol.isActive)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if(!sagControl && !solControl)
            {
                return true;
            }
            else if(sagControl && solControl)
            {
                UserRelation relationSag = twitContenx.UserRelations.Where(x => x.SenderID == receiverId && x.RecipientID == senderId).FirstOrDefault();
                UserRelation relationSol = twitContenx.UserRelations.Where(x => x.SenderID == senderId && x.RecipientID == receiverId).FirstOrDefault();
                if(!relationSol.isActive && !relationSol.isAccepted)
                {
                    return true;
                }
                else if (!relationSag.isActive && !relationSag.isAccepted)
                {
                    return true;
                }
                else
                {
                    return false;
                }  
            }
            else
            {
                return true;
            }

            //if (solControl)
            //{
            //    if(twitContenx.UserRelations.Where(x => x.SenderID == senderId && x.RecipientID == receiverId).FirstOrDefault().isActive && twitContenx.UserRelations.Where(x => x.SenderID == senderId && x.RecipientID == receiverId).FirstOrDefault().isAccepted == false)
            //    {
            //        return false;
            //    }
            //    else if (!twitContenx.UserRelations.Where(x => x.SenderID == senderId && x.RecipientID == receiverId).FirstOrDefault().isActive && twitContenx.UserRelations.Where(x => x.SenderID == senderId && x.RecipientID == receiverId).FirstOrDefault().isAccepted == false)
            //    {
            //        return true;
            //    }
            //    else
            //    {
            //        return false;
                    
            //    }
                
            //}
            //else if(sagControl)
            //{
            //    if (twitContenx.UserRelations.Where(x => x.SenderID == receiverId && x.RecipientID == senderId).FirstOrDefault().isActive && twitContenx.UserRelations.Where(x => x.SenderID == receiverId && x.RecipientID == senderId).FirstOrDefault().isAccepted==false)
            //    {
            //        return false;
            //    }
            //    else if(!twitContenx.UserRelations.Where(x => x.SenderID == receiverId && x.RecipientID == senderId).FirstOrDefault().isActive && twitContenx.UserRelations.Where(x => x.SenderID == receiverId && x.RecipientID == senderId).FirstOrDefault().isAccepted == false)
            //    {
            //        return true;
            //    }
            //    else
            //    {
            //        return false;
            //    }
            //}
            //else
            //{
            //    return true;
            //}  
        }

       
        public List<UserRelation> GetUserRelationByID(int id)
        {
            return twitContenx.UserRelations.Where(x => x.SenderID == id || x.RecipientID == id).ToList(); ;
        }

        public List<int> getUserRequestId(int id)
        {
            List<int> userId = new List<int>();
            foreach(var item in twitContenx.UserRelations.Where(x => x.RecipientID == id).ToList())
            {
                if (!item.isAccepted && item.isActive)
                {
                    userId.Add(item.SenderID);
                }
            }
            return userId;
        }

        public bool isFriend(int authorizeUserId, int userId)
        {
            if(twitContenx.UserRelations.Where(x=>x.isActive==true && x.isAccepted==true).Any(x=>x.SenderID==authorizeUserId && x.RecipientID == userId))
            {
                return true;
            }
            else if(twitContenx.UserRelations.Where(x => x.isActive == true && x.isAccepted == true).Any(x => x.SenderID == userId && x.RecipientID == authorizeUserId))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void RemoveFriend(int senderId, int receiverId)
        {
            UserRelation newUserRealetion = new UserRelation()
            {
                SenderID = senderId,
                RecipientID = receiverId
            };
            bool control = twitContenx.UserRelations.Where(x=>x.isActive==true).Any(x => x.SenderID == senderId && x.RecipientID == receiverId); ;
           if (control)
            {
                if(twitContenx.UserRelations.Where(x => x.SenderID == senderId && x.RecipientID == receiverId).FirstOrDefault().isAccepted && twitContenx.UserRelations.Where(x => x.SenderID == senderId && x.RecipientID == receiverId).FirstOrDefault().isActive)
                {
                    twitContenx.UserRelations.Where(x => x.SenderID == senderId && x.RecipientID == receiverId).FirstOrDefault().isAccepted = false;
                    twitContenx.UserRelations.Where(x => x.SenderID == senderId && x.RecipientID == receiverId).FirstOrDefault().isActive = false;
                }
            }
            bool control2= twitContenx.UserRelations.Where(x=>x.isActive==true).Any(x => x.SenderID == receiverId && x.RecipientID == senderId);
            if (control2)
            {
                if (twitContenx.UserRelations.Where(x => x.SenderID == receiverId && x.RecipientID == senderId).FirstOrDefault().isAccepted && twitContenx.UserRelations.Where(x => x.SenderID == receiverId && x.RecipientID == senderId).FirstOrDefault().isActive)
                {
                    twitContenx.UserRelations.Where(x => x.SenderID == receiverId && x.RecipientID == senderId).FirstOrDefault().isAccepted = false;
                    twitContenx.UserRelations.Where(x => x.SenderID == receiverId && x.RecipientID == senderId).FirstOrDefault().isActive = false;
                }
            }
        }
    }
}

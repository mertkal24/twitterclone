using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Twitter.CORE.Common;
using Twitter.DATA.Entities.Context;
using Twitter.DATA.UnitOfWork;

namespace Twitter.CORE.Services
{
    public  class CommentService
    {
        UnitOfWorkTwitter unitOfWork = new UnitOfWorkTwitter(new TwitterContext());
        public List<CommentDTO> getAllCommentForPostId(int postId)
        {
            List<CommentDTO> comments = new List<CommentDTO>();
            foreach(var item in unitOfWork.commentRepo.getCommentsByPostID(postId))
            {
                UserService userS = new UserService();
                UserDTO user = userS.GetUserByID(item.UserID);
                CommentDTO dtoComment = new CommentDTO()
                {
                    ID = item.ID,
                    CommentContent = item.CommentContent,
                    CreatedDate = item.CreatedDate,
                    ParentCommentID = item.ParentCommentID,
                    PostID = item.PostID,
                    UserID = item.UserID,
                    UserProfilePicture = user.ProfilePicture,
                    UserNameSurname = user.Name + " " + user.Surname
                 
                };
                comments.Add(dtoComment);
            }
            return comments.OrderByDescending(x=>x.CreatedDate).ToList();
        }
        public void AddComment(int yorumYapanUserId,string commentBody,int postId)
        {
            unitOfWork.commentRepo.AddCommentForPost(yorumYapanUserId, commentBody, postId);
            unitOfWork.SaveAllChanges();
        }

    }
}

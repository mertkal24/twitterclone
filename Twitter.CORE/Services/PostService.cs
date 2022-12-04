using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Twitter.CORE.Common;
using Twitter.DATA.Entities;
using Twitter.DATA.Entities.Context;
using Twitter.DATA.Repos;
using Twitter.DATA.Repos.Concrete;
using Twitter.DATA.UnitOfWork;

namespace Twitter.CORE.Services
{
    public class PostService
    {
        UnitOfWorkTwitter unitofWork = new UnitOfWorkTwitter(new TwitterContext());

        public List<PostDTO> GetUserPostByUserID(int userID)
        {
            List<PostDTO> kullanicninPostlari = new List<PostDTO>();
           foreach(Post post in unitofWork.postRepo.GetAllUserPostByUserID(userID))
            {
                CommentService cservice = new CommentService();
                CommentDTO cdto = new CommentDTO();
                PostDTO addPostItem = new PostDTO() 
                {
                    CreatedDate=post.CreatedDate,
                    Image=post.Image,
                    PostContent=post.PostContent,
                    UserID=post.UserID,
                    postComments= cservice.getAllCommentForPostId(post.ID)
                };
                kullanicninPostlari.Add(addPostItem);
            }
            return kullanicninPostlari;
        }
        public void TweetAt(PostDTO newPostDTO)
        {
            Post newPost = new Post()
            {
                UserID=newPostDTO.UserID,
                CreatedDate=DateTime.Now,
                Image=newPostDTO.Image,
                PostContent=newPostDTO.PostContent
            };
            unitofWork.postRepo.Tweetle(newPost);
            unitofWork.SaveAllChanges();
        }

        public List<PostDTO> GetFriendsPosts(List<UserDTO> friends,UserDTO user)
        {

            List<PostDTO> pageFriendPosts = new List<PostDTO>();
            foreach(var item in unitofWork.postRepo.GetAllUserPostByUserID(user.ID))
            {
                CommentService cs = new CommentService();
                PostDTO dtoPost = new PostDTO()
                {
                    ID = item.ID,
                    UserID = item.UserID,
                    CreatedDate = item.CreatedDate,
                    Image = item.Image,
                    PostContent = item.PostContent,
                    UserSurname = user.Surname,
                    UserName = user.Name,
                    UserProfilePicture = user.ProfilePicture,
                    postComments = cs.getAllCommentForPostId(item.ID)
                    
                };
                pageFriendPosts.Add(dtoPost);

            }
            foreach(UserDTO friendUser in friends)
            {
                foreach(Post post in unitofWork.postRepo.GetAllUserPostByUserID(friendUser.ID))
                {
                    CommentService cs = new CommentService();
                    PostDTO dtoPost = new PostDTO()
                    {
                        ID = post.ID,
                        CreatedDate = post.CreatedDate,
                        Image = post.Image,
                        PostContent = post.PostContent,
                        UserID = post.UserID,
                        UserName = friendUser.Name,
                        UserProfilePicture = friendUser.ProfilePicture,
                        UserSurname = friendUser.Surname,
                        postComments = cs.getAllCommentForPostId(post.ID)
                        
                   };
                    pageFriendPosts.Add(dtoPost);
                }
            }
            
            return pageFriendPosts.OrderByDescending(x=>x.CreatedDate).ToList();

        }
    }
}

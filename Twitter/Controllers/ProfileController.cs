using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Twitter.CORE.Common;
using Twitter.CORE.Services;
using Twitter.Models;

namespace Twitter.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        public IActionResult Index()
        {
            
            int id = int.Parse(User.Claims.Where(x => x.Type == ClaimTypes.Name).Select(x => x.Value).FirstOrDefault());
            ViewBag.pageTitle = "Profil";
                UserRelationService relationService = new UserRelationService();
                UserService userService = new UserService();
                PostService postService = new PostService();
                MainPageModel pageModel = new MainPageModel();
                pageModel.User = userService.GetUserByID(id);
                pageModel.UserPosts = postService.GetUserPostByUserID(id);
                pageModel.UserRelationProposal = userService.Get5User(id);
                pageModel.UserFriends = relationService.getFriends(id);
                pageModel.UserRequestList =relationService.getRequestList(id);
                return View(pageModel);
  
        }
        public IActionResult UserProfile(int id)
        {
            UserRelationService relationService = new UserRelationService();
            UserService userService = new UserService();
            PostService postService = new PostService();
            MainPageModel pageModel = new MainPageModel();
            int Userid = int.Parse(User.Claims.Where(x => x.Type == ClaimTypes.Name).Select(x => x.Value).FirstOrDefault());
            ViewBag.pageTitle = userService.GetUserByID(id).Name +" "+userService.GetUserByID(id).Surname;
            pageModel.isFriend = relationService.isFriend(Userid, id);
            pageModel.User = userService.GetUserByID(id);
            pageModel.UserPosts = postService.GetUserPostByUserID(id);
            pageModel.UserRelationProposal = userService.Get5User(Userid);
            pageModel.UserFriends = relationService.getFriends(id);
            pageModel.UserRequestList = new List<UserDTO>();
            return View(pageModel);
        }
        

    }
}

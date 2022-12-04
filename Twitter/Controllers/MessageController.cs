using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Twitter.CORE.Services;
using Twitter.Models;

namespace Twitter.Controllers
{
    public class MessageController : Controller
    {
       
        public IActionResult Index()
        {
            int id = int.Parse(User.Claims.Where(x => x.Type == ClaimTypes.Name).Select(x => x.Value).SingleOrDefault());
            UserRelationService relationService = new UserRelationService();
            UserService userService = new UserService();
            PostService postService = new PostService();
            MainPageModel pageModel = new MainPageModel();
            pageModel.User = userService.GetUserByID(id);
            pageModel.UserFriends = relationService.getFriends(id);
            return View(pageModel);
        }
       
    }
}

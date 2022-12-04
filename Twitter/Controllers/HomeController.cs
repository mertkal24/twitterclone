using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Twitter.CORE.Common;
using Twitter.CORE.Services;
using Twitter.Models;

namespace Twitter.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewBag.pageTitle = "Anasayfa";
            int id = int.Parse(User.Claims.Where(x => x.Type == ClaimTypes.Name).Select(x => x.Value).FirstOrDefault());
            UserRelationService relService = new UserRelationService();
            PostService postService = new PostService();
            UserService userService = new UserService();
            MainPageModel pageModel = new MainPageModel();
            pageModel.User = userService.GetUserByID(id);
             List<PostDTO> allPost = new List<PostDTO>();
            UserDTO user = userService.GetUserByID(id);
            pageModel.usersFriendsPost = postService.GetFriendsPosts(relService.getFriends(id),user);
            pageModel.UserRelationProposal = userService.Get5User(id);
            return View(pageModel);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

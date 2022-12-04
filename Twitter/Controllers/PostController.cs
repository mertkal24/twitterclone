using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Twitter.CORE.Common;
using Twitter.CORE.Services;

namespace Twitter.Controllers
{
    public class PostController : Controller
    {
        public IActionResult PostAt(string postContent)
        {
            PostService postService = new PostService();
            int id = int.Parse(User.Claims.Where(x => x.Type == ClaimTypes.Name).Select(x => x.Value).FirstOrDefault());
            PostDTO newPost = new PostDTO()
            {
                Image = "Yok",
                PostContent = postContent,
                UserID = id
            };
            postService.TweetAt(newPost);
            return Json(Url.Action("Index","Home"));
        }
    }
}

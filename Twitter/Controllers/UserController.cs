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
    public class UserController : Controller
    {
        public IActionResult SendFriendRequest(int istekGonderilecekUserId)
        {
            UserRelationService userRelation = new UserRelationService();
            int id = int.Parse(User.Claims.Where(x => x.Type == ClaimTypes.Name).Select(x => x.Value).FirstOrDefault());
            userRelation.SendFriendRequest(id, istekGonderilecekUserId);
            return Json("Arkadaş İsteği Gönderildi");
        }
        public IActionResult AcceptFriend(int id)
        {
            int idUser = int.Parse(User.Claims.Where(x => x.Type == ClaimTypes.Name).Select(x => x.Value).FirstOrDefault());
            UserRelationService userRelation = new UserRelationService();
            userRelation.AcceptFriend(id,idUser);
            return Json(Url.Action("Index","Profile"));
        }
        public IActionResult DeleteFriend(int id)
        {
            int idUser = int.Parse(User.Claims.Where(x => x.Type == ClaimTypes.Name).Select(x => x.Value).FirstOrDefault());
            UserRelationService userRelation = new UserRelationService();
            userRelation.RemoveFriend(idUser, id);
            return Json(Url.Action("Index", "Profile"));
        }
        public JsonResult YorumAt(string content, int id)
        {
            CommentService commentService = new CommentService();
            int idUser = int.Parse(User.Claims.Where(x => x.Type == ClaimTypes.Name).Select(x => x.Value).FirstOrDefault());
            commentService.AddComment(idUser, content, id);
            return Json("1");
        }
        public JsonResult GetUserBySearchText(string text)
        {
            UserService userService = new UserService();
            List<UserDTO> serchedUserList = userService.GetUserBySearchedText(text);
            return Json(serchedUserList.Take(5).ToList());
        }
    }
}

using Microsoft.AspNetCore.Authentication;
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
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public  async Task<IActionResult> Index(UserLoginDTO user)
        {
            UserService userService = new UserService();
            if (userService.AuthenticationControl(user))
            {
                int UserId = userService.getUserIdByEmail(user.Email);
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email,user.Email),
                    new Claim(ClaimTypes.Name,UserId.ToString())
                };
                var cid = new ClaimsIdentity(claims, "Login");
                ClaimsPrincipal principal = new ClaimsPrincipal(cid);
                await HttpContext.SignInAsync(principal);

                return Json(Url.Action("Index", "Home"));
            }
            else
            {
                return Json("1");
            }
            
        }
        public async Task<JsonResult> LogOut()
        {
            await HttpContext.SignOutAsync();
            return Json(Url.Action("Index", "Login"));
        }
    }
}

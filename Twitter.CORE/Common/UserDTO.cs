using System;
using System.Collections.Generic;
using System.Text;

namespace Twitter.CORE.Common
{
   public class UserDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Telno { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Nick { get; set; }
        public string ProfilePicture { get; set; }
        public string BannerPicture { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public bool isActive { get; set; }
        public bool isVerified { get; set; }
        public bool isOnline { get; set; }
    }
}

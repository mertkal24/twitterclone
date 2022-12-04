using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Twitter.CORE.Common;

namespace Twitter.Models
{
    public class MainPageModel
    {
        public MainPageModel()
        {
           
        }
        public IEnumerable<PostDTO> UserRelationsPosts { get; set; }
        public IEnumerable<UserDTO> UserRelationProposal { get; set; }
        public  PostDTO UserNewPost { get; set; }
        public UserDTO User  { get; set; }
        public IEnumerable<PostDTO> usersFriendsPost { get; set; }
        public IEnumerable<PostDTO> UserPosts { get; set; }
        public IEnumerable<UserDTO> UserFriends { get; set; }
        public IEnumerable<UserDTO> UserRequestList { get; set; }
        public bool isFriend { get; set; }

    }
}

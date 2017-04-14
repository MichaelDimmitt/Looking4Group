using System;
using System.Collections.Generic;

namespace Looking4Group.Models
{
    public class User
    {
        public int UserID { get; set; }
        public String Username { get; set; }
        public String Password { get; set; }
        public String PasswordSalt { get; set; }
        public String Email { get; set; }

        public ICollection<UserTag> UserTags { get; set; }
    }
}
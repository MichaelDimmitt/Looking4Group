using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Looking4Group.Models
{
    public class User
    {
        public int UserID { get; set; }
        public String PasswordSalt { get; set; }

        [Required(ErrorMessage = "Required")]
        public String Username { get; set; }

        [Required(ErrorMessage = "Required")]
        public String Password { get; set; }

        [Required(ErrorMessage = "Required")]
        public String Email { get; set; }

        public ICollection<UserTag> UserTags { get; set; }
    }
}
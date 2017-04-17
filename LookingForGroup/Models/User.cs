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
        [StringLength(32, ErrorMessage = "Max size: 32")]
        public String Username { get; set; }

        [Required(ErrorMessage = "Required")]
        [StringLength(1024, ErrorMessage = "Max size: 1024")]
        public String Password { get; set; }

        [Required(ErrorMessage = "Required")]
        [DataType(DataType.EmailAddress, ErrorMessage ="Please enter a valid email!")]
        [StringLength(32, ErrorMessage = "Max size: 32")]
        public String Email { get; set; }

        public ICollection<UserTag> UserTags { get; set; }


    }
}
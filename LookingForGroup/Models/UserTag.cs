using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Looking4Group.Models
{
    public class UserTag
    {
        [Key]
        public int TagID { get; set; }
        public int UserID { get; set; }
        public String Label { get; set; }
        public int Weight { get; set; }

        public User User { get; set; }
    }
}

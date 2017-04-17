using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Looking4Group.Models
{
    public class UserTag
    {
        [Key]
        public int TagID { get; set; }
        public int UserID { get; set; }

        [StringLength(15, ErrorMessage = "Max size: 15")]
        public String Label { get; set; }
        public int Weight { get; set; }

        [ForeignKey("UserID")]
        public User User { get; set; }
    }
}

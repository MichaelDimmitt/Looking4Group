using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Looking4Group.Models
{
    public class Post
    {
        public int PostID { get; set; }
        public int UserID { get; set; }
        public int DiscussionID { get; set; }

        public String Content { get; set; }
        public DateTime DateTime { get; set; }

        [ForeignKey("DiscussionID")]
        public Discussion Discussion { get; set; }

        [ForeignKey("UserID")]
        public User User { get; set; }
    }
}

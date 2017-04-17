using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Looking4Group.Models
{
    public class Discussion
    {
        public int DiscussionID { get; set; }
        public int ForumID { get; set; }

        public String Title { get; set; }

        [ForeignKey("ForumID")]
        public Forum Forum { get; set; }
        public ICollection<Post> Posts { get; set; }

        public Discussion()
        {
            Posts = new List<Post>();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Looking4Group.Models
{
    public class Forum
    {
        public int ForumID { get; set; }

        public String Name { get; set; }
        public String Description { get; set; }

        public ICollection<Discussion> Discussions { get; set; }

        public Forum()
        {
            Discussions = new List<Discussion>();
        }
    }
}

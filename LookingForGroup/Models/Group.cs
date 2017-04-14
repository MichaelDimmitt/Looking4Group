using System;
using System.Collections.Generic;

namespace Looking4Group.Models
{
    public class Group
    {
        public int GroupID { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public String Link { get; set; }
        public ICollection<UserTag> Tags { get; set; }
    }
}

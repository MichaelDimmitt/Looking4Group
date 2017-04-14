using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Looking4Group.Models
{
    public class GroupTag
    {
        [Key]
        public int TagID { get; set; }
        public int GroupID { get; set; }
        public String Label { get; set; }
        public int Weight { get; set; }

        public Group Group { get; set; }
    }
}

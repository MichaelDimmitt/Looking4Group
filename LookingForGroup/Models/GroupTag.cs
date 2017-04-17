using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Looking4Group.Models
{
    public class GroupTag
    {
        [Key]
        public int TagID { get; set; }
        public int GroupID { get; set; }

        [StringLength(15, ErrorMessage = "Max size: 15")]
        public String Label { get; set; }
        public int Weight { get; set; }

        [ForeignKey("GroupID")]
        public Group Group { get; set; }
    }
}

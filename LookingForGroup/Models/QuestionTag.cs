using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Looking4Group.Models
{
    public class QuestionTag
    {
        [Key]
        public int TagID { get; set; }
        public String Label { get; set; }

        public Question Question { get; set; }
    }
}

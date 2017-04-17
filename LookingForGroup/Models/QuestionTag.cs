using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Looking4Group.Models
{
    public class QuestionTag
    {
        [Key]
        public int TagID { get; set; }
        public int QuestionID { get; set; }

        [StringLength(15, ErrorMessage = "Max size: 15")]
        public String Label { get; set; }

        [ForeignKey("QuestionID")]
        public virtual Question Question { get; set; }
    }
}

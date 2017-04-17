using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Looking4Group.Models
{
    public class Question
    {
        public int QuestionID { get; set; }
        public bool DefaultQuestion { get; set; }

        [StringLength(64, ErrorMessage = "Max size: 64")]
        public String Title { get; set; }

        [StringLength(64, ErrorMessage = "Max size: 64")]
        public String Answer1 { get; set; }

        [StringLength(64, ErrorMessage = "Max size: 64")]
        public String Answer2 { get; set; }

        [StringLength(64, ErrorMessage = "Max size: 64")]
        public String Answer3 { get; set; }

        [StringLength(64, ErrorMessage = "Max size: 64")]
        public String Answer4 { get; set; }

        public ICollection<QuestionTag> Tags { get; set; }

        public Question()
        {
            Tags = new List<QuestionTag>();
        }
    }
}

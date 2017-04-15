using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Looking4Group.Models
{
    public class Question
    {
        public int QuestionID { get; set; }
        public bool DefaultQuestion { get; set; }
        public String Title { get; set; }
        public String Answer1 { get; set; }
        public String Answer2 { get; set; }
        public String Answer3 { get; set; }
        public String Answer4 { get; set; }

        public ICollection<QuestionTag> Tags { get; set; }
    }
}

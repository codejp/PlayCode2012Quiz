using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlayCode2012Quiz.Models
{
    public class GDataQuestion
    {
        public int QuestionID { get; set; }

        public string Body { get; set; }

        public string Option0 { get; set; }
        public string Option1 { get; set; }
        public string Option2 { get; set; }
        public string Option3 { get; set; }
        public string Option4 { get; set; }
        public string Option5 { get; set; }

        public string IndexOfCorrectOption { get; set; }

        public string Comment { get; set; }

        public string Category { get; set; }
    }
}
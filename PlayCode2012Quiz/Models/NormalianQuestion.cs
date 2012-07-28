using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlayCode2012Quiz.Models
{
    public class NormalianQuestion
    {
        public string QuestionSummary { get; set; }
        public string AnswerDetail { get; set; }
        public string Answer1 { get; set; }
        public string Answer2 { get; set; }
        public string Answer3 { get; set; }
        public string Answer4 { get; set; }
        public string Answer5 { get; set; }
        public string Answer6 { get; set; }
        public int AnswerNo { get; set; }
    }
}
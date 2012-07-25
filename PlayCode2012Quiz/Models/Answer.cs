using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlayCode2012Quiz.Models
{
    public class Answer
    {
        public int AnswerID { get; set; }

        public int PlayerID { get; set; }

        public int QuestionID { get; set; }

        public int ChoincedOptionIndex { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PlayCode2012Quiz.Models;

namespace PlayCode2012Quiz.Controllers
{
    public class AdminController : Controller
    {
        public PlayCode2012QuizDB DB { get; set; }

        public AdminController()
        {
            this.DB = new PlayCode2012QuizDB();
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View(this.DB);
        }

        [HttpGet]
        public ActionResult QuestionBody()
        {
            var context = this.DB.Context.First();
            var curQuestion = this.DB.Questions.Find(context.CurrentQuestionID);
            return View(curQuestion);
        }

        [HttpPost]
        public ActionResult CurrentState(int state)
        {
            var context = this.DB.Context.First();
            context.CurrentState = state;
            
            // if change state to "3:show answer", judge to all players.
            if (state == 3)
            {
                var answers = this.DB
                    .Answers
                    .Where(a =>a.QuestionID == context.CurrentQuestionID)
                    .ToList();
                var currentQuestion = this.DB.Questions.Find(context.CurrentQuestionID);

                answers
                    .ForEach(a => a.Status = 
                        a.ChoincedOptionIndex == currentQuestion.IndexOfCorrectOption
                        ? 2 : 3);
            }
            
            this.DB.SaveChanges();

            return Json(new { });
        }

        [HttpPost]
        public ActionResult CurrentQuestion(int questionID)
        {
            this.DB.Context.First().CurrentQuestionID = questionID;
            this.DB.SaveChanges();

            return Json(new { });
        }
    }
}

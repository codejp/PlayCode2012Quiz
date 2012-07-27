using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text.RegularExpressions;
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
 
    
        [HttpGet]
        public ActionResult ImportQuestion()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ImportQuestion(FormCollection f)
        {
            var GDbUser = ConfigurationManager.AppSettings["GData.User"];
            var GDbPwd = ConfigurationManager.AppSettings["GData.Password"];

            var questions = 
                new GDataDB.DatabaseClient(GDbUser, GDbPwd)
                .GetDatabase("CopyOfCode2012Quiz")
                .GetTable<GDataQuestion>("Sheet1")
                .FindAll()
                .Select(r => r.Element)
                .ToArray();

            using (var db = new PlayCode2012QuizDB())
            {
                db.Database.ExecuteSqlCommand("TRUNCATE TABLE Questions");

                var qs = questions
                    .Select(q => new Question
                    {
                        Body = q.Body,
                        Option0 = q.Option0,
                        Option1 = q.Option1,
                        Option2 = q.Option2,
                        Option3 = q.Option3,
                        Option4 = q.Option4,
                        Option5 = q.Option5,
                        Comment = q.Comment,
                        IndexOfCorrectOption = int.Parse(Regex.Match(q.IndexOfCorrectOption, @"\d+").Value) - 1
                    })
                    .ToList();
                    qs.ForEach(q => db.Questions.Add(q));

                db.SaveChanges();
            }

            return View();
        }
    }
}

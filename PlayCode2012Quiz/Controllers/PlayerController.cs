using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using PlayCode2012Quiz.Models;

namespace PlayCode2012Quiz.Controllers
{
    [Authorize]
    public class PlayerController : Controller
    {
        public PlayCode2012QuizDB DB { get; set; }

        public PlayerController()
        {
            this.DB = new PlayCode2012QuizDB();
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View(this.DB);
        }

        [HttpGet]
        public ActionResult PlayerMainContent()
        {
            var context = this.DB.Context.First();
            var playerID = this.DB.Players.First(p => p.Name == User.Identity.Name).PlayerID;
            var questionID = this.DB.Context.First().CurrentQuestionID;
            var ansewer = this.DB.Answers.FirstOrDefault(a => a.PlayerID == playerID && a.QuestionID == questionID);
            if (ansewer == null)
            {
                ansewer = new Answer { PlayerID = playerID, QuestionID = questionID, ChoincedOptionIndex = -1 };
                this.DB.Answers.Add(ansewer);
                this.DB.SaveChanges();
            }

            return PartialView("PlayerMainContent" + context.CurrentState.ToString(), this.DB);
        }

        [HttpGet]
        public ActionResult CurrentState()
        {
            return Json(this.DB.Context.First().CurrentState, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult SelectedOptionIndex(int index)
        {
            var playerID = this.DB.Players.First(p => p.Name == User.Identity.Name).PlayerID;
            var questionID = this.DB.Context.First().CurrentQuestionID;
            var ansewer = this.DB.Answers.FirstOrDefault(a => a.PlayerID == playerID && a.QuestionID == questionID);
            ansewer.ChoincedOptionIndex = index;
            ansewer.Status = 1;/*entried*/

            this.DB.SaveChanges();

            return Json(new { });
        }


        #region Dashboard

        [HttpGet]
        public ActionResult Dashboard()
        {
            return View(this.DB);
        }

        [HttpGet]
        public ActionResult LatestDashboard()
        {
            return PartialView("DashboardMainContent", this.DB);
        } 
        
        #endregion
    }
}

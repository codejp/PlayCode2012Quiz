using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using PlayCode2012Quiz.Models;

namespace PlayCode2012Quiz.Controllers
{
    public class QuestionsController : ApiController
    {
        private PlayCode2012QuizDB db = new PlayCode2012QuizDB();

        // GET api/Questions
        [Queryable]
        public IQueryable<Question> GetQuestions()
        {
            return db.Questions;
        }

        [HttpGet]
        public int Count()
        {
            return db.Questions.Count();
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
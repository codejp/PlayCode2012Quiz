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
            return View();
        }

        [HttpGet]
        public ActionResult Dashboard()
        {
            return View(this.DB);
        }
    }
}

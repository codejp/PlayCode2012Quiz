﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using PlayCode2012Quiz.Models;

namespace PlayCode2012Quiz.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string name)
        {
            FormsAuthentication.SetAuthCookie(name, createPersistentCookie: false);
            using (var db = new PlayCode2012QuizDB())
            {
                if (db.Players.Any(p => p.Name == name) == false)
                {
                    db.Players.Add(new Player { Name = name });
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index", "Player");
        }

    }
}

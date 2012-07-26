using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using PlayCode2012Quiz.Models;

namespace PlayCode2012Quiz
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            using (var db = new PlayCode2012QuizDB())
            {
                if (db.Context.Any() == false)
                {
                    db.Context.Add(new Context { CurrentQuestionID = 1, CurrentState = 0 });
                    
                    db.Players.Add(new Player { Name = "jsakamoto" });
                    db.Players.Add(new Player { Name = "zecl" });

                    db.Questions.Add(new Question { Body = "Q-1", Option0 = "A-1-1", Option1 = "A-1-2", Option3 = "A-1-3", IndexOfCorrectOption = 0 });
                    db.Questions.Add(new Question { Body = "Q-2", Option0 = "A-2-1", Option1 = "A-2-2", Option3 = "A-2-3", IndexOfCorrectOption = 1 });
                    
                    db.SaveChanges();
                }
            }
        }
    }
}
using System.Data.Entity;
using Devtalk.EF.CodeFirst;
using PlayCode2012Quiz.Models;

[assembly: WebActivator.PreApplicationStartMethod(typeof(PlayCode2012Quiz.App_Start.DontDropDbJustCreateTablesIfModelChangedStart), "Start")]

namespace PlayCode2012Quiz.App_Start {
    public static class DontDropDbJustCreateTablesIfModelChangedStart {
        public static void Start() {
            // Uncomment this line and replace CONTEXT_NAME with the name of your DbContext if you are 
            // using your DbContext to create and manage your database
            Database.SetInitializer(new DontDropDbJustCreateTablesIfModelChanged<PlayCode2012QuizDB>());
        }
    }
}

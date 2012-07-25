using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PlayCode2012Quiz.Models
{
    public class PlayCode2012QuizDB : DbContext
    {
        public DbSet<Player> Players { get; set; }

        public DbSet<Question> Questions { get; set; }

        public DbSet<Answer> Answers { get; set; }

        public DbSet<Context> Context { get; set; }
    }
}
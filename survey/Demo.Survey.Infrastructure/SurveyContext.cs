using System;

namespace Demo.Survey.Infrastructure
{
    using System.Collections.Generic;
    using Microsoft.EntityFrameworkCore;
    using Model;

    public class SurveyContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public List<User> Users { get; set; }
        public List<UserSurvey> UserSurveys { get; set; }
        public List<UserQuestionAnswer> UserQuestionAnswers { get; set; }
        public List<Survey> Surveys { get; set; }
        public List<SurveyQuestion> SurveyQuestions { get; set; }
        public List<QuestionAnswer> QuestionAnswers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=demo.db");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // user survey context
            modelBuilder.Entity<User>();
            modelBuilder.Entity<UserSurvey>();
            modelBuilder.Entity<UserQuestionAnswer>();

            // survey context
            modelBuilder.Entity<Survey>();
            modelBuilder.Entity<SurveyQuestion>();
            modelBuilder.Entity<QuestionAnswer>();
            base.OnModelCreating(modelBuilder);

        }
    }
}

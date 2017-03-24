// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Demo.Survey.Api.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using Infrastructure;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.ViewFeatures.Internal;
    using Microsoft.EntityFrameworkCore;
    using Model;

    [Route("api/[controller]")]
    public class SurveyController : Controller
    {
        private readonly SurveyContext dbContext;
        private static UserSurvey cache;

        // GET: api/values
        public SurveyController(SurveyContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public List<UserSurvey> Get()
        {
            PopulateIfNoData();
            //var surveys = dbContext.Set<UserSurvey>()
            //    .Include(x => x.User)
            //    .Include(x => x.Answers)
            //    .Include(x => x.Survey)
            //    .ThenInclude(x => x.Questions)
            //    .ThenInclude(x => x.Answers)
            //    .ToList();
            //return surveys;
            return new List<UserSurvey>() {cache};
        }

        //// GET api/values/5
        //[HttpGet("{id}")]
        //public UserSurvey Get(int id)
        //{
        //    PopulateIfNoData();
        //    return dbContext.Set<UserSurvey>()
        //        .Include(x => x.User)
        //        .Include(x => x.Answers)
        //        .Include(x => x.Survey)
        //        .ThenInclude(x => x.Questions)
        //        .ThenInclude(x => x.Answers).FirstOrDefault(x => x.Id == id);
        //}

        #region Demo data

        private void PopulateIfNoData()
        {
            //dbContext.Database.EnsureDeleted();
            //dbContext.Database.EnsureCreated();
            //dbContext.Database.Migrate();
            if (cache != null)
            {
                return;
            }

            var survey = CreateSurvey();
            var userSurvey = new UserSurvey()
            {
                User = new User() { Name = "Demo" },
                Survey = survey,
                Answers = new List<UserQuestionAnswer>()
            };

            cache = userSurvey;

            var surveys = dbContext.Set<UserSurvey>();
            if (!surveys.Any())
            {   surveys.Add(userSurvey);
                dbContext.SaveChanges();
            }
        }

        private static Survey CreateSurvey()
        {
            var survey = new Survey();
            survey.Title = "This is a demo!";
            SurveyQuestion question1 = null;
            question1 = new SurveyQuestion
            {
                QuestionType = QuestionType.Select,
                Text = "How did you find out about this job opportunity?",
                Answers = new List<QuestionAnswer>
                {
                    new QuestionAnswer
                    {
                        Answer = "StackOverflow"
                    },
                    new QuestionAnswer
                    {
                        Answer = "Indeed"
                    },
                    new QuestionAnswer
                    {
                        Answer = "Other"
                    }
                }
            };
            var question2 = new SurveyQuestion
            {
                QuestionType = QuestionType.MultiSelect,
                Text = "How do you find the company’s location?",
                Answers = new List<QuestionAnswer>
                {
                    new QuestionAnswer
                    {
                        Answer = "Easy to access by public transport."
                    },
                    new QuestionAnswer
                    {
                        Answer = "Easy to access by car."
                    },
                    new QuestionAnswer
                    {
                        Answer = "In a pleasant area."
                    },
                    new QuestionAnswer
                    {
                        Answer = "None of the above."
                    }
                }
            };
            var question3 = new SurveyQuestion
            {
                QuestionType = QuestionType.Select,
                Text = "What was your impression of the office where you had the interview?",
                Answers = new List<QuestionAnswer>
                {
                    new QuestionAnswer
                    {
                        Answer = "Tidy."
                    },
                    new QuestionAnswer
                    {
                        Answer = "Sloppy."
                    },
                    new QuestionAnswer
                    {
                        Answer = "Did not notice."
                    }
                }
            };
            var question4 = new SurveyQuestion
            {
                QuestionType = QuestionType.Select,
                Text = "How technically challenging was the interview?",
                Answers = new List<QuestionAnswer>
                {
                    new QuestionAnswer
                    {
                        Answer = "Very difficult."
                    },
                    new QuestionAnswer
                    {
                        Answer = "Difficult."
                    },
                    new QuestionAnswer
                    {
                        Answer = "Moderate."
                    },
                    new QuestionAnswer
                    {
                        Answer = "Easy."
                    }
                }
            };
            var question5 = new SurveyQuestion
            {
                QuestionType = QuestionType.MultiSelect,
                Text = "How can you describe the manager that interviewed you?",
                Answers = new List<QuestionAnswer>
                {
                    new QuestionAnswer
                    {
                        Answer = "Enthusiastic."
                    },
                    new QuestionAnswer
                    {
                        Answer = "Polite."
                    },
                    new QuestionAnswer
                    {
                        Answer = "Organized."
                    },
                    new QuestionAnswer
                    {
                        Answer = "Could not tell."
                    }
                }
            };
            survey.Questions = new List<SurveyQuestion>
            {
                question1,
                question2,
                question3,
                question4,
                question5
            };
            return survey;
        }
            #endregion

        // POST api/values
        [HttpPost]
        public void Post([FromBody] UserSurvey userSurvey)
        {
            //userSurvey.Answers.ForEach(a =>
            //{
            //    x.Question = dbContext.Set<SurveyQuestion>().Find(a.Question.Id)
            //                    .Include(x => x.Answers)
            //                    .ThenInclude(x => x.Questions);
            //});
            //userSurvey.Survey = dbContext.Set<Survey>().Find(userSurvey.Survey.Id);
            //userSurvey.User = dbContext.Set<User>().Find(userSurvey.User.Id);
            //dbContext.Set<UserSurvey>().Attach(userSurvey);
            //userSurvey.Answers.ForEach(x =>
            //{
            //    dbContext.Set<UserQuestionAnswer>()
            //    .Include(x => x.Answers)
            //    .ThenInclude(x => x.Questions)
                
            //});

            //var us = dbContext.UserSurveys.Find(userSurvey.Id);
            //userSurvey.Answers.ForEach(x =>
            //{
            //    var item = dbContext.Set<UserQuestionAnswer>().FirstOrDefault(a => a.Question.Id == x.Question.Id);
            //    if (item == null)
            //    {
            //        var answ = new UserQuestionAnswer()
            //        {
            //            Question = dbContext.Set<SurveyQuestion>().Find(x.Question.Id),
            //            Answers = x.Answers
            //        };
            //        dbContext.Set<UserQuestionAnswer>().Add(answ);
            //    }
            //    else
            //    {

            //        item.Answers.Clear();
            //        x.Answers.ForEach(item.Answers.Add);
            //    }
            //});
            //dbContext.SaveChanges();
            cache = userSurvey;
        }
        
        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
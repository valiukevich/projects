namespace Demo.Survey.Api.Controllers
{
    using System;
    using System.Collections.Generic;
    using Infrastructure;
    using Microsoft.AspNetCore.Mvc;
    using Model;

    [Route("api/[controller]")]
    public class SurveyController : Controller
    {
        private readonly SurveyContext dbContext;
        private static Lazy<UserSurvey> lazy = new Lazy<UserSurvey>(CreateUserSurvey);
        private static UserSurvey cache = lazy.Value;

        // GET: api/values
        public SurveyController(SurveyContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public List<UserSurvey> Get()
        {
            return new List<UserSurvey>()
            {
                cache
            };
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] UserSurvey userSurvey)
        {
            cache = userSurvey;
        }

        #region Demo data

        private static UserSurvey CreateUserSurvey()
        {
            var survey = CreateSurvey();
            var userSurvey = new UserSurvey()
            {
                User = new User()
                {
                    Name = "Demo"
                },
                Survey = survey,
                Answers = new List<UserQuestionAnswer>()
            };
            return userSurvey;
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
    }
}
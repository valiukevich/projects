// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Demo.Survey.Api.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using Infrastructure;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Model;

    [Route("api/[controller]")]
    public class SurveyController : Controller
    {
        private readonly SurveyContext dbContext;
        // GET: api/values
        public SurveyController(SurveyContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public List<Survey> Get()
        {
            PopulateIfNoData();
            var surveys = dbContext.Set<Survey>()
                .Include(x => x.Questions)
                .ThenInclude(x => x.Answers)
                .ToList();
            return surveys;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Survey Get(int id)
        {
            PopulateIfNoData();
            return dbContext.Set<UserSurvey>()
                       .Include(x => x.Survey)
                       .ThenInclude(x => x.Questions)
                       .ThenInclude(x => x.Answers).FirstOrDefault(x => x.Id == id)?.Survey
                   ??
                   dbContext.Set<Survey>()
                       .Include(x => x.Questions)
                       .ThenInclude(x => x.Answers).FirstOrDefault();
        }

        private void PopulateIfNoData()
        {
            dbContext.Database.EnsureDeleted();
            //dbContext.Database.EnsureCreated();
            dbContext.Database.Migrate();
            var surveys = dbContext.Set<Survey>();
            if (!surveys.Any())
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
                surveys.Add(survey);
                dbContext.SaveChanges();
            }
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
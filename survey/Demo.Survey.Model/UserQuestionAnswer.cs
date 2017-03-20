using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Survey.Model
{
    public class UserQuestionAnswer : BaseEntity
    {
        public SurveyQuestion Question { get; set; }

        public List<QuestionAnswer> Answers { get; set; }
    }
}

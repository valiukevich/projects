using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Survey.Model
{
    public class SurveyQuestion : BaseEntity
    {
        public QuestionType QuestionType { get; set; }

        public string Text { get; set; }

        public List<QuestionAnswer> Answers { get; set; }
    }
}

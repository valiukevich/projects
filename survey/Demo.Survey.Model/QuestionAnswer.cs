using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Survey.Model
{
    public class QuestionAnswer : BaseEntity
    {
        public SurveyQuestion Question { get; set; }

        public string Answer { get; set; }
    }
}

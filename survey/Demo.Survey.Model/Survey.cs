using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Survey.Model
{
    public class Survey : BaseEntity
    {
        public string Title { get; set; }

        public List<SurveyQuestion> Questions { get; set; }
    }
}

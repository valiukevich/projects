using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Survey.Model
{
    public class UserSurvey : BaseEntity
    {
        public User User { get; set; }

        public Survey Survey { get; set; }

        public List<UserQuestionAnswer> Answers { get; set; }
    }
}

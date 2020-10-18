using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Data
{
    public class UserTechnicalSkills
    {
        public int TechnicalSkillsId { get; set; }
        public TechnicalSkills technicalSkills { get; set; }
        public User user { get; set; }
        public string userId { get; set; }

    }
}

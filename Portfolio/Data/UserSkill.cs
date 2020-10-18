using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Data
{
    public class UserSkill
    {
        public int InterpersonalSkillsId { get; set; }
        public string UserId { get; set; }
        public InterpersonalSkills InterpersonalSkill { get; set; }
        public User User { get; set; }
        public int TechnicalSkillsId { get; set; }
        public TechnicalSkills TechnicalSkill { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Data
{
    public class UserInterpersonalSkills
    {
        public int InterpersonalSkillsId { get; set; }
        public InterpersonalSkills interpersonalSkills { get; set; }
        public User user { get; set; }
        public string userId { get; set; }
    }
}

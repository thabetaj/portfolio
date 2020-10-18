using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Data
{
    public class TechnicalSkills
    {
        
        public int TechnicalSkillsId { get; set; }
        public string TechnicalSkillName { get; set; }
        public ICollection<UserTechnicalSkills> UserTechnicalSkills { get; set; }

    }
}

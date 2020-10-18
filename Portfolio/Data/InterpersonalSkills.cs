using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Data
{
    public class InterpersonalSkills
    {
        
        public int InterpersonalSkillsId { get; set; }
        
        public string InterpersonalSkillName { get; set; }
        public ICollection<UserInterpersonalSkills> UserInterpersonalSkills { get; set; }


    }
}

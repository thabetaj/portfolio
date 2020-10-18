using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Data
{
    public class Degree
    {
        
        public int DegreeId { get; set; }
       
        public string DegreeName { get; set; }

        public ICollection<UserUniversity> UserUniversities { get; set; }
    }
}

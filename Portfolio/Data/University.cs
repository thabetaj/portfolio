using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Data
{
    public class University
    {
        public int UniversityId { get; set; }
        public string UniversityName { get; set; }
        public ICollection<UserUniversity> UserUniversities { get; set; }
    }
}

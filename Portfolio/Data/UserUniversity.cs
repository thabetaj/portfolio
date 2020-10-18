using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Data
{
    public class UserUniversity
    {
        public int UniversityiId { get; set; }
        public int DegreeId { get; set; }
        public string MajorName { get; set; }
        public string UserId { get; set; }
        public University University { get; set; }
        public Degree Degree { get; set; }
        public User User { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Models
{
    public class UniversityDto
    {
        public int UniversityId { get; set; }
        public int DegreeId { get; set; }
        public string UniversityName { get; set; }
        public string DegreeName { get; set; }
        public string MajorName { get; set; }
    }
}

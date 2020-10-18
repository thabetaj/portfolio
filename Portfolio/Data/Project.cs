using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Data
{
    public class Project
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string ProjectDescription { get; set; }
        public byte[] ProjectImage { get; set; }
        public byte[] ProjectPDF { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
    }
}

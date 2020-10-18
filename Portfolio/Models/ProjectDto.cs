using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Models
{
    public class ProjectDto
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string ProjectDescription { get; set; }
        public IFormFile ProjectImage { get; set; }
        public byte[] ProjectImg { get; set; }
        public IFormFile ProjectPDF { get; set; }
        public byte[] ProjectPDFb { get; set; }
    }
}

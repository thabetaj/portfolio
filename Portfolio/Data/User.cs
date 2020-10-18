
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Data
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public string PortfolioEmail { get; set; }
        public long MobileNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool Gender { get; set; }
        public string Address { get; set; }
        public byte[] PersonalImage { get; set; }
        public string Vision { get; set; }
        public string About { get; set; }
        public byte[] CV { get; set; }
        public string FBUrl { get; set; }
        public string TwitterUrl { get; set; }  
        public string LinkedInUrl { get; set; }
        public string JobTitle { get; set; }
        public ICollection<UserUniversity> UserUniversities { get; set; }
        public ICollection<Project> Projects { get; set; }
        public ICollection<UserTechnicalSkills> UserTechnicalSkills { get; set; }
        public ICollection<UserInterpersonalSkills> UserInterpersonalSkills { get; set; }

    }
}

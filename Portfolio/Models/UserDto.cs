using Microsoft.AspNetCore.Http;
using Portfolio.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Models
{
    public class UserDto
    {
        public string UserId { get; set; }
        [Required]
        [Display(Name ="First Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Second Name")]
        public string SecondName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "Job Title")]
        public string JobTitle { get; set; }
        [Required]
        [Display(Name = "Email")]
        public string PortfolioEmail { get; set; }
        [Required]
        [Display(Name = "Mobile Number Name")]
        public long MobileNumber { get; set; }
        [Required]
        [Display(Name = "Date Of Birth")]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public bool Gender { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        [Display(Name = "Image")]
        public IFormFile PersonalImage { get; set; }
        public byte[] PersonalImg { get; set; }
        [Required]
        public string Vision { get; set; }
        [Required]
        public string About { get; set; }
        [Required]
        public IFormFile CV { get; set; }
        public byte[] CVb { get; set; }
        [Required]  
        public List<int> TechnicalSkills { get; set; }
        [Required]
        public List<int> InterpersonalSkills { get; set; } 
        [Required]
        public List<UniversityDto> UniversityDtos { get; set; }
        [Required]
        public List<ProjectDto> ProjectDtos { get; set; }
        [Required]
        [Display(Name = "Facebook Url")]
        public string FBUrl { get; set; }
        [Required]
        [Display(Name = "Twitter Url")]
        public string TwitterUrl { get; set; }
        [Required]
        [Display(Name = "LinkedIn Url")]
        public string LinkedInUrl { get; set; }
    }
}

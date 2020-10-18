using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Portfolio.Data;
using Portfolio.Models;
using Portfolio.Repositories;
using Portfolio.Views.User;

namespace Portfolio.Controllers
{
    [ApiController]
    [Route("API/[Controller]/[Action]")]
    public class UserController : Controller
    {
        private readonly IUserRepository userRepository;
        private readonly IUserSkillsRepository userSkillsRepository;
        private readonly IUserUniversityRepository userUniversity;
        private readonly IUserProjectRepository userProjectRepository;
       
        public UserController(IUserRepository userRepository, IUserSkillsRepository userSkillsRepository, IUserUniversityRepository userUniversity, IUserProjectRepository userProjectRepository)
        {
            this.userRepository = userRepository;
            this.userSkillsRepository = userSkillsRepository;
            this.userUniversity = userUniversity;
            this.userProjectRepository = userProjectRepository;
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<ICollection<User>>> UserInfo()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var technicalSkills = userSkillsRepository.getAllTechnicalSkills();
            ViewBag.TechnicalSkills = technicalSkills;
            var interpersonalSkills = userSkillsRepository.getAllInterpersonalSkills();
            ViewBag.InterpersonalSkills = interpersonalSkills;
            var universities = userUniversity.getAllUniversities();
            ViewBag.Universities =  universities;
            var degrees = userUniversity.getAllDegrees();
            ViewBag.Degrees = degrees;
            return View();
        }
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<ICollection<User>>> Create([FromForm]UserDto userDto)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            userDto.UserId = userId;
            if (userDto.CV.Length > 0)
            {
                Stream st = userDto.CV.OpenReadStream();
                using (BinaryReader br = new BinaryReader(st))
                {
                    userDto.CVb = br.ReadBytes((int)userDto.CV.Length);
                }
            }
            if (userDto.PersonalImage.Length > 0)
            {
                Stream st = userDto.PersonalImage.OpenReadStream();
                using (BinaryReader br = new BinaryReader(st))
                {
                    userDto.PersonalImg = br.ReadBytes((int)userDto.PersonalImage.Length);
                }
            }
            if (userDto.ProjectDtos[0].ProjectImage.Length > 0)
            {
                Stream st = userDto.ProjectDtos[0].ProjectImage.OpenReadStream();
                using (BinaryReader br = new BinaryReader(st))
                {
                    userDto.ProjectDtos[0].ProjectImg = br.ReadBytes((int)userDto.ProjectDtos[0].ProjectImage.Length);
                }
            }
            if (userDto.ProjectDtos[1].ProjectImage.Length > 0)
            {
                Stream st = userDto.ProjectDtos[1].ProjectImage.OpenReadStream();
                using (BinaryReader br = new BinaryReader(st))
                {
                    userDto.ProjectDtos[1].ProjectImg = br.ReadBytes((int)userDto.ProjectDtos[1].ProjectImage.Length);
                }
            }
            if (userDto.ProjectDtos[2].ProjectImage.Length > 0)
            {
                Stream st = userDto.ProjectDtos[2].ProjectImage.OpenReadStream();
                using (BinaryReader br = new BinaryReader(st))
                {
                    userDto.ProjectDtos[2].ProjectImg = br.ReadBytes((int)userDto.ProjectDtos[2].ProjectImage.Length);
                }
            }
            if (userDto.ProjectDtos[0].ProjectPDF.Length > 0)
            {
                Stream st = userDto.ProjectDtos[0].ProjectPDF.OpenReadStream();
                using (BinaryReader br = new BinaryReader(st))
                {
                    userDto.ProjectDtos[0].ProjectPDFb = br.ReadBytes((int)userDto.ProjectDtos[0].ProjectPDF.Length);
                }
            }
            if (userDto.ProjectDtos[1].ProjectPDF.Length > 0)
            {
                Stream st = userDto.ProjectDtos[1].ProjectPDF.OpenReadStream();
                using (BinaryReader br = new BinaryReader(st))
                {
                    userDto.ProjectDtos[1].ProjectPDFb = br.ReadBytes((int)userDto.ProjectDtos[1].ProjectPDF.Length);
                }
            }
            if (userDto.ProjectDtos[2].ProjectPDF.Length > 0)
            {
                Stream st = userDto.ProjectDtos[2].ProjectPDF.OpenReadStream();
                using (BinaryReader br = new BinaryReader(st))
                {
                    userDto.ProjectDtos[2].ProjectPDFb = br.ReadBytes((int)userDto.ProjectDtos[2].ProjectPDF.Length);
                }
            }
            if (ModelState.IsValid)
            {
                await userRepository.Add(userDto);

                return RedirectToAction("ViewPortfolio", "View");
            }
            return View();
        }
        
        
        [HttpPost]
        public async Task<ActionResult> EditPortfolio([FromForm]UserDto user)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            user.UserId = userId;
            if (user.CV.Length > 0)
            {
                Stream st = user.CV.OpenReadStream();
                using (BinaryReader br = new BinaryReader(st))
                {
                    user.CVb = br.ReadBytes((int)user.CV.Length);
                }
            }
            if (user.PersonalImage.Length > 0)
            {
                Stream st = user.PersonalImage.OpenReadStream();
                using (BinaryReader br = new BinaryReader(st))
                {
                    user.PersonalImg = br.ReadBytes((int)user.PersonalImage.Length);
                }
            }
            if (user.ProjectDtos[0].ProjectImage.Length > 0)
            {
                Stream st = user.ProjectDtos[0].ProjectImage.OpenReadStream();
                using (BinaryReader br = new BinaryReader(st))
                {
                    user.ProjectDtos[0].ProjectImg = br.ReadBytes((int)user.ProjectDtos[0].ProjectImage.Length);
                }
            }
            if (user.ProjectDtos[1].ProjectImage.Length > 0)
            {
                Stream st = user.ProjectDtos[1].ProjectImage.OpenReadStream();
                using (BinaryReader br = new BinaryReader(st))
                {
                    user.ProjectDtos[1].ProjectImg = br.ReadBytes((int)user.ProjectDtos[1].ProjectImage.Length);
                }
            }
            if (user.ProjectDtos[2].ProjectImage.Length > 0)
            {
                Stream st = user.ProjectDtos[2].ProjectImage.OpenReadStream();
                using (BinaryReader br = new BinaryReader(st))
                {
                    user.ProjectDtos[2].ProjectImg = br.ReadBytes((int)user.ProjectDtos[2].ProjectImage.Length);
                }
            }
            if (user.ProjectDtos[0].ProjectPDF.Length > 0)
            {
                Stream st = user.ProjectDtos[0].ProjectPDF.OpenReadStream();
                using (BinaryReader br = new BinaryReader(st))
                {
                    user.ProjectDtos[0].ProjectPDFb = br.ReadBytes((int)user.ProjectDtos[0].ProjectPDF.Length);
                }
            }
            if (user.ProjectDtos[1].ProjectPDF.Length > 0)
            {
                Stream st = user.ProjectDtos[1].ProjectPDF.OpenReadStream();
                using (BinaryReader br = new BinaryReader(st))
                {
                    user.ProjectDtos[1].ProjectPDFb = br.ReadBytes((int)user.ProjectDtos[1].ProjectPDF.Length);
                }
            }
            if (user.ProjectDtos[2].ProjectPDF.Length > 0)
            {
                Stream st = user.ProjectDtos[2].ProjectPDF.OpenReadStream();
                using (BinaryReader br = new BinaryReader(st))
                {
                    user.ProjectDtos[2].ProjectPDFb = br.ReadBytes((int)user.ProjectDtos[2].ProjectPDF.Length);
                }
            }
            userRepository.UpdateUser(user);
            return RedirectToAction("ViewPortfolio", "View");
        }

        [HttpGet]
        public  JsonResult ViewPortfolio()
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                User user = userRepository.getViewUser(userId);
                var universitiesList = userUniversity.getAllUniversitiesById(userId);
                var intePersonalSkills = userSkillsRepository.getAllInterPersonalSkillsById(userId);
                var technicalSkills = userSkillsRepository.getAllTechnicalSkillsById(userId);
                var projects = userProjectRepository.getAllProjectsById(userId);

                List<InterpersonalSkillDto> personalSkills = new List<InterpersonalSkillDto>();

                foreach (var skill in intePersonalSkills)
                {
                    personalSkills.Add(new InterpersonalSkillDto
                    {
                        Name = skill.InterpersonalSkillName
                    });
                }
                List<TechnicalSkillDto> techSkills = new List<TechnicalSkillDto>();

                foreach (var skill in technicalSkills)
                {
                    techSkills.Add(new TechnicalSkillDto
                    {
                        Name = skill.TechnicalSkillName
                    });
                }
                List<ProjectDto> project = new List<ProjectDto>();

                foreach (var prj in projects)
                {
                    project.Add(new ProjectDto
                    {
                        ProjectName = prj.ProjectName,
                        ProjectDescription = prj.ProjectDescription,
                        ProjectImg = prj.ProjectImage,
                        ProjectPDFb = prj.ProjectPDF
                    });
                }

                var user1 = new
                {
                    firstName = user.FirstName,
                    secondName = user.SecondName,
                    about = user.About,
                    vision = user.Vision,
                    lastName = user.LastName,
                    linkedInUrl = user.LinkedInUrl,
                    fBUrl = user.FBUrl,
                    twitterUrl = user.TwitterUrl,
                    portfolioEmail = user.PortfolioEmail,
                    jobTitle = user.JobTitle,
                    interpersonalSkill = personalSkills,
                    technicalSkill = techSkills,
                    project = project,
                    personalImage = user.PersonalImage,
                    mobileNumber = user.MobileNumber,
                    address = user.Address,
                    DateOfBirth = user.DateOfBirth.Year + "-" + user.DateOfBirth.Month + "-" + user.DateOfBirth.Day,
                    id = user.Id,
                };
                return Json(user1);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return Json("");
        }
       
       
        [HttpGet]
        public JsonResult ViewPortfolioForAdmin(string Id)
        {
            User user =  userRepository.getViewUser(Id);
            var universitiesList = userUniversity.getAllUniversitiesById(Id);
            var interPersonalSkills = userSkillsRepository.getAllInterPersonalSkillsById(Id);
            var technicalSkills = userSkillsRepository.getAllTechnicalSkillsById(Id);
            var projects = userProjectRepository.getAllProjectsById(Id);

            List<InterpersonalSkillDto> personalSkills = new List<InterpersonalSkillDto>();

            foreach (var skill in interPersonalSkills)
            {
                personalSkills.Add(new InterpersonalSkillDto
                {
                    Name = skill.InterpersonalSkillName
                });
            }
            List<TechnicalSkillDto> techSkills = new List<TechnicalSkillDto>();

            foreach (var skill in technicalSkills)
            {
                techSkills.Add(new TechnicalSkillDto
                {
                    Name = skill.TechnicalSkillName
                });
            }

          
            var user1 = new
            {
                firstName = user.FirstName,
                secondName = user.SecondName,
                about = user.About,
                vision = user.Vision,
                lastName = user.LastName,
                linkedInUrl = user.LinkedInUrl,
                fBUrl = user.FBUrl,
                twitterUrl = user.TwitterUrl,
                portfolioEmail = user.PortfolioEmail,
                jobTitle = user.JobTitle,
                interpersonalSkill = personalSkills,
                technicalSkill = techSkills,
                personalImage = user.PersonalImage,
                mobileNumber = user.MobileNumber,
                address = user.Address,
                DateOfBirth = user.DateOfBirth.Year + "-" + user.DateOfBirth.Month + "-" + user.DateOfBirth.Day,
            };
            return Json(user1);
        }
        [HttpGet]
        public FileStreamResult CV(string Id)
        {
            var user = userRepository.getViewUser(Id);
            var file = user.CV;
            Stream stream = new MemoryStream(file);
            return new FileStreamResult(stream, "application/pdf");
        }
        [HttpGet]
        public FileStreamResult ProjectFile(int Id)
        {
            var project = userProjectRepository.getProjectById(Id);
            var file = project.ProjectPDF;
            Stream stream = new MemoryStream(file);
            return new FileStreamResult(stream, "application/pdf");
        }
    }

}

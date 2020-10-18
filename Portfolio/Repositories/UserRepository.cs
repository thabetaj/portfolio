using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;
using Portfolio.Data;
using Portfolio.Data.Migrations;
using Portfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;


namespace Portfolio.Repositories
{
    public class UserRepository : IUserRepository
    {
        public void SendMail(string email, string name, string Id)
        {
            using (var message = new MailMessage("Thabet.Ajweh@HTU.EDU.JO", email))
            {
                message.To.Add(new MailAddress(email));
                message.From = new MailAddress("Thabet.Ajweh@HTU.EDU.JO");
                message.Subject = "Your portfolio is ready";
                message.Body = $"Dear {name},<br/><br/>" +
                    $"Your portfoio is ready and this is the link <br/>" +
                    $"http://thabet.azurewebsites.net/AdminUsers/ViewPortfolio?UserId=" + Id;
                message.IsBodyHtml = true;
                using (var smtpClient = new SmtpClient("smtp.office365.com", 587))
                {
                    smtpClient.EnableSsl = true;
                    smtpClient.UseDefaultCredentials = false;
                    smtpClient.Credentials = new NetworkCredential("Thabet.Ajweh@HTU.EDU.JO", "Ajwenho1412017*");
                    smtpClient.Send(message);
                }
            }
        }
        private readonly ApplicationDbContext applicationDbContext;
        public UserRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
        public User getViewUser(string Id)
        {
            try
            {
                return applicationDbContext.User
                .Where(x => x.Id == Id)
                .SingleOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public UserDto UpdateUser(string Id)
        {
            var editUser = applicationDbContext.User.Include(x => x.UserInterpersonalSkills)
                .ThenInclude(x => x.interpersonalSkills)
                .Include(x => x.UserTechnicalSkills)
                .ThenInclude(x => x.technicalSkills)
                .Include(x => x.UserUniversities)
                .ThenInclude(x => x.University)
                .Include(x => x.Projects).Where(x => x.Id == Id)
                .SingleOrDefault();
            List<int> interpersonalSkillIds = new List<int>();
            List<int> technicalSkillIds = new List<int>();
            UserDto userDto = new UserDto()
            {
                FirstName = editUser.FirstName,
                SecondName = editUser.SecondName,
                LastName = editUser.LastName,
                Address = editUser.Address,
                DateOfBirth = editUser.DateOfBirth,
                CVb = editUser.CV,
                PortfolioEmail = editUser.PortfolioEmail,
                Gender = editUser.Gender,
                About = editUser.About,
                MobileNumber = editUser.MobileNumber,
                PersonalImg = editUser.PersonalImage,
                Vision = editUser.Vision,
                LinkedInUrl = editUser.LinkedInUrl,
                FBUrl = editUser.FBUrl,
                TwitterUrl = editUser.TwitterUrl,
                JobTitle = editUser.JobTitle,
            };
            foreach (var techSkill in editUser.UserTechnicalSkills)
            {
                technicalSkillIds.Add(techSkill.TechnicalSkillsId);
            }
            userDto.TechnicalSkills = technicalSkillIds;
            var techSkills = applicationDbContext.TechnicalSkills.ToList();
            applicationDbContext.SaveChanges();
            foreach (var interSkill in editUser.UserInterpersonalSkills)
            {
                interpersonalSkillIds.Add(interSkill.InterpersonalSkillsId);
            }
            userDto.InterpersonalSkills = interpersonalSkillIds;
            var interSkills = applicationDbContext.InterpersonalSkills.ToList();

            return userDto;
        }

        public async Task<List<User>> Add(UserDto userDto)
        {
            var user = applicationDbContext.Users.Where(x => x.Id == userDto.UserId).SingleOrDefault();
            user.FirstName = userDto.FirstName;
            user.SecondName = userDto.SecondName;
            user.LastName = userDto.LastName;
            user.Address = userDto.Address;
            user.DateOfBirth = userDto.DateOfBirth;
            user.CV = userDto.CVb;
            user.PortfolioEmail = userDto.PortfolioEmail;
            user.Gender = userDto.Gender;
            user.About = userDto.About;
            user.MobileNumber = userDto.MobileNumber;
            user.PersonalImage = userDto.PersonalImg;
            user.Vision = userDto.Vision;
            user.LinkedInUrl = userDto.LinkedInUrl;
            user.FBUrl = userDto.FBUrl;
            user.TwitterUrl = userDto.TwitterUrl;
            user.JobTitle = userDto.JobTitle;
            applicationDbContext.SaveChanges();

            foreach (var techSkill in userDto.TechnicalSkills)
            {
                UserTechnicalSkills userTechnicalSkills = new UserTechnicalSkills();
                userTechnicalSkills.userId = user.Id;
                userTechnicalSkills.TechnicalSkillsId = techSkill;
                applicationDbContext.UserTechnicalSkills.Add(userTechnicalSkills);
                applicationDbContext.SaveChanges();
            }
            foreach (var interSkill in userDto.InterpersonalSkills)
            {
                UserInterpersonalSkills userInterpersonalSkills = new UserInterpersonalSkills();
                userInterpersonalSkills.userId = user.Id;
                userInterpersonalSkills.InterpersonalSkillsId = interSkill;
                applicationDbContext.UserInterpersonalSkills.Add(userInterpersonalSkills);
                applicationDbContext.SaveChanges();
            }
            foreach (var u in userDto.UniversityDtos)
            {
                UserUniversity userUniversity = new UserUniversity();
                userUniversity.UserId = user.Id;
                userUniversity.DegreeId = u.DegreeId;
                userUniversity.UniversityiId = u.UniversityId;
                userUniversity.MajorName = u.MajorName;
                applicationDbContext.UserUniversitiess.Add(userUniversity);
                applicationDbContext.SaveChanges();
            }
            foreach (var u in userDto.ProjectDtos)
            {
                Project project = new Project();
                project.UserId = user.Id;
                project.ProjectId = u.ProjectId;
                project.ProjectImage = u.ProjectImg;
                project.ProjectPDF = u.ProjectPDFb;
                project.ProjectName = u.ProjectName;
                project.ProjectDescription = u.ProjectDescription;
                applicationDbContext.Projects.Add(project);
                applicationDbContext.SaveChanges();
            }
            SendMail(user.Email, user.FirstName, user.Id);

            var userRet = applicationDbContext.User.Where(x => x.Id == userDto.UserId).ToList();
            return userRet;
        }


        public UserDto getUserSkills(string id)
        {
            var user = applicationDbContext.User
                .Include(x => x.UserInterpersonalSkills).ThenInclude(x => x.interpersonalSkills)
                .Where(x => x.Id == id).SingleOrDefault();
            List<int> interpersonalSkillsId = new List<int>();
            UserDto userDto = new UserDto()
            {
                FirstName = user.FirstName,
                SecondName = user.SecondName,
                LastName = user.LastName,
                Address = user.Address,
                DateOfBirth = user.DateOfBirth,
                CVb = user.CV,
                PortfolioEmail = user.PortfolioEmail,
                Gender = user.Gender,
                About = user.About,
                MobileNumber = user.MobileNumber,
                PersonalImg = user.PersonalImage,
                Vision = user.Vision,
            };
            throw new NotImplementedException();
        }
        public List<User> GetAllUser()
        {
            var user = applicationDbContext.Users.ToList();
            return user;
        }

        public async void UpdateUser(UserDto user)
        {
            var user1 = applicationDbContext.Users.Where(x => x.Id == user.UserId).SingleOrDefault();
            user1.FirstName = user.FirstName;
            user1.SecondName = user.SecondName;
            user1.LastName = user.LastName;
            user1.Address = user.Address;
            user1.DateOfBirth = user.DateOfBirth;
            user1.CV = user.CVb;
            user1.PortfolioEmail = user.PortfolioEmail;
            user1.About = user.About;
            user1.MobileNumber = user.MobileNumber;
            user1.PersonalImage = user.PersonalImg;
            user1.Vision = user.Vision;
            user1.LinkedInUrl = user.LinkedInUrl;
            user1.FBUrl = user.FBUrl;
            user1.TwitterUrl = user.TwitterUrl;
            user1.JobTitle = user.JobTitle;
            var InterpersonalSkills = applicationDbContext.UserInterpersonalSkills
                .Where(x => x.userId == user1.Id).ToList();
            foreach (var i in InterpersonalSkills)
            {
                applicationDbContext.Remove(i);
                applicationDbContext.SaveChanges();
            }
            var inter = new UserInterpersonalSkills();
            foreach (var i in user.InterpersonalSkills)
            {
                inter.userId = user.UserId;
                inter.InterpersonalSkillsId = i;
                applicationDbContext.UserInterpersonalSkills.Add(inter);
                applicationDbContext.SaveChanges();
            }

            var TechnicalSkills = applicationDbContext.UserTechnicalSkills.Where(x => x.userId == user1.Id).ToList();
            foreach (var i in TechnicalSkills)
            {
                applicationDbContext.Remove(i);
                applicationDbContext.SaveChanges();
            }
            var tech = new UserTechnicalSkills();
            foreach (var i in user.TechnicalSkills)
            {
                tech.userId = user.UserId;
                tech.TechnicalSkillsId = i;
                applicationDbContext.UserTechnicalSkills.Add(tech);
                applicationDbContext.SaveChanges();
            }
            var uni = applicationDbContext.UserUniversitiess.Where(x => x.UserId == user.UserId).ToList();
            foreach (var unii in uni)
            {
                applicationDbContext.Remove(unii);
                applicationDbContext.SaveChanges();
            }
            foreach (var i in user.UniversityDtos)
            {
                var unii = new UserUniversity();
                unii.UserId = user.UserId;
                unii.UniversityiId = i.UniversityId;
                unii.DegreeId = i.DegreeId;
                unii.MajorName = i.MajorName;
                applicationDbContext.UserUniversitiess.Add(unii);
                applicationDbContext.SaveChanges();
            }
            var project = applicationDbContext.Projects.Where(x => x.UserId == user.UserId).ToList();
            foreach (var projects in project)
            {
                applicationDbContext.Remove(projects);
                applicationDbContext.SaveChanges();
            }
            foreach (var i in user.ProjectDtos)
            {
                var pro = new Project();
                pro.UserId = user.UserId;
                pro.ProjectName = i.ProjectName;
                pro.ProjectPDF = i.ProjectPDFb;
                pro.ProjectImage = i.ProjectImg;
                pro.ProjectDescription = i.ProjectDescription;
                applicationDbContext.Projects.Add(pro);
                applicationDbContext.SaveChanges();
            }
            applicationDbContext.SaveChanges();
        }
    }
}

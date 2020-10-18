using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Data;
using Portfolio.Models;
using Portfolio.Repositories;

namespace Portfolio.Controllers
{
    public class ViewController : Controller
    {
        private readonly IUserRepository userRepository;
        private readonly IUserSkillsRepository userSkillsRepository;
        private readonly IUserUniversityRepository userUniversityRepository;
        private readonly ApplicationDbContext applicationDbContext;

        public ViewController(ApplicationDbContext applicationDbContext, IUserRepository userRepository, IUserSkillsRepository userSkillsRepository, IUserUniversityRepository userUniversityRepository)
        {
            this.userRepository = userRepository;
            this.userSkillsRepository = userSkillsRepository;
            this.userUniversityRepository = userUniversityRepository;
            this.applicationDbContext = applicationDbContext;
        }
        public IActionResult ViewPortfolio()
        {
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var unii = applicationDbContext.Universities.ToList();
                ViewBag.unii = unii;
                var degree = applicationDbContext.Degrees.ToList();
                var uni = applicationDbContext.UserUniversitiess.Where(x => x.UserId == userId).ToList();
                ViewBag.uni = uni;
                ViewBag.UserId = userId;
                var project = applicationDbContext.Projects.Where(x => x.UserId == userId).ToList();
                ViewBag.Projects = project;
                return View();
            }
        }
        [HttpGet]
        public async Task<ActionResult> EditPortfolio()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var InterpersonalSkills = userSkillsRepository.getAllInterpersonalSkills();
            ViewBag.interpersonalSkills = InterpersonalSkills;

            var TechnicalSkills = userSkillsRepository.getAllTechnicalSkills();
            ViewBag.technicalSkills = TechnicalSkills;

            var Universities = userUniversityRepository.getAllUniversities();
            ViewBag.universities = Universities;

            var Degree = userUniversityRepository.getAllDegrees();
            ViewBag.degree = Degree;

            var editUser = userRepository.UpdateUser(userId);
            return View(editUser);
        }

        public IActionResult Test()
        {
            return View();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Data;
using Portfolio.Repositories;

namespace Portfolio.Controllers
{
    public class SkillController : Controller
    {
        private readonly IUserSkillsRepository userSkillsRepository;
        private readonly ApplicationDbContext applicationDbContext;
        public SkillController(IUserSkillsRepository userSkillsRepository, ApplicationDbContext applicationDbContext)
        {
            this.userSkillsRepository = userSkillsRepository;
            this.applicationDbContext = applicationDbContext;
        }
        public IActionResult InterpersonalSkills()
        {
            var interpersonalSkills = userSkillsRepository.getAllInterpersonalSkillsShow();
            ViewBag.InterpersonalSkills = interpersonalSkills;
            return View();
        }
        public IActionResult InterpersonalSkillCreate()
        {
            return View();
        }
        public IActionResult CreateInterpersonalSkill(InterpersonalSkills interpersonalSkills)
        {

            userSkillsRepository.addInterpersonalSkill(interpersonalSkills);
            return RedirectToAction("InterpersonalSkills", "Skill");
        }
        public IActionResult RemoveInterpersonalSkill(int Id)
        {
            userSkillsRepository.RemoveInterpersonalSkill(Id);
            return RedirectToAction("InterpersonalSkills", "Skill");
        }
        public IActionResult TechnicalSkills()
        {
            var technicalSkills = userSkillsRepository.getAllTechnicalSkillsShow();
            ViewBag.TechnicalSkills = technicalSkills;
            return View();
        }
        public IActionResult TechnicalSkillCreate()
        {
            return View();
        }
        public IActionResult CreateTechnicalSkill(TechnicalSkills technicalSkills)
        {
            
            userSkillsRepository.addTechnicalSkill(technicalSkills);
            return RedirectToAction("TechnicalSkills", "Skill");
        }
        public IActionResult RemoveTechnicalSkill(int Id)
        {
            userSkillsRepository.RemoveTechnicalSkill(Id);
            return RedirectToAction("TechnicalSkills", "Skill");
        }
        [HttpGet]
        public IActionResult InterpersonalSkillEdit(int interpersonalSkillId)
        {
            InterpersonalSkills interpersonalSkills = userSkillsRepository.UpdateInterpersonalSkill(interpersonalSkillId);
            return View(interpersonalSkills);
        }

        [HttpPost]
        public IActionResult InterpersonalSkillEdit(InterpersonalSkills interpersonalSkills)
        {
            userSkillsRepository.ShowUpdateInterpersonal(interpersonalSkills);
            return RedirectToAction("InterpersonalSkills", "Skill");
        }
        [HttpGet]
        public IActionResult TechnicalSkillEdit(int technicalSkillId)
        {
            TechnicalSkills technicalSkills = userSkillsRepository.UpdateTechnicalSkill(technicalSkillId);
            return View(technicalSkills);
        }

        [HttpPost]
        public IActionResult TechnicalSkillEdit(TechnicalSkills technicalSkills)
        {
            userSkillsRepository.ShowUpdateTechnical(technicalSkills);
            return RedirectToAction("TechnicalSkills", "Skill");
        }
    }
}

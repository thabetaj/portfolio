using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Data;
using Portfolio.Repositories;

namespace Portfolio.Controllers
{
    public class UniversityController : Controller
    {
        private readonly IUserUniversityRepository userUniversityRepository;
        public UniversityController(IUserUniversityRepository userUniversityRepository)
        {
            this.userUniversityRepository = userUniversityRepository;
        }
        public IActionResult Universities()
        {
            var universities = userUniversityRepository.getAllUniversitiesEdit();
            ViewBag.Universities = universities;
            return View();
        }
        public IActionResult UniversityCreate()
        {
            return View();
        }
        public IActionResult CreateUniversity(University university)
        {
            userUniversityRepository.add(university);
            return RedirectToAction("Universities", "University");
        }

        public IActionResult RemoveUniversity(int Id)
        {
            userUniversityRepository.remove(Id);
            return RedirectToAction("Universities", "University");
        }
        [HttpGet]
        public IActionResult UniversityEdit(int UniversityId)
        {
            University university = userUniversityRepository.UpdateUniversity(UniversityId);
            return View(university);
        }

        [HttpPost]
        public IActionResult UniversityEdit(University university)
        {
            userUniversityRepository.Showupdate(university);
            return RedirectToAction("Universities", "University");
        }
    }
}

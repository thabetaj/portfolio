using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Data;
using Portfolio.Repositories;

namespace Portfolio.Controllers
{
    public class DegreeController : Controller
    {
        private readonly IUserDegreeRepository userDegreeRepository;
        public DegreeController(IUserDegreeRepository userDegreeRepository)
        {
            this.userDegreeRepository = userDegreeRepository;
        }
        public IActionResult Degrees()
        {
            var degrees = userDegreeRepository.getAllDegrees();
            ViewBag.Degrees = degrees;
            return View();
        }
        public IActionResult DegreeCreate()
        {
            return View();
        }
        public IActionResult CreateDegree(Degree degree)
        {
            userDegreeRepository.add(degree);
            return RedirectToAction("Degrees", "Degree");
        }

        public IActionResult RemoveDegree(int Id)
        {
            userDegreeRepository.remove(Id);
            return RedirectToAction("Degrees", "Degree");
        }
        [HttpGet]
        public IActionResult DegreeEdit(int degreeId)
        {
            Degree degree = userDegreeRepository.UpdateDegree(degreeId);
            return View(degree);
        }

        [HttpPost]
        public IActionResult DegreeEdit(Degree degree)
        {
            userDegreeRepository.ShowUpdate(degree);
            return RedirectToAction("Degrees", "Degree");
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}


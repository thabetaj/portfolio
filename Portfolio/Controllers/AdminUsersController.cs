using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Data;
using Portfolio.Models;
using Portfolio.Repositories;

namespace Portfolio.Controllers
{
    public class AdminUsersController : Controller
    {
        private readonly IUserRepository userRepository;
        private readonly IUserUniversityRepository userUniversityRepository;
        private readonly ApplicationDbContext applicationDbContext;


        public AdminUsersController(ApplicationDbContext applicationDbContext, IUserRepository userRepository, IUserUniversityRepository userUniversityRepository)
        {
            this.applicationDbContext = applicationDbContext;
            this.userRepository = userRepository;
            this.userUniversityRepository = userUniversityRepository;
        }
        [Authorize]
        public IActionResult Users()
        {
            var user = userRepository.GetAllUser();
            List<UserDto> userDtos = new List<UserDto>();
            foreach (var x in user)
            {
                userDtos.Add(new UserDto()
                {
                    UserId = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    PortfolioEmail = x.PortfolioEmail,
                    MobileNumber = (int)x.MobileNumber
                });
            }
            ViewBag.User = userDtos;
            return View();
        }
        public IActionResult ViewPortfolio(string UserId)
        {
                var unii = applicationDbContext.Universities.ToList();
                ViewBag.unii = unii;
                var degree = applicationDbContext.Degrees.ToList();
                var uni = applicationDbContext.UserUniversitiess.Where(x => x.UserId == UserId).ToList();
                ViewBag.uni = uni;
                ViewBag.UserId = UserId;
                var project = applicationDbContext.Projects.Where(x => x.UserId == UserId).ToList();
                ViewBag.Projects = project;
                return View();
        }
        public IActionResult Index()
        {
            var user = userRepository.GetAllUser();
            List<UserDto> userDtos = new List<UserDto>();
            foreach (var x in user)
            {
                userDtos.Add(new UserDto()
                {
                    UserId = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    PortfolioEmail = x.PortfolioEmail,
                    MobileNumber = (int)x.MobileNumber
                });
            }
            ViewBag.User = userDtos;
            return View();
        }
    }
}

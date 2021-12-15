using HealthCareApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Entity.Models;
using Service.Abstract;

namespace HealthCareApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserService _userService;
        public HomeController(ILogger<HomeController> logger,IUserService userService)
        {
            _userService = userService;
            _logger = logger;
        }

        public IActionResult Index()
        {
            User nuser = new User()
            {
                FirstName ="Ayşe",
                LastName = "Far",
                BloodGroup = 1,
                CreateDate = DateTime.Now,
                UpdateDate = DateTime.Now,
                FatherName = "Orhan",
                MotherName = "Fatma",
                EducationStatus = 1,
                Rh = 1,
                UserType = 1,
                CivilStatus = 1,
                Mail = "gfh@hotmail.com",
                IdentityNumber = "sfsfsfs",
                Password = "1234",
                Gender = 1,
                Weight = 45,
                Height = 160,
                Phone = "55545555",
                LastLoginDate = DateTime.Now
            };
          var result=  _userService.Add(nuser);
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

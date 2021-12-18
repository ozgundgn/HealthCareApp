using HealthCareApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreHero.ToastNotification.Abstractions;
using Entity.Models;
using Repository.Helpers;
using Service.Abstract;
using ServiceStack;

namespace HealthCareApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserService _userService;
        private readonly INotyfService _notify;
        public HomeController(ILogger<HomeController> logger, IUserService userService, INotyfService notifyService)
        {
            _userService = userService;
            _logger = logger;
            _notify = notifyService;
        }

        public IActionResult Index()
        {
            if (SessionHelper.DefaultSession == null || SessionHelper.DefaultSession.Id == 0)
            {
                return RedirectToAction("Error");
            }
            return View();
        }
        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            var result = _userService.Login(email, password);

            if (!result.Success)
            {
                _notify.Error(result.Message);
                return RedirectToAction("Error");
            }
            return RedirectToAction("Index");

        }
        public IActionResult Register()
        {
            return View("MemberRegister");
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

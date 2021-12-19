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
using Microsoft.AspNetCore.Http;
using Repository.Helpers;
using Service.Abstract;
using ServiceStack;
using ServiceStack.Redis;

namespace HealthCareApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserService _userService;
        private readonly INotyfService _notify;
        private static IRedisClient _redisClient;
        private static IHttpContextAccessor _contextAccessor;
        public HomeController(ILogger<HomeController> logger, IUserService userService, INotyfService notifyService, IRedisClient redisClient, IHttpContextAccessor contextAccessor)
        {
            _userService = userService;
            _logger = logger;
            _notify = notifyService;
            _redisClient = redisClient;
            _contextAccessor = contextAccessor;
        }

        public IActionResult Index()
        {
            if (SessionHelper.DefaultSession == null || SessionHelper.DefaultSession.Id == 0)
            {
                return RedirectToAction("DonorApplicationList","Application");
            }
            return View();
        }
        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            var result = _userService.Login(email, password);
            if (result?.Data == null)
            {
                _notify.Error(result.Message);
                return RedirectToAction("Index");

            }
            var encUserId = Guid.NewGuid().ToString().Replace("-", "");
                    CookieOptions cookie = new CookieOptions { Expires = DateTime.Now.AddDays(1) };
                    Response.Cookies.Append("user", encUserId, cookie);
                    if (!_redisClient.ContainsKey(string.Concat("user:", encUserId)))
                    {
                        _redisClient.Add(string.Concat("user:", encUserId), result.Data);
                    }
                    _notify.Success("Kullanıcı Girişi Başarılı" + SessionHelper.DefaultSession.FirstName);
            
            return RedirectToAction("Index");

        }

        public IActionResult LogOut()
        {
            _redisClient.Remove(string.Concat("user:", _contextAccessor.HttpContext?.Request.Cookies["user"]));
            Response.Cookies.Delete(_contextAccessor.HttpContext?.Request.Cookies["user"]);
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

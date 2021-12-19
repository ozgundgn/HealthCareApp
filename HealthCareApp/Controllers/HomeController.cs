using HealthCareApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreHero.ToastNotification.Abstractions;
using Entity.Models;
using Microsoft.AspNetCore.Http;
using Models.Application;
using Models.Home;
using Nancy.Json;
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
        private readonly IApplicationService _applicationService;
    public HomeController(ILogger<HomeController> logger, IUserService userService,IApplicationService applicationService, INotyfService notifyService, IRedisClient redisClient, IHttpContextAccessor contextAccessor)
        {
            _userService = userService;
            _logger = logger;
            _notify = notifyService;
            _redisClient = redisClient;
            _contextAccessor = contextAccessor;
            _applicationService = applicationService;
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
        public IActionResult RegisterScreen()
        {
	        RegisterModel model = new RegisterModel();
	        model.CityList = _applicationService.GetCityList().Data;
          return View("MemberRegister",model);
        }     
        public IActionResult Register(UserSaveRequestModel usermodel)
        {
          User user=new User()
          {
	          Address = new List<Address>
	          { new Address {DistrictId = usermodel.DistrictId, CityId = usermodel.CityId,AddressDesc = usermodel.AddressDesc}},
            Birthday = usermodel.Birthday,
            BloodGroup = usermodel.BloodGroup,
            CivilStatus = usermodel.CivilStatus,
            EducationStatus = usermodel.EducationStatus,
            FatherName = usermodel.FatherName,
            FirstName = usermodel.FirstName,
            Gender = usermodel.Gender,
            Height = usermodel.Height,
            IdentityNumber = usermodel.IdentityNumber,
            LastName = usermodel.LastName,
            Mail = usermodel.Mail,
            MotherName = usermodel.MotherName,
            Password = usermodel.Password,
            Phone = usermodel.Phone,
            Rh = usermodel.Rh,
            UserType = usermodel.UserType,
            Weight = usermodel.Weight
          };

					 var result = _userService.Add(user);
					 if (result.Success)
					 {
						 _notify.Success("Kullanıcı Kayıt İşlemi Başarılı");
					 }
					 else
					 {
						 _notify.Error("Kullanıcı Kayıt İşlemi Başarısız");
					 }
					 return RedirectToAction("Index");
    }
    public IActionResult DistrictList(int id)
        {
	        return Json(new
	        {
		        result = true,//result.Success,
		        message = "İşlem Başarılı",
		        Object = _applicationService.GetDistrictList(id).Data,// result.Object.Id
	        });
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

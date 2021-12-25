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
using Core.Extentions;
using Entity.Models;
using Microsoft.AspNetCore.Http;
using Models.Application;
using Models.Enums;
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
        public HomeController(ILogger<HomeController> logger, IUserService userService, IApplicationService applicationService, INotyfService notifyService, IRedisClient redisClient, IHttpContextAccessor contextAccessor)
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
                return RedirectToAction("DonorApplicationList", "Application");
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

            return RedirectToAction("UserApplicationInformList", "Application");

        }

        public IActionResult LogOut()
        {
            _redisClient.Remove(string.Concat("user:", _contextAccessor.HttpContext?.Request.Cookies["user"]));
            Response.Cookies.Delete(_contextAccessor.HttpContext?.Request.Cookies["user"]);
            return RedirectToAction("Index");
        }
        public IActionResult RegisterUpdateScreen()
        {
	        var userAddresInformation = _userService.GetUserAddress(SessionHelper.DefaultSession.Id).Data;
          RegisterModel model = new RegisterModel()
	        {
            AddressDesc = userAddresInformation.AddressDesc,
            CityId = userAddresInformation.CityId,
            DistrictId = userAddresInformation.DistrictId,
            FatherName = SessionHelper.DefaultSession.FatherName,
            FirstName = SessionHelper.DefaultSession.FirstName,
            Height = SessionHelper.DefaultSession.Height,
            Birthday = SessionHelper.DefaultSession.Birthday,
            CityList = _applicationService.GetCityList().Data,
            Gender = SessionHelper.DefaultSession.Gender,
            DistrictList = _applicationService.GetDistrictList(userAddresInformation.CityId).Data,
            LastName = SessionHelper.DefaultSession.LastName,
            UserType = SessionHelper.DefaultSession.UserType,
            IdentityNumber = SessionHelper.DefaultSession.IdentityNumber,
            MotherName = SessionHelper.DefaultSession.MotherName,
            Weight =  SessionHelper.DefaultSession.Weight,
            Phone =  SessionHelper.DefaultSession.Phone,
            Mail =  SessionHelper.DefaultSession.Mail,
            EducationStatusList = Enum.GetValues(typeof(EducationStatusEnum)).Cast<EducationStatusEnum>(),
            BloodGroupList = Enum.GetValues(typeof(BloodGroupEnum)).Cast<BloodGroupEnum>(),
            CivilStatusList = Enum.GetValues(typeof(CivilStatusEnum)).Cast<CivilStatusEnum>(),
            RhList = Enum.GetValues(typeof(RhEnum)).Cast<RhEnum>(),
            BloodGroup = SessionHelper.DefaultSession.BloodGroup,
            CivilStatus = SessionHelper.DefaultSession.CivilStatus,
            EducationStatus = SessionHelper.DefaultSession.EducationStatus,
            Rh = SessionHelper.DefaultSession.Rh,
            TitleHead = "KULLANICI BİLGİLERİ DÜZENLEME FORMU",
            TitleButton = "Güncelle",
            Id = SessionHelper.DefaultSession.Id
          };

	        return View("MemberRegister", model);
			  }  
        public IActionResult RegisterScreen()
        {
	        RegisterModel model = new RegisterModel()
	        {
            CityList = _applicationService.GetCityList().Data,
            EducationStatusList = Enum.GetValues(typeof(EducationStatusEnum)).Cast<EducationStatusEnum>(),
            BloodGroupList = Enum.GetValues(typeof(BloodGroupEnum)).Cast<BloodGroupEnum>(),
            CivilStatusList = Enum.GetValues(typeof(CivilStatusEnum)).Cast<CivilStatusEnum>(),
            RhList = Enum.GetValues(typeof(RhEnum)).Cast<RhEnum>(),
            TitleHead = "KULLANICI KAYIT FORMU",
            TitleButton = "Kaydet"
          };

          return View("MemberRegister",model);
        }     
        public IActionResult Register(UserSaveRequestModel usermodel)
        {
	        RegisterModel model = new RegisterModel();
	        usermodel.MapTo(model);
	        model.CityList = _applicationService.GetCityList().Data;
	        model.EducationStatusList = Enum.GetValues(typeof(EducationStatusEnum)).Cast<EducationStatusEnum>();
	        model.EducationStatusList = Enum.GetValues(typeof(EducationStatusEnum)).Cast<EducationStatusEnum>();
	        model.BloodGroupList = Enum.GetValues(typeof(BloodGroupEnum)).Cast<BloodGroupEnum>();
	        model.CivilStatusList = Enum.GetValues(typeof(CivilStatusEnum)).Cast<CivilStatusEnum>();
	        model.DistrictList = _applicationService.GetDistrictList(usermodel.CityId).Data;
	        model.RhList = Enum.GetValues(typeof(RhEnum)).Cast<RhEnum>();
	        model.TitleButton = "Kaydet";
	        model.TitleHead = "KULLANICI KAYIT FORMU";
		      if (usermodel.Password!= usermodel.RPassword)
		      {
						_notify.Warning("Lütfen şifrenizi kontrol ediniz");
						return View("MemberRegister", model);
					}
					User user = new User()
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
	          Weight = usermodel.Weight,
            Id = usermodel.Id
          };
				  if (usermodel.Id != 0)
          {
					 var result = _userService.Update(user);
					 if (result.Success)
					 {
						 _notify.Success("Kullanıcı Güncelleme İşlemi Başarılı");
					 }
					 else
					 {
						 _notify.Error("Güncelleme İşlemi Başarısız");
					 }
					}
					else
          {
	         bool isIdentityNumber= _userService.UserIdentityNumberControl(usermodel.IdentityNumber);

	         if (isIdentityNumber)
	         {
          _notify.Error("Sistemde TC numarası zaten kayıtlı");
					 return View("MemberRegister", model);
					 }

					 var result = _userService.Add(user);
					 if (result.Success)
					 {
						 _notify.Success("Kullanıcı Kayıt İşlemi Başarılı");
					 }
					 else
					 {
						 _notify.Error("Kayıt İşlemi Başarısız");
					 }
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
        [HttpPost]
        public IActionResult SendMail(string message, int id,bool donorPage)
        {
            var result = _userService.SendMailToUser(message, id);
            if (result.Success)
            {
                _notify.Success("Mesajınız gönderildi.");
            }else
            {
                _notify.Error("Mesajınız gönderilirken bir hata oluştu.");
            }

            if (donorPage)
            {
                return RedirectToAction("DonorApplicationList", "Application");
            }
            return RedirectToAction("SickApplicationList", "Application");
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

using System;
using System.Collections.Generic;
using HealthCareApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.IO;
using AspNetCoreHero.ToastNotification.Abstractions;
using HealthCareApp.Helpers;
using Models.Application;
using Service.Abstract;
using Nancy.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Repository.Helpers;
using ServiceStack.Text;

namespace HealthCareApp.Controllers
{
    public class ApplicationController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IApplicationService _applicationService;
        private readonly INotyfService _notify;
        public ApplicationController(ILogger<HomeController> logger, IApplicationService applicationService,INotyfService notify)
        {
            _applicationService = applicationService;
            _logger = logger;
            _notify = notify;
        }

        public IActionResult SickApplicationList()
        {
            return View(_applicationService.GetSickApplicationList().Data);
        }

      

        public IActionResult DonorApplicationList()
        {
            return View();
        }

        public JsonResult GetDonorList(DonorAplicationRequestModel model)
        {
         
            return ActionResultHelper.GridStoreLoad(_applicationService.GetDonorApplicationList(model).Data);
        }
        public IActionResult AplicationCreate()
        {
            ApplicationCreateViewModel model =new ApplicationCreateViewModel();
               model.QuestionsList = _applicationService.GetQuestionList().Data;
            return View(model);
        }
        [HttpPost]
        public IActionResult ApplicationSave([FromForm]ApplicationSaveRequestModel model)
        {
            model.QuestionResultList= new JavaScriptSerializer().Deserialize<List<QuestionResultList>>(model.QuestionResultListString);

            var uploads = Path.Combine(string.Concat( @"C:\HealtyCareApp\"));
            var dosyaAdi = model.ReportResult.FileName.Split(".");
            var path = dosyaAdi[1];
            model.ReportName = dosyaAdi[0];
            var dosyaKayitId = _applicationService.SetApplication(model);
            var filePath =
                Path.Combine(uploads, string.Concat(dosyaKayitId.Data.Id, ".", path)); //dosya kayiıt id döncek
            using (var dosya = new FileStream(filePath, FileMode.Create))
            {
                model.ReportResult.CopyTo(dosya);
            }

            return Json(new
            {
                result = true,
                message = "İşlem Başarılı",
               
            });
           
        }
    
        public IActionResult ApppFileView(int id)
        {
            var uploads = Path.Combine(string.Concat(@"C:\HealtyCareApp\"));
            var filePath = Path.Combine(uploads, string.Concat(id ,".", "pdf"));

               byte[] bytes = System.IO.File.ReadAllBytes(filePath);
               var _dosya = string.Concat("data:application/pdf;base64,", Convert.ToBase64String(bytes));
            return Json(new
            {
                result = true,
                message = "İşlem Başarılı",
                Object =_dosya
            });
        }
       
        public IActionResult UserApplicationInformList()
        {
          var appList= _applicationService.GetUserApplicationInformList().Data;
          return View(appList);
        }
        //[HttpPost]
        //public IActionResult AppDonorList()
        //{
         
        //    return Json(new
        //    {
        //        result = true,
        //        message = "İşlem Başarılı",
        //        Object = _applicationService.GetDonorApplicationList().Data
        //    });
        //}
        [HttpPost]
        public IActionResult StateSave(StateSaveRequestModel model)
        {
            var result = _applicationService.SetApplicationState(model);
            if(result.Success)
            _notify.Success("Başvuru Durumu Güncellendi.");
            else _notify.Success("Başvuru Durumu Güncellenemedi.");
            return RedirectToAction("UserApplicationInformList", "Application");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

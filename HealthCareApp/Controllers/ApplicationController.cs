using System;
using System.Collections.Generic;
using HealthCareApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.IO;
using Models.Application;
using Service.Abstract;
using Nancy.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ServiceStack.Text;

namespace HealthCareApp.Controllers
{
    public class ApplicationController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IApplicationService _applicationService;
        public ApplicationController(ILogger<HomeController> logger, IApplicationService applicationService)
        {
            _applicationService = applicationService;
            _logger = logger;
        }

        public IActionResult SickApplicationList()
        {
            return View(_applicationService.GetSickApplicationList().Data);
        }

        public IActionResult DonorApplicationList()
        {
            return View(_applicationService.GetDonorApplicationList().Data);
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
            //if (model.ReportResult != null && model.ReportResult.Length > 0)
            //{
            //    using (var ms = new MemoryStream())
            //    {
            //        model.ReportResult.CopyTo(ms);
            //        model.ReportResultByte = ms.ToArray();
            //    }
            //}


            //var result = _applicationService.GenelTanimlamalarService.SirtlikTasarimKaydet(model);
            return Json(new
            {
                result = true,//result.Success,
                message = "İşlem Başarılı",
                //Object =null,// result.Object.Id
            });
            //ApplicationCreateViewModel model = new ApplicationCreateViewModel();
            //model.QuestionsList = _applicationService.GetQuestionList().Data;
            //return View(model);
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

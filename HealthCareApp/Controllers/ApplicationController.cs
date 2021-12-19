using HealthCareApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.IO;
using Models.Application;
using Service.Abstract;
using Nancy.Json;

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
            var ss= new JavaScriptSerializer().Serialize(model.QuestionResultListString);
            if (model.ReportResult != null && model.ReportResult.Length > 0)
            {
                using (var ms = new MemoryStream())
                {
                    model.ReportResult.CopyTo(ms);
                    model.ReportResultByte = ms.ToArray();
                }
            }
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

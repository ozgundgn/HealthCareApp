using HealthCareApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Entity.Models;
using Models.Application;
using Service.Abstract;

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
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

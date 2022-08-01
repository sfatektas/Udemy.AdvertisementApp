using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Udemy.Adversitement.UI.Controllers.Extensions;
using Udemy.AdvertisementApp.Bussines.Interfaces;
using Udemy.AdvertisementApp.Dtos.ProvidedServicesDtos;

namespace Udemy.Adversitement.UI.Controllers.Home
{
    public class HomeController : Controller
    {
        private readonly IProvidedServiceService _providedService;
        private readonly IAdvertisementService _advertisementService;

        public HomeController(IProvidedServiceService providedService, IAdvertisementService advertisementService)
        {
            _providedService = providedService;
            _advertisementService = advertisementService;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _providedService.GetAllAsync();
            return this.ResponseView(response);
        }
        public async Task<IActionResult> HumanResource()
        {
            var response = await _advertisementService.GetAllActiveAsync();
            return View(response.Data);
        }
    }
}

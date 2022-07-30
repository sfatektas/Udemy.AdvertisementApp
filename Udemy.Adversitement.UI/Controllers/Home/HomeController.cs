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

        public HomeController(IProvidedServiceService providedService)
        {
            _providedService = providedService;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _providedService.GetAllAsync();
            return this.ResponseView(response);
        }
    }
}

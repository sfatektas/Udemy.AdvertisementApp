using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Udemy.Adversitement.Common;
using Udemy.Adversitement.UI.Controllers.Extensions;
using Udemy.AdversitementApp.Common.Enums;
using Udemy.AdvertisementApp.Bussines.Interfaces;
using Udemy.AdvertisementApp.Dtos.AdvertisementAppUserDtos;
using Udemy.AdvertisementApp.Dtos.AppUserDtos;
using Udemy.AdvertisementApp.Dtos.MilitaryStatusDtos;

namespace Udemy.Adversitement.UI.Controllers.Advertisement
{
    [Authorize]
    public class AdvertisementController : Controller
    {
        private readonly IAppUserService _appUserService;

        public AdvertisementController(IAppUserService appUserService)
        {
            _appUserService = appUserService;
        }

        public async Task<IActionResult> Apply(int advertisementId)
        {
            //Authorize edilmiş olan userın Identifire özelliğini çekiyoruz.

            var userId = int.Parse(User.Claims.FirstOrDefault(x=>x.Type == ClaimTypes.NameIdentifier).Value);
            var userResponse = await _appUserService.GetByIdAsync<AppUserListDto>(userId);

            //View katmanında kullanıcıya erkek veya kız olma durumuna göre 
            //kullanıcıya farklı form viewı gösterilecek

            ViewBag.GenderId = userResponse.Data.GenderId;

            var list = new List<MilitaryStatusListDto>();

            foreach (var item in Enum.GetValues(typeof(MilitaryStatusType)))
            {
                list.Add(new() { 
                Id = (int)item,
                Defination = Enum.GetName(typeof(MilitaryStatusType),(int)item)
                });
            }
            var selectlist = new SelectList(list, "Id", "Defination");

            ViewBag.MilitaryStatus = selectlist;

            if (userResponse.ResponseType == ResponseType.Success)
            {
                return View(new AdvertisementAppUserCreateDto()
                {
                    AdvertisementId = advertisementId,
                    AppUserId = userResponse.Data.Id,
                });
                //return this.ResponseView(userResponse);
            }
            //yok ise SignIn bölümüne kendini aktar.
            return RedirectToAction("SignIn", "Account");
        }
        [HttpPost]
        public async Task<IActionResult> Apply(AdvertisementAppUserCreateDto dto)
        {
            return View();
        }
    }
}

using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Udemy.Adversitement.UI.Controllers.Extensions;
using Udemy.Adversitement.UI.Models;
using Udemy.AdvertisementApp.Bussines.Interfaces;
using Udemy.AdvertisementApp.Dtos.AppUserDtos;

namespace Udemy.Adversitement.UI.Controllers.Account
{
    public class AccountController : Controller
    {
        private readonly IGenderService _genderService;
        private readonly IAppUserService _appUserService;
        private readonly IValidator<UserCreateModel> _usercreatevalidator;
        private readonly IMapper _mapper;

        public AccountController(IGenderService genderService, IValidator<UserCreateModel> usercreatevalidator, IMapper mapper, IAppUserService appUserService)
        {
            _genderService = genderService;
            _usercreatevalidator = usercreatevalidator;
            _mapper = mapper;
            _appUserService = appUserService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> SignUp()
        {
            var response = await _genderService.GetAllAsync();
            return View(new UserCreateModel
            {
                Genders = new SelectList(response.Data, "Id", "Defination")
            });
        }
        [HttpPost]
        public async Task<IActionResult> SignUp(UserCreateModel model)
        {
            var result = _usercreatevalidator.Validate(model);
            if (result.IsValid)
            {
                var dto = _mapper.Map<AppUserCreateDto>(model);
                var createResponse = await _appUserService.CreateAsync(dto);
                return this.ResponseRedirectAction(createResponse,"Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                var response = await _genderService.GetAllAsync();
                model.Genders = new SelectList(response.Data, "Id", "Defination", model.GenderId);
                return View(model);
            }

        }
    }
}

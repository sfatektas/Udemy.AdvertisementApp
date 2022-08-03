using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
        private readonly IValidator<AppUserLoginDto> _loginvalidator;
        private readonly IMapper _mapper;

        public AccountController(IGenderService genderService, IValidator<UserCreateModel> usercreatevalidator, IMapper mapper, IAppUserService appUserService, IValidator<AppUserLoginDto> loginvalidator)
        {
            _genderService = genderService;
            _usercreatevalidator = usercreatevalidator;
            _mapper = mapper;
            _appUserService = appUserService;
            _loginvalidator = loginvalidator;
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
                var createResponse = await _appUserService.CreateUserWithRoleAsync(dto,1);
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
        public IActionResult SignIn()
        {
            return View(new AppUserLoginDto());
        }
        [HttpPost]
        public async Task <IActionResult> SignIn(AppUserLoginDto dto)
        {
            var result = await _loginvalidator.ValidateAsync(dto);
            if (result.IsValid)
            {
                var user = await _appUserService.CheckUser(dto);
                if (user != null)
                {
                    var rolesResponse = await _appUserService.GetRolesByUserIdAsync(user.Data.Id);
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, user.Data.Firstname),
                        new Claim(ClaimTypes.NameIdentifier, user.Data.Id.ToString()),
                    };
                    foreach (var role in rolesResponse.Data)
                    {
                        claims.Add(new(ClaimTypes.Role, role.ToString()));
                    }

                    var claimsIdentity = new ClaimsIdentity(
                        claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    var authProperties = new AuthenticationProperties
                    {
                        //AllowRefresh = <bool>,
                        // Refreshing the authentication session should be allowed.

                        //ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
                        // The time at which the authentication ticket expires. A 
                        // value set here overrides the ExpireTimeSpan option of 
                        // CookieAuthenticationOptions set with AddCookie.

                        IsPersistent = true,
                        // Whether the authentication session is persisted across 
                        // multiple requests. When used with cookies, controls
                        // whether the cookie's lifetime is absolute (matching the
                        // lifetime of the authentication ticket) or session-based.

                        //IssuedUtc = <DateTimeOffset>,
                        // The time at which the authentication ticket was issued.

                        //RedirectUri = <string>
                        // The full path or absolute URI to be used as an http 
                        // redirect response value.
                    };

                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity),
                        authProperties);
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", user.Message);
                return View(dto);
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return View(dto);
            }

        }
    }
}

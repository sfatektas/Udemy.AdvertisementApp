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
                var createResponse = await _appUserService.CreateUserWithRoleAsync(dto, 1);
                return this.ResponseRedirectAction(createResponse, "Index");
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
        public IActionResult SignIn(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View(new AppUserLoginDto());
        }
        [HttpPost]
        public async Task<IActionResult> SignIn(AppUserLoginDto dto ,string returnUrl)
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
                        claims.Add(new(ClaimTypes.Role, role.Defination.ToString()));
                    }

                    var claimsIdentity = new ClaimsIdentity(
                        claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    var authProperties = new AuthenticationProperties
                    {
                        IsPersistent = true,
                        // Whether the authentication session is persisted across 
                        // multiple requests. When used with cookies, controls
                        // whether the cookie's lifetime is absolute (matching the
                        // lifetime of the authentication ticket) or session-based.
                    };

                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity),
                        authProperties);
                    if (returnUrl == "" || returnUrl == null)
                        return RedirectToAction("Index", "Home");
                    else
                        return Redirect(returnUrl);

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
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(
    CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Index","Home");
        }
        public IActionResult Forbidden()
        {
            return View();
        }
    }
}

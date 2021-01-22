using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TornadoToDo.Business.Interfaces;
using TornadoToDo.Entities.Concrete;
using TornadoToDo.Web.Models;

namespace TornadoToDo.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAppUserService _appUserService;
        private readonly IHttpContextAccessor _accessor;
        public HomeController(IHttpContextAccessor accessor, IAppUserService appUserService)
        {
            _accessor = accessor;
            _appUserService = appUserService;
        }

        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> SignIn(SignInModel model)
        {
            var user = await _appUserService.GetUserByEmail(model.Email);
            if (user != null && user.Password == model.Password && user.Email == model.Email)
            {
                _accessor.HttpContext.Session.SetString("id", user.Id.ToString());
                _accessor.HttpContext.Session.SetString("username", user.Username);
                return RedirectToAction("Index", "Board");
            }
            else
            {
                return View(model);
            }
        }

        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> SignUp(SignUpModel model)
        {
            await _appUserService.AddAsync(new AppUser
            {
                Email = model.Email,
                Password = model.Password,
                Username = model.Username
            });
            return RedirectToAction("SignIn", "Home");
        }


        public IActionResult LogOut()
        {
            _accessor.HttpContext.Session.Remove("id");
            _accessor.HttpContext.Session.Remove("username");

            return RedirectToAction("SignIn", "Home");
        }
    }
}

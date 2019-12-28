using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Database;
using Ecommerce.Helper;
using Ecommerce.Servicies.Interface;
using Ecommerce.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Ecommerce.Controllers
{
    public class UserController : Controller
    {
      
        private readonly IUserService _userService;

        private readonly UserManager<ApplicationUser> _userManager;

        private readonly Servicies.Interface.IEmailSender _emailSender;

        private readonly SignInManager<ApplicationUser> _signInManager;

        public UserController(IUserService  userService, UserManager<ApplicationUser> userManager, Servicies.Interface.IEmailSender emailSender, SignInManager<ApplicationUser> signInManager
           )
        {
            _userService = userService;

            _userManager = userManager;

            _emailSender = emailSender;

            _signInManager = signInManager;
        }

        public async Task<IActionResult> Index()
        {
            var result = _userService.GetAllInformation();
            return View(result);
        }


        public async Task<IActionResult> AddUser()
        {
            UserViewModel user = new UserViewModel();
            user.Data = _userService.GetAllRoleInformation().Select(x=> new SelectListItem {Text = x.Name, Value = x.Name.ToString()}).ToList();


            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(UserViewModel model)
        {
           
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email, AddressLine1 = model.AddressLine1, AddressLine2 = model.AddressLine2, City = model.City, State = model.State, ContactNumber = model.ContactNumber, IsActive = true };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {

                    await _userManager.AddToRoleAsync(user, model.Role);

                  

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    var callbackUrl = Url.EmailConfirmationLink(user.Id, code, Request.Scheme);
                    await _emailSender.SendEmailConfirmationAsync(model.Email, callbackUrl);

                    await _signInManager.SignInAsync(user, isPersistent: false);

                    return RedirectToAction("Index");
                }
                
            }

            model.Data = _userService.GetAllRoleInformation().Select(x => new SelectListItem { Text = x.Name, Value = x.Name.ToString() }).ToList();

            // If we got this far, something failed, redisplay form
            return View(model);
          
        }


        public IActionResult Delete(string Id)
        {
            _userService.RemoveUserInformation(Id);

            return RedirectToAction("Index");
        }

        public IActionResult EditUnit(string Id)
        {
          var user =  _userService.GetUserInformation(Id);

            user.Data = _userService.GetAllRoleInformation().Select(x => new SelectListItem { Text = x.Name, Value = x.Name.ToString() }).ToList();

            return View("AddUser", user);
        }

        [HttpPost]
        public IActionResult EditUnit(UserViewModel unitViewModel)
        {
            if (ModelState.IsValid)
            {
                
                    _userService.UpdateUserInformation(unitViewModel, unitViewModel.RoleId);
                
               

                return RedirectToAction("Index");
            }

            unitViewModel.Data = _userService.GetAllRoleInformation().Select(x => new SelectListItem { Text = x.Name, Value = x.Name.ToString() }).ToList();

            return View(unitViewModel);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Database;
using Ecommerce.Servicies.Interface;
using Ecommerce.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers
{
    public class UnitController : Controller
    {
        private IUnitService UnitService { get; set; }

       


     

        public UnitController(IUnitService unitService, UserManager<ApplicationUser> userManager)
        {
            UnitService = unitService;
        }
        public IActionResult Index()
        {
            var result = UnitService.GetUnitInformation();
            return View(result);
        }

        [HttpGet]
        public IActionResult AddUnit()
        {

            return View();
        }

        [HttpPost]
        public IActionResult AddUnit(UnitViewModel unitViewModel)
        {
            if (ModelState.IsValid)
            {
                if (unitViewModel.Id > 0)
                {
                    UnitService.UpdateUnit(unitViewModel);
                }
                else
                {
                    UnitService.AddUnit(unitViewModel);
                }

                return RedirectToAction("Index");
            }

            return View(unitViewModel);
        }

        public IActionResult Delete(int Id)
        {
            UnitService.RemoveUnit(Id);

            return RedirectToAction("Index");
        }

        public IActionResult EditUnit(int Id)
        {
            var result = UnitService.GetUnitInformation(Id);

            return View("AddUnit", result);
        }

        [HttpPost]
        public IActionResult EditUnit(UnitViewModel unitViewModel)
        {
            if (ModelState.IsValid)
            {
                if (unitViewModel.Id > 0)
                {
                    UnitService.UpdateUnit(unitViewModel);
                }
                else
                {
                    UnitService.AddUnit(unitViewModel);
                }

                return RedirectToAction("Index");
            }

            return View(unitViewModel);
        }
    }
}
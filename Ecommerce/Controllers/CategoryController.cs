using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Servicies.Interface;
using Ecommerce.Servicies.Manager;
using Ecommerce.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Ecommerce.Controllers
{
    public class CategoryController : Controller
    {
        private ICategoryService CategoryService { get; set; }

        public CategoryController(ICategoryService category)
        {
            CategoryService = category;
        }
        public IActionResult Index()
        {
            var result = CategoryService.GetCategoryInformation();
            return View(result);
        }

        [HttpGet]
        public IActionResult AddCategory()
        {
          
            return View();
        }

        [HttpPost]
        public IActionResult AddCategory(CategoryVieWModel categoryVieWModel)
        {
            if (ModelState.IsValid)
            {
                if (categoryVieWModel.Id > 0)
                {
                    CategoryService.UpdateCategory(categoryVieWModel);
                }
                else
                {
                    CategoryService.AddCategory(categoryVieWModel);
                }
                
                return RedirectToAction("Index");
            }
          
            return View(categoryVieWModel);
        }

        public IActionResult Delete(int Id)
        {
            CategoryService.RemoveCategory(Id);

            return RedirectToAction("Index");
        }

        public IActionResult EditCategory(int Id)
        {
           var result = CategoryService.GetCategoryInformation(Id);

            return View("AddCategory", result);
        }

        [HttpPost]
        public IActionResult EditCategory(CategoryVieWModel categoryVieWModel)
        {
            if (ModelState.IsValid)
            {
                if (categoryVieWModel.Id > 0)
                {
                    CategoryService.UpdateCategory(categoryVieWModel);
                }
                else
                {
                    CategoryService.AddCategory(categoryVieWModel);
                }

                return RedirectToAction("Index");
            }

            return View(categoryVieWModel);
        }







    }
}
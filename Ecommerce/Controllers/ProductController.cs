using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Servicies.Interface;
using Ecommerce.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        private IProductService ProductService { get; set; }
        public ProductController(IProductService productService)
        {
            ProductService = productService;
        }
        public ActionResult Index()
        {
            var result = ProductService.GetProductInformation();
            return View(result);

        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductViewModel productviewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (productviewModel.Id > 0)
                    {
                        ProductService.UpdateProduct(productviewModel);
                    }
                    else
                    {
                        ProductService.AddProduct(productviewModel);
                    }

                    return RedirectToAction("Index");
                }

                return View(productviewModel);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            var result = ProductService.GetProductInformation(id);
            return View(result);
        }

        // POST: Product/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductViewModel productviewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (productviewModel.Id > 0)
                    {
                        ProductService.UpdateProduct(productviewModel);
                    }
                    else
                    {
                        ProductService.AddProduct(productviewModel);
                    }

                    return RedirectToAction("Index");
                }

                return View(productviewModel);
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            ProductService.RemoveProduct(id);
            return RedirectToAction("Index");
        }

        // POST: Product/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
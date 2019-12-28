using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.MainMenu;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers
{
    
    [Authorize(Roles = MenuItems.AdminRole)]
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wed_ShopGaming.Models;

namespace Wed_ShopGaming.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext context;
        public HomeController()
        {
            context = ApplicationDbContext.Create();
        }
        public ActionResult Index()
        {
            return View();
        }
       
    }
}
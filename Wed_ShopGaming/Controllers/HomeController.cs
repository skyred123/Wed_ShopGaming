using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wed_ShopGaming.Models;
using PagedList;

namespace Wed_ShopGaming.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext context;
        public HomeController()
        {
            context = ApplicationDbContext.Create();
        }
        public ActionResult Index(int? page)
        {
            if (page == null) page = 1;
            var sanPham = context.SanPhams.ToList();
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(sanPham.ToPagedList(pageNumber, pageSize)); ;
        }
       
    }
}
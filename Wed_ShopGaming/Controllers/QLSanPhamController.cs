using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wed_ShopGaming.Models;
using Wed_ShopGaming.Models.Entity;
using Wed_ShopGaming.ViewModels;

namespace Wed_ShopGaming.Controllers
{
    public class QLSanPhamController : Controller
    {
        // GET: QLSanPham
        public ActionResult Index_LoaiSP()
        {
            List<LoaiSP> list = Sevices.LoaiSPSevice().GetListLoaiSP();
            LoaiSPViewModel model = new LoaiSPViewModel()
            {
                Loais = list,
            };
            return View(model);
        }
    }
}
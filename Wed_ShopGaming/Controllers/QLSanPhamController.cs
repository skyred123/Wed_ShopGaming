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


        [HttpPost]
        public ActionResult Index_LoaiSP(LoaiSPViewModel entity)
        {
            if (entity.Name != null)
            {
                LoaiSP loaiSP = new LoaiSP();
                loaiSP.Id = Guid.NewGuid();
                loaiSP.Name = entity.Name;
                Sevices._dbContext.LoaiSPs.Add(loaiSP);
                Sevices._dbContext.SaveChanges();
            }
            return RedirectToAction("Index_LoaiSP", "QLSanPham");
        }
    }
}
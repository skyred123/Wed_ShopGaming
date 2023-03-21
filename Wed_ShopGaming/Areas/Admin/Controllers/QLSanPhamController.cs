using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wed_ShopGaming.Models;
using Wed_ShopGaming.Models.Entity;
using Wed_ShopGaming.ViewModels;

namespace Wed_ShopGaming.Areas.Admin.Controllers
{
    [Authorize(Roles ="Admin")]
    public class QLSanPhamController : Controller
    {
        ApplicationDbContext context;
        public QLSanPhamController(){
            context = ApplicationDbContext.Create();
        }
        // GET: QLSanPham
        public ActionResult Index_LoaiSP()
        {
            List<LoaiSP> list = context.LoaiSPs.ToList();
            LoaiSPViewModel model = new LoaiSPViewModel()
            {
                Loais = list,
            };
            return View(model);
        }
        [HttpPost]
        public ActionResult Create_LoaiSP(LoaiSPViewModel entity)
        {
            if (entity.Name != null)
            {
                LoaiSP loaiSP = new LoaiSP();
                loaiSP.Id = Guid.NewGuid();
                loaiSP.Name = entity.Name;
                context.LoaiSPs.Add(loaiSP);
                context.SaveChanges();
            }
            return RedirectToAction("Index_LoaiSP", "QLSanPham",new { area = "Admin" });
        }
        public ActionResult Delete_LoaiSP(String id)
        {
            if (id != null)
            {
                var item = Guid.Parse(id);
                LoaiSP loaiSP = (context.LoaiSPs.ToList()).FirstOrDefault(e => e.Id == item);
                if (loaiSP != null)
                {
                    context.LoaiSPs.Remove(loaiSP);
                    context.SaveChanges();
                    return RedirectToAction("Index_LoaiSP", "QLSanPham", new { area = "Admin" });
                }
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
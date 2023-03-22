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
    //[Authorize(Roles ="Admin")]
    public class QLSanPhamController : Controller
    {
        ApplicationDbContext context;
        public QLSanPhamController(){
            context = ApplicationDbContext.Create();
        }
        // GET: QLSanPham
        #region Quan ly loai san pham
        public ActionResult LoaiSP()
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
            return RedirectToAction("LoaiSP", "QLSanPham",new { area = "Admin" });
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
                    return RedirectToAction("LoaiSP", "QLSanPham", new { area = "Admin" });
                }
            }
            return RedirectToAction("Index", "Home");
        }

        #endregion

        #region Quan ly thong so san pham
        public ActionResult ThongSoSP(string id)
        {
            List<ThongSo> thongso = null;
            if (id == null)
            {
                thongso = context.ThongSos.ToList();
            }
            else
            {
                thongso = context.LoaiSPs.ToList().FirstOrDefault(e=>e.Id == Guid.Parse(id)).ThongSos.ToList();
            }
            ThongSoSPViewModel model = new ThongSoSPViewModel();
            model.listThongSos = thongso;
            model.listloaiSPs = context.LoaiSPs.ToList();
            return View(model);
        }
        [HttpPost]
        public ActionResult Create_ThongSoSP(ThongSoSPViewModel model)
        {
            if (model != null)
            {
                ThongSo thongSo = new ThongSo();
                thongSo.Id = Guid.NewGuid();
                thongSo.Name = model.Name;
                thongSo.IdLoaiSP = Guid.Parse(model.IdLoai);
                context.ThongSos.Add(thongSo);
                context.SaveChanges();
            }
            return RedirectToAction("ThongSoSP", "QLSanPham", new { area = "Admin" });
        }
        public ActionResult Delete_ThongSoSP(String id)
        {
            if (id != null)
            {
                var item = Guid.Parse(id);
                ThongSo thongSo = (context.ThongSos.ToList()).FirstOrDefault(e => e.Id == item);
                if (thongSo != null)
                {
                    context.ThongSos.Remove(thongSo);
                    context.SaveChanges();
                    return RedirectToAction("ThongSoSP", "QLSanPham", new { area = "Admin" });
                }
            }
            return RedirectToAction("Index", "Home");
        }
        #endregion

        #region Quan ly hang san pham
        /*public ActionResult Hang    SP(string id)
        {
            List<ThongSo> thongso = null;
            ThongSoSPViewModel model = new ThongSoSPViewModel();
            return View(model);
        }*/
        #endregion
    }
}
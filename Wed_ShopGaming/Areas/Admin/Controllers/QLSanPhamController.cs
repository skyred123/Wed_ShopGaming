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
        #region Quan ly loai san pham
        public ActionResult LoaiLK()
        {
            List<LoaiLK> list = context.LoaiLKs.ToList();
            LoaiLKViewModel model = new LoaiLKViewModel()
            {
                Loais = list,
            };
            return View(model);
        }
        [HttpPost]
        public ActionResult Create_LoaiLK(LoaiLKViewModel entity)
        {
            if (entity.Name != null)
            {
                LoaiLK loaiSP = new LoaiLK();
                loaiSP.Id = Guid.NewGuid().ToString();
                loaiSP.Name = entity.Name;
                context.LoaiLKs.Add(loaiSP);
                context.SaveChanges();
            }
            return RedirectToAction("LoaiLK", "QLSanPham",new { area = "Admin" });
        }
        public ActionResult Delete_LoaiLK(String id)
        {
            if (id != null)
            {
                LoaiLK loaiSP = (context.LoaiLKs.ToList()).FirstOrDefault(e => e.Id == id);
                if (loaiSP != null)
                {
                    context.LoaiLKs.Remove(loaiSP);
                    context.SaveChanges();
                    return RedirectToAction("LoaiLK", "QLSanPham", new { area = "Admin" });
                }
            }
            return RedirectToAction("Index", "Home");
        }

        #endregion

        #region Quan ly loai san pham
        public ActionResult LoaiMT()
        {
            List<LoaiMT> list = context.LoaiMTs.ToList();
            LoaiMTViewModel model = new LoaiMTViewModel()
            {
                Loais = list,
            };
            return View(model);
        }
        [HttpPost]
        public ActionResult Create_LoaiMT(LoaiMTViewModel entity)
        {
            if (entity.Name != null)
            {
                LoaiMT loaiSP = new LoaiMT();
                loaiSP.Id = Guid.NewGuid().ToString();
                loaiSP.Name = entity.Name;
                context.LoaiMTs.Add(loaiSP);
                context.SaveChanges();
            }
            return RedirectToAction("LoaiMT", "QLSanPham", new { area = "Admin" });
        }
        public ActionResult Delete_LoaiMT(String id)
        {
            if (id != null)
            {
                LoaiMT loaiSP = (context.LoaiMTs.ToList()).FirstOrDefault(e => e.Id == id);
                if (loaiSP != null)
                {
                    context.LoaiMTs.Remove(loaiSP);
                    context.SaveChanges();
                    return RedirectToAction("LoaiMT", "QLSanPham", new { area = "Admin" });
                }
            }
            return RedirectToAction("Index", "Home");
        }

        #endregion

        #region Quan ly thong so ky thuat san pham
        public ActionResult TSKTSP(string id)
        {
            TSKTSPViewModel model = new TSKTSPViewModel();
            model.listTSKT = context.TSKTs.ToList(); ;
            return View(model);
        }
        [HttpPost]
        public ActionResult Create_TSKTSP(TSKTSPViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model != null)
                {
                    TSKT thongSo = new TSKT();
                    thongSo.Id = Guid.NewGuid().ToString();
                    thongSo.Name = model.Name;
                    thongSo.Description = model.Description;
                    context.TSKTs.Add(thongSo);
                    context.SaveChanges();
                    return RedirectToAction("TSKTSP", "QLSanPham", new { area = "Admin" });
                }
            }
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Delete_TSKTSP(String id)
        {
            if (id != null)
            {
                TSKT thongSo = (context.TSKTs.ToList()).FirstOrDefault(e => e.Id == id);
                if (thongSo != null)
                {
                    context.TSKTs.Remove(thongSo);
                    context.SaveChanges();
                    return RedirectToAction("TSKTSP", "QLSanPham", new { area = "Admin" });
                }
            }
            return RedirectToAction("Index", "Home");
        }
        #endregion

        #region Quan ly hang san pham
        public ActionResult HangSP()
        {
            HangSPViewModel model = new HangSPViewModel
            {
                Hangs = context.Hangs.ToList(),
            };
            return View(model);
        }
        [HttpPost]
        public ActionResult Create_HangSP(HangSPViewModel model)
        {
            if (model != null)
            {
                Hang hang = new Hang();
                hang.Id = Guid.NewGuid().ToString();
                hang.Name = model.Name;
                context.Hangs.Add(hang);
                context.SaveChanges();
            }
            return RedirectToAction("HangSP", "QLSanPham", new { area = "Admin" });
        }
        public ActionResult Delete_HangSP(String id)
        {
            if (id != null)
            {
                Hang hang = (context.Hangs.ToList()).FirstOrDefault(e => e.Id == id);
                if (hang != null)
                {
                    context.Hangs.Remove(hang);
                    context.SaveChanges();
                    return RedirectToAction("HangSP", "QLSanPham", new { area = "Admin" });
                }
            }
            return RedirectToAction("Index", "Home");
        }
        #endregion

        #region Quan ly cau hinh san pham
        public ActionResult CauHinhSP()
        {
            CauHinhSPViewModel model = new CauHinhSPViewModel
            {
                CauHinhs = context.CauHinhs.ToList(),
            };
            return View(model);
        }
        [HttpPost]
        public ActionResult Create_CauHinhSP(CauHinhSPViewModel model)
        {
            if (model != null)
            {
                CauHinh cauHinh = new CauHinh();
                cauHinh.Id = Guid.NewGuid().ToString();
                cauHinh.Name = model.Name;
                context.CauHinhs.Add(cauHinh);
                context.SaveChanges();
            }
            return RedirectToAction("CauHinhSP", "QLSanPham", new { area = "Admin" });
        }
        public ActionResult Delete_CauHinhSP(String id)
        {
            if (id != null)
            {
                CauHinh cauHinh = (context.CauHinhs.ToList()).FirstOrDefault(e => e.Id == id);
                if (cauHinh != null)
                {
                    context.CauHinhs.Remove(cauHinh);
                    context.SaveChanges();
                    return RedirectToAction("CauHinhSP", "QLSanPham", new { area = "Admin" });
                }
            }
            return RedirectToAction("Index", "Home");
        }
        #endregion
    }
}
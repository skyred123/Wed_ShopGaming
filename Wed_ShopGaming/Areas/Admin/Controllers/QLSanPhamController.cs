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
                loaiSP.Id = Guid.NewGuid().ToString();
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
                LoaiSP loaiSP = (context.LoaiSPs.ToList()).FirstOrDefault(e => e.Id == id);
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
                thongso = context.LoaiSPs.ToList().FirstOrDefault(e=>e.Id == id).ThongSos.ToList();
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
                thongSo.Id = Guid.NewGuid().ToString();
                thongSo.Name = model.Name;
                thongSo.IdLoaiSP = model.IdLoai;
                context.ThongSos.Add(thongSo);
                context.SaveChanges();
            }
            return RedirectToAction("ThongSoSP", "QLSanPham", new { area = "Admin" });
        }
        public ActionResult Delete_ThongSoSP(String id)
        {
            if (id != null)
            {
                ThongSo thongSo = (context.ThongSos.ToList()).FirstOrDefault(e => e.Id == id);
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
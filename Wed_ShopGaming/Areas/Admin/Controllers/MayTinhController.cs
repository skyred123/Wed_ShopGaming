using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wed_ShopGaming.Models;
using Wed_ShopGaming.Models.Entity;
using Wed_ShopGaming.ViewModels;

namespace Wed_ShopGaming.Areas.Admin.Controllers
{
    public class MayTinhController : Controller
    {
        ApplicationDbContext context;
        public MayTinhController()
        {
            context = ApplicationDbContext.Create();
        }
        // GET: Admin/MayTinh
        public ActionResult MayTinh()
        {
            MayTinhViewModel model = new MayTinhViewModel
            {
                CauHinh = context.CauHinhs.ToList(),
                hangs = context.Hangs.ToList(),
                LoaiSP = context.LoaiMTs.ToList(),
            };
            var sp = context.SanPhams.ToList();
            List<SanPham> sanPhams = new List<SanPham>();
            foreach (var item in sp)
            {
                if (item.MayTinh != null)
                {
                    sanPhams.Add(item);
                }
            }
            model.SanPham = sanPhams;
            if(Session["ManagerAction"] != null && (Session["ManagerAction"] as ManagerViewModel).SanPhamId != null)
            {
                var sanphamId = (Session["ManagerAction"] as ManagerViewModel).SanPhamId;
                var mt = context.SanPhams.FirstOrDefault(e => e.Id == sanphamId);
                model.id = mt.Id;
                model.Name = mt.Name;
                model.Amount = mt.Amount.ToString();
                model.Price = mt.Price.ToString();
                model.IdHang = mt.IdHang.ToString();
                model.IdLoai = mt.MayTinh.IdLoaiMT;
                model.IdCauHinh = mt.MayTinh.IdCH;
                (Session["ManagerAction"] as ManagerViewModel).Heading = "Update";
                (Session["ManagerAction"] as ManagerViewModel).SanPhamId = null;
            }
            else
            {
                ManagerViewModel managerViewModel = new ManagerViewModel()
                {
                    Heading = "Create",
                    SanPhamId = null,
                    Action = "Create_MayTinh",
                };
                Session["ManagerAction"] = managerViewModel;
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult Create_MayTinh(MayTinhViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model == null)
                {
                    return RedirectToAction("MayTinh", "MayTinh");
                }
                var id = Guid.NewGuid().ToString();
                MayTinh mt = new MayTinh
                {
                    Id = id,
                    IdCH = model.IdCauHinh,
                    IdLoaiMT = model.IdLoai,
                };
                SanPham sanPham = new SanPham
                {
                    Id = id,
                    Name = model.Name,
                    Amount = int.Parse(model.Amount),
                    Price = int.Parse(model.Price),
                    IdHang = model.IdHang,
                };
                context.SanPhams.Add(sanPham);
                context.MayTinhs.Add(mt);
                context.SaveChanges();
                return RedirectToAction("MayTinh", "MayTinh", new { area = "Admin" });
            }
            return RedirectToAction("MayTinh", "MayTinh");
        }
        [HttpPost]
        public ActionResult Update_MayTinh(MayTinhViewModel model)
        {
            var sanPham = context.SanPhams.FirstOrDefault(e=>e.Id==model.id);
            sanPham.Name = model.Name;
            sanPham.Amount = int.Parse(model.Amount);
            sanPham.Price = int.Parse(model.Price);
            sanPham.IdHang = model.IdHang.ToString();
            sanPham.MayTinh.IdLoaiMT = model.IdLoai;
            sanPham.MayTinh.IdCH = model.IdCauHinh;
            context.SaveChanges();
            return RedirectToAction("MayTinh", "MayTinh");
        }
        public ActionResult Details_MayTinh(string id)
        {
            var sp = context.SanPhams.ToList().FirstOrDefault(e => e.Id == id);
            if (sp == null)
            {
                return RedirectToAction("MayTinh", "MayTinh", new { area = "Admin" });
            }
            ListDetails_MayTinhViewModel model = new ListDetails_MayTinhViewModel();
            model.Details_MayTinh = new List<Details_MayTinhViewModel>();
            foreach(var item in context.LinhKiens.ToList()) {
                var check = item.CT_LinhKiens.Where(e => e.IdMayTinh == sp.Id && e.IdLinhKien == item.Id).ToList().FirstOrDefault();
                if (check == null)
                {
                    Details_MayTinhViewModel temp = new Details_MayTinhViewModel()
                    {
                        Id = item.Id,
                        Name = item.SanPham.Name
                        ,IsCheck= false,
                    };
                    model.Details_MayTinh.Add(temp);
                }
                else
                {
                    Details_MayTinhViewModel temp = new Details_MayTinhViewModel()
                    {
                        Id = item.Id,
                        Name = item.SanPham.Name
                        ,
                        IsCheck = true,
                    };
                    model.Details_MayTinh.Add(temp);
                }
                    
            }
            Session["AddCT_LinhKien"] = model;
            ViewBag.MayTinh = context.SanPhams.ToList().FirstOrDefault(e => e.Id == id);
            return View(model);
        }
        
        [HttpPost]
        public ActionResult Details_MayTinh(ListDetails_MayTinhViewModel model,string idSanPham)
        {
            var listCT_LinhKien = Session["AddCT_LinhKien"] as ListDetails_MayTinhViewModel;
            for (int i=0;i< model.Details_MayTinh.Count();i++)
            {
                if (model.Details_MayTinh[i].IsCheck != listCT_LinhKien.Details_MayTinh[i].IsCheck)
                {
                    if (model.Details_MayTinh[i].IsCheck == false)
                    {
                        CT_LinhKien cT_LinhKien = context.CT_LinhKiens.ToList().Where(e => e.IdMayTinh == idSanPham && e.IdLinhKien == model.Details_MayTinh[i].Id).ToList().FirstOrDefault();
                        context.CT_LinhKiens.Remove(cT_LinhKien);
                        context.SaveChanges();
                    }
                    else if (model.Details_MayTinh[i].IsCheck == true)
                    {
                        var ct_LinhKien = new CT_LinhKien();
                        ct_LinhKien.id = Guid.NewGuid().ToString();
                        ct_LinhKien.IdLinhKien = model.Details_MayTinh[i].Id;
                        ct_LinhKien.IdMayTinh = idSanPham;
                        context.CT_LinhKiens.Add(ct_LinhKien);
                        context.SaveChanges();
                    }
                }
            }

            /*var ct_LinhKien = new CT_LinhKien();
            ct_LinhKien.id = Guid.NewGuid().ToString();
            ct_LinhKien.IdLinhKien = item.Id;
            ct_LinhKien.IdMayTinh = idSanPham;
            context.CT_LinhKiens.Add(ct_LinhKien);
            context.SaveChanges();*/
            return RedirectToAction("MayTinh", "MayTinh");
        }

        public ActionResult Edit_MayTinh(string id)
        {
            ManagerViewModel managerViewModel = new ManagerViewModel()
            {
                SanPhamId = id,
                Action = "Update_MayTinh",
            };
            Session["ManagerAction"] = managerViewModel;
            return RedirectToAction("MayTinh", "MayTinh");
        }
        public ActionResult Delete_LinhKien(string id)
        {
            var sanpham = context.SanPhams.FirstOrDefault(e=>e.Id== id);
            context.SanPhams.Remove(sanpham);
            context.SaveChanges();
            return RedirectToAction("MayTinh", "MayTinh");
        }
    }
}
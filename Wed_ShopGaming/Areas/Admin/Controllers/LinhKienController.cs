using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using Wed_ShopGaming.Models;
using Wed_ShopGaming.Models.Entity;
using Wed_ShopGaming.ViewModels;

namespace Wed_ShopGaming.Areas.Admin.Controllers
{
    public class LinhKienController : Controller
    {
        ApplicationDbContext context;
        public LinhKienController()
        {
            context =  ApplicationDbContext.Create();
        }
        // GET: Admin/SanPhams
        public ActionResult LinhKien()
        {
            LinhKienViewModels model = new LinhKienViewModels
            {
                hangs = context.Hangs.ToList(),
                LoaiSP = context.LoaiLKs.ToList(),
            };
            var sp = context.SanPhams.ToList();
            List<SanPham> sanPhams= new List<SanPham>();
            foreach (var item in sp)
            {
                if(item.LinhKien != null)
                {
                    sanPhams.Add(item);
                }
            }
            model.sanPham = sanPhams;
            return View(model);
        }

        [HttpPost]
        public ActionResult Create_LinhKien(LinhKienViewModels model, List<HttpPostedFileBase> files)
        {
            if (ModelState.IsValid)
            {
                if (model == null)
                {
                    return RedirectToAction("Index", "Home");
                }
                var id = Guid.NewGuid().ToString();
                LinhKien lk = new LinhKien
                {
                    Id = id,
                    IdLoaiLK = model.IdLoai,
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
                context.LinhKiens.Add(lk);
                context.SaveChanges();
                return RedirectToAction("LinhKien", "LinhKien", new { area = "Admin" });
            }
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Description_LinhKien(string id)
        {
            var sp = context.SanPhams.ToList().FirstOrDefault(e => e.Id == id);
            if (sp == null)
            {
                return RedirectToAction("LinhKien", "LinhKien", new { area = "Admin" });
            }
            ListDescription_LinhKienViewModel model = new ListDescription_LinhKienViewModel();
            model.description_LinhKiens = new List<Description_LinhKienViewModel>();
            foreach (var item in context.TSKTs.ToList())
            {
                CT_TSKT check = item.CT_TSKTs.Where(e=>e.IdLinhKien == sp.Id && e.IdTSKT == item.Id).ToList().FirstOrDefault();
                Description_LinhKienViewModel temp = new Description_LinhKienViewModel();
                temp.IdTSKT = item.Id;
                temp.Name = item.Name;
                temp.Description = item.Description;
                if (check == null)
                {
                    
                    temp.IsCheck = false;
                    
                }
                else
                {
                    temp.IsCheck = true;
                }
                model.description_LinhKiens.Add(temp);
            }
            TempData["AddCT_TSKT"] = model;
            ViewBag.SanPham_Description = context.SanPhams.ToList().FirstOrDefault(e=>e.Id==id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Description_LinhKien(ListDescription_LinhKienViewModel model, string idSanPham)
        {
            var listCT_TSKT = (ListDescription_LinhKienViewModel)TempData["AddCT_TSKT"];
            for (int i=0;i< model.description_LinhKiens.Count();i++)
            {
                if (model.description_LinhKiens[i].IsCheck != listCT_TSKT.description_LinhKiens[i].IsCheck)
                {
                    if (model.description_LinhKiens[i].IsCheck == false)
                    {
                        CT_TSKT cT_TSKT = context.CT_TSKTs.ToList().Where(e=> e.IdLinhKien == idSanPham && e.IdTSKT == model.description_LinhKiens[i].IdTSKT).ToList().FirstOrDefault();
                        context.CT_TSKTs.Remove(cT_TSKT);
                        context.SaveChanges();
                    }
                    else if(model.description_LinhKiens[i].IsCheck == false){
                        var ct_TSKT = new CT_TSKT();
                        ct_TSKT.id = Guid.NewGuid().ToString();
                        ct_TSKT.IdTSKT = model.description_LinhKiens[i].IdTSKT;
                        ct_TSKT.IdLinhKien = idSanPham;
                        context.CT_TSKTs.Add(ct_TSKT);
                        context.SaveChanges();
                    }
                }
            }
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Delete_LinhKien(string id)
        {
            return RedirectToAction("Index", "Home");
        }
        
    }
}
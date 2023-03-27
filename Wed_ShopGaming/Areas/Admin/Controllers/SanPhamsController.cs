﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wed_ShopGaming.Models;
using Wed_ShopGaming.Models.Entity;
using Wed_ShopGaming.ViewModels;

namespace Wed_ShopGaming.Areas.Admin.Controllers
{
    public class SanPhamsController : Controller
    {
        ApplicationDbContext context;
        public SanPhamsController()
        {
            context =  ApplicationDbContext.Create();
        }
        // GET: Admin/SanPhams
        public ActionResult LinhKien()
        {
            LinhKienViewModels model = new LinhKienViewModels
            {
                hangs = context.Hangs.ToList(),
                LoaiSP = context.LoaiSPs.ToList(),
                sanPham = context.SanPhams.ToList(),
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Create_LinhKien(LinhKienViewModels model)
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
                    IdLoaiSP = model.IdLoai,
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
                return RedirectToAction("LinhKien", "SanPhams", new { area = "Admin" });
            }
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Description_LinhKien(string id)
        {
            var sp = context.SanPhams.ToList().FirstOrDefault(e => e.Id == id);
            if (sp == null)
            {
                return RedirectToAction("LinhKien", "SanPhams", new { area = "Admin" });
            }
            ListDescription_LinhKienViewModel model = new ListDescription_LinhKienViewModel();
            model.description_LinhKiens = new List<Description_LinhKienViewModel>();
            foreach (var item in context.TSKTs.ToList())
            {
                Description_LinhKienViewModel temp = new Description_LinhKienViewModel();
                temp.Id = item.Id;
                temp.IdLinhKien = id;
                temp.Name = item.Name;
                temp.Description = item.Description;
                temp.IsCheck = false;
                model.description_LinhKiens.Add(temp);
            }
            ViewBag.SanPham_Description = context.SanPhams.ToList().FirstOrDefault(e=>e.Id==id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Description_LinhKien(ListDescription_LinhKienViewModel model)
        {
            /*model = new Description_LinhKienViewModel();
            model.Id = id;
            model.TSKTs = context.TSKTs.ToList();*/
            //var model = context.TSKTs.ToList().FirstOrDefault();
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Delete_LinhKien(string id)
        {
            return RedirectToAction("Index", "Home");
        }
    }
}
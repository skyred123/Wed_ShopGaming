﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wed_ShopGaming.Models;
using Wed_ShopGaming.Models.Entity;
using Wed_ShopGaming.ViewModels;

namespace Wed_ShopGaming.Areas.Admin.Controllers
{
    public class UpLoadFileController : Controller
    {
        ApplicationDbContext context;
        public UpLoadFileController()
        {
            context = ApplicationDbContext.Create();
        }
        // GET: Admin/UpLoadFile
        public ActionResult Image_LinhKien(string id)
        {
            var sp = context.SanPhams.ToList().FirstOrDefault(e => e.Id == id);
            if (sp == null)
            {
                return RedirectToAction("LinhKien", "LinhKien", new { area = "Admin" });
            }
            ViewBag.Image = sp;
            ListHinhAnhViewModel listModel = new ListHinhAnhViewModel();
            listModel.HinhAnhs = new List<HinhAnhViewModel>();
            foreach (var item in sp.HinhAnhs.OrderBy(e=>e.STT))
            {
                HinhAnhViewModel model = new HinhAnhViewModel();
                model.Id = item.Id;
                model.IDSanPham = item.IDSanPham;
                model.IsCheck = false;
                listModel.HinhAnhs.Add(model);
            }
            return View(listModel);
        }
        public ActionResult Image_MayTinh(string id)
        {
            var sp = context.SanPhams.ToList().FirstOrDefault(e => e.Id == id);
            if (sp == null)
            {
                return RedirectToAction("MayTinh", "MayTinh", new { area = "Admin" });
            }
            ViewBag.Image = sp;
            ListHinhAnhViewModel listModel = new ListHinhAnhViewModel();
            listModel.HinhAnhs = new List<HinhAnhViewModel>();
            foreach (var item in sp.HinhAnhs.OrderBy(e=>e.STT))
            {
                HinhAnhViewModel model = new HinhAnhViewModel();
                model.Id = item.Id;
                model.IDSanPham = item.IDSanPham;
                model.IsCheck = false;
                listModel.HinhAnhs.Add(model);
            }
            return View(listModel);
        }
        [HttpPost]
        public ActionResult UploadFile(List<HttpPostedFileBase> file, string idSanPham)
        {
            int i = context.SanPhams.FirstOrDefault(e=>e.Id==idSanPham).HinhAnhs.Count();
            foreach (HttpPostedFileBase fileBase in file)
            {
                if (fileBase != null && fileBase.ContentLength > 0)
                {
                    byte[] data;
                    using (BinaryReader br = new BinaryReader(fileBase.InputStream))
                    {
                        data = br.ReadBytes(fileBase.ContentLength);
                    }
                    HinhAnh hinhAnh = new HinhAnh();
                    hinhAnh.IDSanPham = idSanPham;
                    hinhAnh.Id = Guid.NewGuid().ToString();
                    hinhAnh.Img = data;
                    hinhAnh.STT = i;
                    i++;
                    context.HinhAnhs.Add(hinhAnh);
                    context.SaveChanges();
                }
            }
            return RedirectToAction("Index", "Home");
        }
        public ActionResult RenderImage(string file)
        {
            byte[] bytes = context.HinhAnhs.FirstOrDefault(e=>e.Id == file).Img;
            return File(bytes, "image/png");
        }
        [HttpPost]
        public ActionResult Delete_File(ListHinhAnhViewModel viewModel, string idSanPham)
        {
            foreach (var model in viewModel.HinhAnhs)
            {
                if (model.IsCheck == true)
                {
                    HinhAnh hinhAnh = context.HinhAnhs.FirstOrDefault(e=>e.Id == model.Id);
                    context.HinhAnhs.Remove(hinhAnh);
                    context.SaveChanges();
                }
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
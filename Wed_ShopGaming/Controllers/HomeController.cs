using System.Linq;
using System.Web.Mvc;
using Wed_ShopGaming.Models;
using Wed_ShopGaming.ViewModels;
using PagedList;
using Wed_ShopGaming.Models.Entity;
using System.Collections.Generic;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.EnterpriseServices.CompensatingResourceManager;
using System.Data.Entity.Migrations;
using System.Drawing.Printing;
using System.Web.UI;

namespace Wed_ShopGaming.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext context;

        public HomeController()
        {
            context = ApplicationDbContext.Create();


        }
        public ActionResult Index()
        {


            PagingSPViewModel model = new PagingSPViewModel();
            HinhAnhMainViewModel hinhAnhMain = null;
            List<HinhAnhMainViewModel> LapTop = new List<HinhAnhMainViewModel>();
            List<HinhAnhMainViewModel> MayTinh = new List<HinhAnhMainViewModel>();
            List<HinhAnhMainViewModel> DanhChoBan = new List<HinhAnhMainViewModel>();
            List<HinhAnhMainViewModel> LinhKien = new List<HinhAnhMainViewModel>();
            if (model.page == 0 || model.page == null) model.page = 1;
            model.pageSize = 8;
            if (model.pageSize == 0) { model.pageSize = 1; }
            model.pageNumber = (model.page ?? 1);
            foreach (var item in context.SanPhams.Where(e => e.MayTinh.LoaiMT.Name.Contains("LapTop") == true))
            {
                if (item.Amount != 0)
                {
                    hinhAnhMain = new HinhAnhMainViewModel();
                    if (item.HinhAnhs.Count() != 0)
                    {
                        hinhAnhMain.img = item.HinhAnhs.FirstOrDefault(e => e.STT == 0).Img;
                    }
                    else
                    {
                        hinhAnhMain.img = "";
                    }
                    hinhAnhMain.sanPham = item;
                    LapTop.Add(hinhAnhMain);
                }
            }
            MayTinh = new List<HinhAnhMainViewModel>();
            foreach (var item in context.SanPhams.Where(e => e.MayTinh.LoaiMT.Name.Contains("MayTinh") == true || e.MayTinh.LoaiMT.Name.Contains("Máy Tính") == true))
            {
                if (item.Amount != 0)
                {
                    hinhAnhMain = new HinhAnhMainViewModel();
                    if (item.HinhAnhs.Count() != 0)
                    {
                        hinhAnhMain.img = item.HinhAnhs.FirstOrDefault(e => e.STT == 0).Img;
                    }
                    else
                    {
                        hinhAnhMain.img = "";
                    }
                    hinhAnhMain.sanPham = item;
                    MayTinh.Add(hinhAnhMain);
                }
                    
            }
            DanhChoBan = new List<HinhAnhMainViewModel>();
            foreach (var item in context.SanPhams.Where(e => e.MayTinh.LoaiMT.Name.Contains("LapTop") == false && e.MayTinh.LoaiMT.Name.Contains("MayTinh") == false && e.MayTinh.LoaiMT.Name.Contains("Máy Tính") == false))
            {
                if (item.Amount != 0)
                {
                    hinhAnhMain = new HinhAnhMainViewModel();
                    if (item.HinhAnhs.Count() != 0)
                    {
                        hinhAnhMain.img = item.HinhAnhs.FirstOrDefault(e => e.STT == 0).Img;
                    }
                    else
                    {
                        hinhAnhMain.img = "";
                    }
                    hinhAnhMain.sanPham = item;
                    DanhChoBan.Add(hinhAnhMain);
                }
                    
            }
            LinhKien = new List<HinhAnhMainViewModel>();
            foreach (var item in context.SanPhams.ToList())
            {
                if (item.LinhKien != null)
                {
                    if (item.Amount != 0)
                    {
                        hinhAnhMain = new HinhAnhMainViewModel();
                        if (item.HinhAnhs.Count() != 0)
                        {
                            hinhAnhMain.img = item.HinhAnhs.FirstOrDefault(e => e.STT == 0).Img;
                        }
                        else
                        {
                            hinhAnhMain.img = "";
                        }
                        hinhAnhMain.sanPham = item;
                        LinhKien.Add(hinhAnhMain);
                    }
                       
                }
            }


            if (Session["page"] == null && Session["check"] == null)
            {
                model.LapTop = LapTop.ToPagedList((int)model.page, model.pageSize);
                model.MayTinh = MayTinh.ToPagedList((int)model.page, model.pageSize);
                model.DanhChoBan = DanhChoBan.ToPagedList((int)model.page, model.pageSize);
                model.LinhKien = LinhKien.ToPagedList((int)model.page, model.pageSize);
            }
            else
            {
                if ((int)Session["check"] == 1)
                {
                    model.LapTop = LapTop.ToPagedList((int)Session["page"], model.pageSize);
                    model.MayTinh = MayTinh.ToPagedList((int)model.page, model.pageSize);
                    model.DanhChoBan = DanhChoBan.ToPagedList((int)model.page, model.pageSize);
                    model.LinhKien = LinhKien.ToPagedList((int)model.page, model.pageSize);

                }
                if ((int)Session["check"] == 2)
                {
                    model.LapTop = LapTop.ToPagedList((int)model.page, model.pageSize);
                    model.MayTinh = MayTinh.ToPagedList((int)Session["page"], model.pageSize);
                    model.DanhChoBan = DanhChoBan.ToPagedList((int)model.page, model.pageSize);
                    model.LinhKien = LinhKien.ToPagedList((int)model.page, model.pageSize);

                }
                if ((int)Session["check"] == 3)
                {
                    model.LapTop = LapTop.ToPagedList((int)model.page, model.pageSize);
                    model.MayTinh = MayTinh.ToPagedList((int)model.page, model.pageSize);
                    model.DanhChoBan = DanhChoBan.ToPagedList((int)Session["page"], model.pageSize);
                    model.LinhKien = LinhKien.ToPagedList((int)model.page, model.pageSize);

                }
                if ((int)Session["check"] == 4)
                {
                    model.LapTop = LapTop.ToPagedList((int)model.page, model.pageSize);
                    model.MayTinh = MayTinh.ToPagedList((int)model.page, model.pageSize);
                    model.DanhChoBan = DanhChoBan.ToPagedList((int)model.page, model.pageSize);
                    model.LinhKien = LinhKien.ToPagedList((int)Session["page"], model.pageSize);

                }
            }
            if (User.Identity.IsAuthenticated)
            {
                var userid = User.Identity.GetUserId();
                var listgiohang = context.gioHangs.Where(e => e.UserId == userid);
                if (listgiohang.Count() != 0)
                {
                    List<GioHangViewModel> gioHangViewModel = new List<GioHangViewModel>();
                    foreach (var item in listgiohang)
                    {
                        GioHangViewModel temp = new GioHangViewModel()
                        {
                            sanPham = item.SanPham,
                            count = item.Count,
                        };
                        gioHangViewModel.Add(temp);
                    }

                    Session["GioHang"] = gioHangViewModel;
                }
            }
            else
            {
                Session["GioHang"] = new List<GioHangViewModel>();
            }
            return View(model);
        }

        public ActionResult DanhSachSPCheck(int? page, int check)
        {
            List<HinhAnhMainViewModel> model = new List<HinhAnhMainViewModel>();
            if (page == 0 || page == null) page = 1;
            int pageSize = 8;
            int pageNumber = (page ?? 1);
            if (check == 1)
            {
                foreach (var item in context.SanPhams.Where(e => e.MayTinh.LoaiMT.Name.Contains("LapTop") == true))
                {
                    HinhAnhMainViewModel hinhAnhMain = new HinhAnhMainViewModel();
                    if (item.HinhAnhs.Count() != 0)
                    {
                        hinhAnhMain.img = item.HinhAnhs.FirstOrDefault(e => e.STT == 0).Img;
                    }
                    else
                    {
                        hinhAnhMain.img = "";
                    }
                    hinhAnhMain.sanPham = item;
                    model.Add(hinhAnhMain);
                }
            }
            if (check == 2)
            {
                foreach (var item in context.SanPhams.Where(e => e.MayTinh.LoaiMT.Name.Contains("May Tinh") == true || e.MayTinh.LoaiMT.Name.Contains("Máy Tính") == true))
                {
                    HinhAnhMainViewModel hinhAnhMain = new HinhAnhMainViewModel();
                    if (item.HinhAnhs.Count() != 0)
                    {
                        hinhAnhMain.img = item.HinhAnhs.FirstOrDefault(e => e.STT == 0).Img;
                    }
                    else
                    {
                        hinhAnhMain.img = "";
                    }
                    hinhAnhMain.sanPham = item;
                    model.Add(hinhAnhMain);
                }
            }
            if (check == 3)
            {
                foreach (var item in context.SanPhams.Where(e => e.MayTinh.LoaiMT.Name.Contains("LapTop") == false && e.MayTinh.LoaiMT.Name.Contains("May Tinh") == false && e.MayTinh.LoaiMT.Name.Contains("Máy Tính") == false))
                {
                    HinhAnhMainViewModel hinhAnhMain = new HinhAnhMainViewModel();
                    if (item.HinhAnhs.Count() != 0)
                    {
                        hinhAnhMain.img = item.HinhAnhs.FirstOrDefault(e => e.STT == 0).Img;
                    }
                    else
                    {
                        hinhAnhMain.img = "";
                    }
                    hinhAnhMain.sanPham = item;
                    model.Add(hinhAnhMain);
                }
            }
            if (check == 4)
            {
                foreach (var item in context.SanPhams.ToList())
                {
                    if (item.LinhKien != null)
                    {
                        HinhAnhMainViewModel hinhAnhMain = new HinhAnhMainViewModel();
                        if (item.HinhAnhs.Count() != 0)
                        {
                            hinhAnhMain.img = item.HinhAnhs.FirstOrDefault(e => e.STT == 0).Img;
                        }
                        else
                        {
                            hinhAnhMain.img = "";
                        }
                        hinhAnhMain.sanPham = item;
                        model.Add(hinhAnhMain);
                    }
                }
            }
            Session["PagingSP"] = model.ToPagedList((int)page, pageSize);
            return RedirectToAction("DanhSachSP", "Home", new {check = check});
        }
        public ActionResult DanhSachSP(int? check)
        {
            if(check== null)
            {
                return RedirectToAction("Index", "Home");
            }
            IPagedList<HinhAnhMainViewModel> model;
            if (check ==0 && Session["PagingSP"] != null)
            {
                return View(Session["PagingSP"] as IPagedList<HinhAnhMainViewModel>); 
            }
            ViewBag.check = check;
            
            if (Session["PagingSP"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else if (Session["PagingSP"] != null)
            {
                model = Session["PagingSP"] as IPagedList<HinhAnhMainViewModel>;
                return View(model);
            }
            return RedirectToAction("Index", "Home");
        }
        public ActionResult ChiTietSP(string id)
        {
            var model = context.SanPhams.FirstOrDefault(e => e.Id == id);
            if (model == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }
        public ActionResult AddGioHang(string id,string strURL)
        {
            if (User.Identity.IsAuthenticated)
            {
                var userid = User.Identity.GetUserId();
                var check = context.gioHangs.Where(e => e.UserId == userid);
                var sanPham = new SanPham();
                var giohang = new GioHang()
                {
                    UserId = User.Identity.GetUserId(),
                };
                if (check == null)
                {
                    Session["GioHang"] = new List<GioHangViewModel>();
                    sanPham = context.SanPhams.FirstOrDefault(e => e.Id == id);
                    GioHangViewModel item = new GioHangViewModel()
                    {
                        sanPham = sanPham,
                        count = 1,
                    };
                    giohang.Count = item.count;
                    (Session["GioHang"] as List<GioHangViewModel>).Add(item);
                    giohang.SanPhamId = sanPham.Id;
                    context.gioHangs.Add(giohang);
                }
                else if (check != null)
                {
                    List<GioHangViewModel> gioHangViewModel = new List<GioHangViewModel>();
                    foreach (var item in check)
                    {
                        GioHangViewModel temp = new GioHangViewModel()
                        {
                            sanPham = item.SanPham,
                            count = item.Count,
                        };
                        gioHangViewModel.Add(temp);
                    }
                    
                    Session["GioHang"] = gioHangViewModel;

                    var item1 = (Session["GioHang"] as List<GioHangViewModel>).FirstOrDefault(e => e.sanPham.Id == id);
                    if (item1 != null)
                    {
                        var gh = context.gioHangs.FirstOrDefault(e => e.SanPhamId == item1.sanPham.Id && e.UserId == userid);
                        item1.count++;
                        giohang.Count++;
                        gh.Count++;
                    }
                    else
                    {
                        sanPham = context.SanPhams.FirstOrDefault(e => e.Id == id);
                        GioHangViewModel temp = new GioHangViewModel()
                        {
                            sanPham = sanPham,
                            count = 1,
                        };
                        giohang.Count= temp.count;
                        (Session["GioHang"] as List<GioHangViewModel>).Add(temp);
                        giohang.SanPhamId = sanPham.Id;
                        context.gioHangs.Add(giohang);
                    }
                }
                context.SaveChanges();
            }
            else
            {
                if (Session["GioHang"] == null)
                {
                    Session["GioHang"] = new List<GioHangViewModel>();
                    var sanPham = context.SanPhams.FirstOrDefault(e => e.Id == id);
                    GioHangViewModel item = new GioHangViewModel()
                    {
                        sanPham = sanPham,
                        count = 1,
                    };
                    (Session["GioHang"] as List<GioHangViewModel>).Add(item);
                }
                else
                {
                    var item = (Session["GioHang"] as List<GioHangViewModel>).FirstOrDefault(e => e.sanPham.Id == id);
                    if (item != null)
                    {
                        item.count++;
                    }
                    else
                    {
                        var sanPham = context.SanPhams.FirstOrDefault(e => e.Id == id);
                        GioHangViewModel giohang = new GioHangViewModel()
                        {
                            sanPham = sanPham,
                            count = 1,
                        };
                        (Session["GioHang"] as List<GioHangViewModel>).Add(giohang);
                    }
                }
            }
            return Redirect(strURL);
        }
        public ActionResult DeleteCountGioHang(string id, string strURL)
        {
            if(User.Identity.IsAuthenticated)
            {
                var sp = (Session["GioHang"] as List<GioHangViewModel>).FirstOrDefault(e=>e.sanPham.Id == id);
                if(sp != null)
                {
                    var item = context.gioHangs.FirstOrDefault(e=>e.SanPhamId== id);
                    if(item != null && item.Count!=1) {
                        sp.count--;
                        item.Count--;
                    }
                    else
                    {
                        (Session["GioHang"] as List<GioHangViewModel>).Remove(sp);
                        context.gioHangs.Remove(item);
                    }
                    context.SaveChanges();
                }
            }
            else
            {
                var sp = (Session["GioHang"] as List<GioHangViewModel>).FirstOrDefault(e=>e.sanPham.Id == id);
                if(sp != null)
                {
                    if(sp != null && sp.count!=1) {
                        sp.count--;
                    }
                    else
                    {
                        (Session["GioHang"] as List<GioHangViewModel>).Remove(sp);
                    }
                }
            }
            return Redirect(strURL);
        }
        public ActionResult DeleteGioHang(string id, string strURL)
        {
            if (User.Identity.IsAuthenticated)
            {
                var sp = (Session["GioHang"] as List<GioHangViewModel>).FirstOrDefault(e => e.sanPham.Id == id);
                if (sp != null)
                {
                    var item = context.gioHangs.FirstOrDefault(e => e.SanPhamId == id);
                    if (item != null)
                    {
                        (Session["GioHang"] as List<GioHangViewModel>).Remove(sp);
                        context.gioHangs.Remove(item); context.SaveChanges();
                    }
                    
                }
            }
            else
            {
                var sp = (Session["GioHang"] as List<GioHangViewModel>).FirstOrDefault(e => e.sanPham.Id == id);
                if (sp != null)
                {
                    if (sp != null)
                    {
                        (Session["GioHang"] as List<GioHangViewModel>).Remove(sp);
                    }

                }
            }
            return Redirect(strURL);
        }
        public double TongTienGioHang(List<GioHangViewModel> gioHangs)
        {
            double result = 0;
            if (gioHangs != null)
            {
                foreach (var item in gioHangs)
                {
                    result += item.sanPham.Price * item.count;
                }
            }
            return result;
        }
        public ActionResult ListGioHang()
        {
            if (User.Identity.IsAuthenticated)
            {
                var userid = User.Identity.GetUserId();
                var listgiohang = context.gioHangs.Where(e => e.UserId == userid);
                List<GioHangViewModel> gioHangViewModel = new List<GioHangViewModel>();
                foreach (var item in listgiohang)
                {
                    GioHangViewModel temp = new GioHangViewModel()
                    {
                        sanPham = item.SanPham,
                        count = item.Count,
                    };
                    gioHangViewModel.Add(temp);
                }

                Session["GioHang"] = gioHangViewModel;
            }
            var gioHangs = Session["GioHang"] as List<GioHangViewModel>;
            ViewBag.TongTien = TongTienGioHang(gioHangs);
            List<HinhAnhMainViewModel> model = new List<HinhAnhMainViewModel>();
            if (gioHangs == null)
            {
                return View(model);
            }
            foreach (var item in gioHangs)
            {
                HinhAnhMainViewModel temp = new HinhAnhMainViewModel();
                temp.sanPham = item.sanPham;
                if (item.sanPham.HinhAnhs.Count() != 0)
                {
                    temp.img = item.sanPham.HinhAnhs.FirstOrDefault(e => e.STT == 0).Img;
                }
                else
                {
                    temp.img = "";
                }
                temp.count = item.count;
                model.Add(temp);
            }
            return View(model);
        }
        public ActionResult PageList(int page, int check) {
            Session["page"]  = page;
            Session["check"] = check;
            return RedirectToAction("Index", "Home");
        }
        public ActionResult DanhSachLoaiSP(string id,int check)
        {
            var mt = new List<MayTinh>();
            var lk = new List<LinhKien>();
            List<HinhAnhMainViewModel> model = new List<HinhAnhMainViewModel>();
            if (check == 1)
            {
                mt = context.LoaiMTs.Where(e=>e.Id== id).FirstOrDefault().MayTinh.ToList();
                foreach (var item in mt)
                {
                    HinhAnhMainViewModel hinhAnhMain = new HinhAnhMainViewModel();
                    if (item.SanPham.HinhAnhs.Count() != 0)
                    {
                        hinhAnhMain.img = item.SanPham.HinhAnhs.FirstOrDefault(e => e.STT == 0).Img;
                    }
                    else
                    {
                        hinhAnhMain.img = "";
                    }
                    hinhAnhMain.sanPham = item.SanPham;
                    model.Add(hinhAnhMain);
                }
            }
            else
            {
                lk = context.LoaiLKs.Where(e => e.Id == id).FirstOrDefault().LinhKiens.ToList();
                foreach (var item in lk)
                {
                    HinhAnhMainViewModel hinhAnhMain = new HinhAnhMainViewModel();
                    if (item.SanPham.HinhAnhs.Count() != 0)
                    {
                        hinhAnhMain.img = item.SanPham.HinhAnhs.FirstOrDefault(e => e.STT == 0).Img;
                    }
                    else
                    {
                        hinhAnhMain.img = "";
                    }
                    hinhAnhMain.sanPham = item.SanPham;
                    model.Add(hinhAnhMain);
                }
            }
            Session["PagingSP"] = model.ToPagedList((int)1, model.Count());
            return RedirectToAction("DanhSachSP", "Home", new { check = 0 });
        }
    }
}